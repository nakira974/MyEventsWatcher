using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Country(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("countryCode")] string CountryCode
);