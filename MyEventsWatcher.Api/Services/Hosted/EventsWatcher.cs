using System.Globalization;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using MyEventsWatcher.Api.Models.Orion;
using MyEventsWatcher.Shared;
using MyEventsWatcher.Shared.Models;
using MyEventsWatcher.Shared.Models.Orion;
using MyNamespace;
using Classification = MyEventsWatcher.Shared.Models.Classification;

namespace MyEventsWatcher.Api.Services.Hosted;

public class EventsWatcher : IHostedService, IDisposable
{
    private int _executionCount = 0;
    private readonly ILogger<EventsWatcher> _logger;
    private readonly IHttpClientFactory _httpClient;
    private readonly IJsonSerializer _jsonSerializer;
    private Timer _timer = null!;

    public EventsWatcher(ILogger<EventsWatcher> logger, IHttpClientFactory httpClient, IJsonSerializer jsonSerializer)
    {
        _logger = logger;
        _httpClient = httpClient;
        _jsonSerializer = jsonSerializer;
    }

    public Task StartAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service running.");

        _timer = new Timer(DoWork, null, TimeSpan.Zero, 
            TimeSpan.FromMinutes(120));

        return Task.CompletedTask;
    }

    private async void DoWork(object? state)
    {
        var count = Interlocked.Increment(ref _executionCount);
        var eventsPool = _httpClient.CreateClient("Events");
        
        try
        {
            var discoveryEvents = await eventsPool.GetFromJsonAsync<DiscoveryEvents?>(string.Empty);
            var events = new List<DiscoveryEvent?>(discoveryEvents.Embedded.Events.Count);
            var relationshipEntities = new List<Operation.EntityRelationship>();
            var unused = string.Empty;
            
            foreach (var currentEvent in discoveryEvents.Embedded.Events)
            {
                var @event = await GetEventDetails(currentEvent.Id);
                try
                {
                    unused = @event?.Id;
                    var record = new Event(@event, @event?.Embedded.Venues);

                    if (!await PostEntity("Entities", record)) continue;
                    
                    events.Add(@event);
                    //On fait le lien event-venue
                    @event?.Embedded?.Venues?.ForEach(venue =>
                    {
                        var operationEntity = new Operation
                            .EntityRelationship(@event.Id, venue.Id);
                        relationshipEntities.Add(operationEntity);
                    });
                }
                
                
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _logger.LogWarning($"Get Event details ID: {unused} failed.", e);
                    continue;
                }
            }

            if (relationshipEntities is not {Count: 0})
            {
                var updateOperation = new UpdateOperation(relationshipEntities);
                await PostEntity("Entities-Relationship", updateOperation);
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
            throw;
        }

        return result;
    }

    public Task StopAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Timed Hosted Service is stopping.");

        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public async Task<DiscoveryEvent?> GetEventDetails(string id)
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
    

    public void Dispose()
    {
        _timer?.Dispose();
    }
}