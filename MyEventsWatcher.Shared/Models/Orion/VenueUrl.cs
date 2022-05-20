using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record VenueUrl
{
    [JsonPropertyName("type")]
    public string Type => "string";

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}