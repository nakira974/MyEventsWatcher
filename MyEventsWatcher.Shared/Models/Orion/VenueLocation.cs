using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record VenueLocation
{
    [JsonPropertyName("type")]
    public string Type => "geo:json";

    [JsonPropertyName("value")]
    public EventCoordinates? Value { get; set; }
}