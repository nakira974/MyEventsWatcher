using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Location(
    [property: JsonPropertyName("longitude")] string Longitude,
    [property: JsonPropertyName("latitude")] string Latitude
);