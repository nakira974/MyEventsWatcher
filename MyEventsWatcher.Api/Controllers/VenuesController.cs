using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using MyEventsWatcher.Shared;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("services/v1/[controller]")]
public class VenuesController : Controller
{
    private readonly ILogger<EventsController> _logger;
    private readonly IHttpClientFactory _httpClient;
    private readonly IJsonSerializer _jsonSerializer;

    public VenuesController(ILogger<EventsController> logger, IHttpClientFactory httpClient, IJsonSerializer jsonSerializer)
    {
        _logger = logger;
        _httpClient = httpClient;
        _jsonSerializer = jsonSerializer;
    }

    private string IdPattern { get; } = "urn:ngsi-ld:Venue:";
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VenueValue>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<VenueValue>), StatusCodes.Status204NoContent)]
    [Route("[action]")]
    
    public async Task<IActionResult> Search(float latitude, float longitude, short range)
    {
        IActionResult result = StatusCode(204, new List<VenueValue>());
        var client = _httpClient.CreateClient("Entities");
        var uri = $"entities/?georel=near;maxDistance:{range}&geometry=point&coords={latitude.ToString("0.000000", CultureInfo.InvariantCulture)},{longitude.ToString("0.000000", CultureInfo.InvariantCulture)}&type=Venue";
        try
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var content =
                await _jsonSerializer.DeserializeAsync<List<VenueValue?>?>(json);
            
            switch ((content ?? new List<VenueValue?>()).Count().Equals(0))
            {
                case true:
                    break;
                
                case false:
                    result = Ok(content);
                    break;
            }
        }
        catch (Exception e)
        {
            _logger.LogError("EventsController::Get(float latitude, float longitude) Error :", e);
            result = StatusCode(500, e);
        }

        return result;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(VenueValue), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(VenueValue), StatusCodes.Status204NoContent)]
    [Route("[action]")]
    public async Task<IActionResult> Get(string id)
    {
        var urn = id.Contains(IdPattern) ? id : IdPattern+id;
        IActionResult result = StatusCode(204, new VenueValue(IdPattern+new Guid().ToString("N")));
        var client = _httpClient.CreateClient("Entities");
        var uri = $"entities/{urn}";
        try
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var content = await _jsonSerializer
                .DeserializeAsync<Event?>(await response
                    .Content.ReadAsStringAsync());
            
            if (content is not null) result = Ok(content);
        }
        catch (Exception e)
        {
            _logger.LogError("EventsController::Get() Error :", e);
            result = StatusCode(500, e);
        }
        
        return result;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<VenueValue>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<VenueValue>), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll()
    {
        IActionResult result = StatusCode(204, new List<VenueValue>());
        var client = _httpClient.CreateClient("Entities");

        try
        {
            var content = await client.GetFromJsonAsync<IEnumerable<VenueValue?>?>("entities/?type=Venue");
            if (content is not null) result = Ok(content);
        }
        catch (Exception e)
        {
            _logger.LogError("EventsController::Get() Error :", e);
            result = StatusCode(500, e);
        }
        
        return result;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status204NoContent)]
    [Route("[action]")]
    public async Task<IActionResult> GetVenueEvents(string id)
    {
        var urn = id.Contains(IdPattern) ? id : IdPattern+id;
        IActionResult result = StatusCode(204, new List<Event>());
        var client = _httpClient.CreateClient("Entities");
        var uri = $"entities/?q=refVenue=={urn}&options=count";
        try
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            
            var content = await _jsonSerializer
                .DeserializeAsync<List<Event>?>(await response
                    .Content.ReadAsStringAsync());
            
            if (content is not null) result = Ok(content);
        }
        catch (Exception e)
        {
            _logger.LogError("EventsController::Get() Error :", e);
            result = StatusCode(500, e);
        }
        
        return result;
    }
}