using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models;

public class AppConfig
{
    [JsonPropertyName("entities")]
    public string? EntitiesUrl { get; set; }
    
    [JsonPropertyName("subscriptions")]
    public string? SubscriptionsUrl { get; set; }
    
    [JsonPropertyName("events")]
    public string? EventsUrl { get; set; }
    
    [JsonPropertyName("venues")]
    public string? Venues { get; set; }
    
    [JsonPropertyName("discoveryBaseUri")]
    public string? DiscoveryBaseUri { get; set; }
}