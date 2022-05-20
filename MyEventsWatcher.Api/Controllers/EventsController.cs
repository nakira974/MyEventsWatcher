using Microsoft.AspNetCore.Mvc;
using MyEventsWatcher.Shared;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Controllers;

[ApiController]
[Produces("application/json")]
[Route("services/v1/[controller]")]
public class EventsController : ControllerBase
{
    private readonly ILogger<EventsController> _logger;
    private readonly IHttpClientFactory _httpClient;
    private readonly IJsonSerializer _jsonSerializer;
    private string IdPattern { get; } = "urn:ngsi-ld:Event:";

    public EventsController(ILogger<EventsController> logger, IHttpClientFactory httpClient, IJsonSerializer jsonSerializer)
    {
        _logger = logger;
        _httpClient = httpClient;
        _jsonSerializer = jsonSerializer;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status204NoContent)]
    [Route("[action]")]
    
    public async Task<IActionResult> Search(float latitude, float longitude, short range)
    {
        IActionResult result = StatusCode(204, new List<Event>());
        var client = _httpClient.CreateClient("Entities");
        var uri = $"?georel=near;maxDistance:{range}&geometry=point&coords={latitude},{longitude}&type=Event&options=keyValues";
        try
        {
            var content = await client.GetFromJsonAsync<IEnumerable<Event?>?>(uri);
            
            switch ((content ?? Array.Empty<Event?>()).Count().Equals(0))
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
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll()
    {
        IActionResult result = StatusCode(204, new List<Event>());
        var client = _httpClient.CreateClient("Entities");

        try
        {
            var content = await client.GetFromJsonAsync<IEnumerable<Event?>?>("entities/?type=Event");
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
    [ProducesResponseType(typeof(Event), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(Event), StatusCodes.Status204NoContent)]
    [Route("[action]")]
    public async Task<IActionResult> Get(string id)
    {
        var urn = id.Contains(IdPattern) ? id : IdPattern+id;
        IActionResult result = StatusCode(204, new Event());
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

    [HttpPost]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<Event>), StatusCodes.Status204NoContent)]
    [Route("[action]")]
    public async Task<IActionResult> Subscribe([FromHeader]UserSubscription userSubscription, IEnumerable<Event> events)
    {
        var subscriptionsDone = new List<Event>(); 
        IActionResult result = StatusCode(204, subscriptionsDone);
        var client = _httpClient.CreateClient("Subscriptions");
        try
        {
            events.ToList().ForEach(async currentEvent =>
            {
                try
                {
                    var httpContent = new StringContent(await _jsonSerializer.SerializeAsync(currentEvent));
                    var response = await client.PostAsync(string.Empty, httpContent);
                    response.EnsureSuccessStatusCode();
                    subscriptionsDone.Add(currentEvent);
                }
                catch (Exception e)
                {
                    _logger.LogError("Subscription failed", e);
                    throw;
                }
            });

            if (subscriptionsDone.Count > 0) result = Ok(subscriptionsDone);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return result;
    }
}