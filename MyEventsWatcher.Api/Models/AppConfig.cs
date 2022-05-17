using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models;

public class AppConfig
{
    [JsonPropertyName("entities")]
    public string? EntitiesUrl { get; set; }
    
    [JsonPropertyName("subscriptions")]
    public string? SubscriptionsUrl { get; set; }
}