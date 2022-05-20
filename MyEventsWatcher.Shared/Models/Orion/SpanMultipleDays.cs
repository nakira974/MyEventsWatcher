using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record SpanMultipleDays
{
    [JsonPropertyName("type")]
    public  string Type => "boolean";

    [JsonPropertyName("value")]
    public bool Value { get; set; }
}