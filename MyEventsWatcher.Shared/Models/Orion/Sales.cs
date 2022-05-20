using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Sales
{
    [JsonPropertyName("value")]
    public EventValue EventValue { get; set; }
}