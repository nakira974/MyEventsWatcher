using System.Globalization;
using MyEventsWatcher.Api.Models.Orion;
using MyEventsWatcher.Shared;
using MyEventsWatcher.Shared.Models;
using MyEventsWatcher.Shared.Models.Orion;
using MyNamespace;
using Classification = MyEventsWatcher.Shared.Models.Classification;
// ReSharper disable InconsistentNaming
// ReSharper disable All

namespace MyEventsWatcher.Api.Services.Hosted;

/// <summary>
/// Tâche de fond visant à récupère les données depuis une API source, transformer ces dernières et les insèrer dans FIWARE.
/// </summary>
public class EventsWatcher : IHostedService, IDisposable
{
    private int _executionCount = 0;
    private readonly ILogger<EventsWatcher> _logger;
    private readonly IHttpClientFactory _httpClient;
    private readonly IJsonSerializer _jsonSerializer;
    private Timer _timer = null!;

    /// <summary>
    /// Constructeur principal de la tâche de fond.
    /// </summary>
    /// <param name="logger"></param>
    /// <param name="httpClient"></param>
    /// <param name="jsonSerializer"></param>
    public EventsWatcher(ILogger<EventsWatcher> logger, IHttpClientFactory httpClient, IJsonSerializer jsonSerializer)
    {
        _logger = logger;
        _httpClient = httpClient;
        _jsonSerializer = jsonSerializer;
    }

    /// <summary>
    /// Lance la tâche de fond.
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, 
            TimeSpan.FromMinutes(120));

        return Task.CompletedTask;
    }

    /// <summary>
    /// Méthode principale de la tâche de fond, elle récupère les données sur l'API source, les transforme pour Orion et les insèrent.
    /// </summary>
    /// <param name="state"></param>
    private async void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref _executionCount);
        var eventsPool = _httpClient.CreateClient("Events");
        
        try
        {
            var discoveryEvents = await eventsPool.GetFromJsonAsync<DiscoveryEvents?>(string.Empty);
            var relationshipEntities = new List<Operation.EntityRelationship>();
            var unused = string.Empty;
            
            // ReSharper disable once AsyncVoidLambda
            discoveryEvents?.Embedded.Events.ForEach(async newEvent =>
            {
                var @event = await GetEventDetails(newEvent.Id);
                try
                {
                    unused = @event?.Id;
                    var record = new Event(@event);
                    var venues = GetVenues(@event?.Embedded.Venues);
                   
                    if (record is not null && !await PostEntity(pool:"Entities", entity:record)) return;
                    
                    // ReSharper disable once AsyncVoidLambda
                    //On fait le lien event-venue
                    venues?.ForEach(async venue =>
                    {
                        if (@event is not null)
                        {
                            var operationEntity = new Operation
                                .EntityRelationship(@event.Id, venue.Id);
                            relationshipEntities.Add(operationEntity);
                        }

                        if (!await PostEntity(pool:"Entities", entity:venue)) 
                            _logger.LogWarning($"Venue ID : {venue.Id} has not been integrated into Orion Brocker");
                    });
                }
                
                
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _logger.LogWarning($"Get Event details ID: {unused} failed", e);
                }
            });

            if (relationshipEntities is not {Count: 0})
            {
                var updateOperation = new UpdateOperation(relationshipEntities);
                if(await PostEntity("Entities-Relationship", updateOperation)) _logger.LogWarning("Orion has been updated !");
                else _logger.LogWarning("Orion has not been updated correctly");
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        _logger.LogInformation(
            "Timed Hosted Service is working. Count: {Count}", count);
    }
    
    /// <summary>
    /// Retourne les Venues au format Orion à partir de ceux de l'API source.
    /// </summary>
    /// <param name="venues">Venues de l'API source</param>
    /// <returns></returns>
    private List<VenueValue> GetVenues(IEnumerable<Venue>? venues)
{
    var result = new List<VenueValue>();

    if (venues is not null)
        foreach (var venue in venues)
        {
            var value = new VenueValue()
            {
                _id = venue.Id,

                Aliases = new Aliases()
                {
                    AlliasesValue = venue?.Aliases ?? new List<string>()
                },
                City = new EventCity()
                {
                    Value = venue?.City?.Name ?? string.Empty
                },
                Country = new EventCountry()
                {
                    Value = venue?.Country?.Name ?? string.Empty
                },
                Location = new VenueLocation()
                {
                    Value = new EventCoordinates()
                    {
                        Coordinates = new List<float>(2)
                        {
                            float.Parse(venue?.Location?.Latitude ?? "0.0", CultureInfo.InvariantCulture),
                            float.Parse(venue?.Location?.Longitude ?? "0.0", CultureInfo.InvariantCulture)
                        }
                    }
                },
                Name = new VenueName()
                {
                    Value = venue?.Name ?? string.Empty
                },
                Url = new VenueUrl()
                {
                    Value = venue?.Url ?? string.Empty
                },
                Address = new EventAddress()
                {
                    Value = venue?.Address?.Line1 ?? string.Empty
                },
                Twitter = new EventTwitter()
                {
                    Value = venue?.Social?.Twitter?.Handle ?? string.Empty
                },
                ChildrenRule = new ChildrenRule()
                {
                    Value = venue?.GeneralInfo?.ChildRule ?? string.Empty
                },
                GeneralRule = new GeneralRule()
                {
                    Value = venue?.GeneralInfo?.GeneralRule ?? string.Empty
                },
                ParkingDetail = new EventParkingDetail()
                {
                    Value = venue?.ParkingDetail ?? string.Empty
                }
            };
            result.Add(value);
        }

    return result;
}

    /// <summary>
    /// Méthode POST générique offrant la possibilité de choisir le pool Http.
    /// </summary>
    /// <param name="pool"></param>
    /// <param name="entity"></param>
    /// <returns></returns>
    private async Task<bool> PostEntity(string pool, object entity)
    {
        var result = false;
        try
        {
            var client = _httpClient.CreateClient(pool);
            var response = await client.PostAsJsonAsync(string.Empty, entity);
            response.EnsureSuccessStatusCode();
            result = true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return result;
        }
        
        return result;
    }

    /// <summary>
    /// Stop la tâche de fond.
    /// </summary>
    /// <param name="stoppingToken"></param>
    /// <returns></returns>
    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    /// <summary>
    /// Lance une requête http GET vers l'API source pour obtenir les détails d'un événemment. 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private async Task<DiscoveryEvent?> GetEventDetails(string id)
    {
        try
        {
            var ticketMasterClient = _httpClient.CreateClient("DiscoveryApi");
            var uri = $"{id}.json?apikey=Sc0vURbseHTexqrEiJAWGAhgigyR3U5p";
            try
            {
                var discoveryEvent = await ticketMasterClient.GetFromJsonAsync<DiscoveryEvent>(uri);
                discoveryEvent!.Embedded.Venues ??= new List<Venue>();
                discoveryEvent.Classifications ??= new List<Classification>();
                return discoveryEvent;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    /// <summary>
    /// Lâche toute les ressources associée à la tâche de fond.
    /// </summary>
    public void Dispose()
    {
        _timer?.Dispose();
    }
    
    /// <summary>
    /// Lâche toute les ressources associée à la tâche de fond de manière asynchrône.
    /// </summary>
    public async Task DisposeAsync()
    {
        await _timer.DisposeAsync();
    }
    
}