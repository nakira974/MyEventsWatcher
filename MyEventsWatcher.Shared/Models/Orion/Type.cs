using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Type
{
    [JsonPropertyName("type")]
    public string EventType { get; set; }
}