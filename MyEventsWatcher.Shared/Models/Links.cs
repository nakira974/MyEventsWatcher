using System.Text.Json.Serialization;
using MyNamespace;

namespace MyEventsWatcher.Shared.Models;

public record Links(
    [property: JsonPropertyName("self")] Self Self,
    [property: JsonPropertyName("attractions")] IReadOnlyList<Attraction> Attractions,
    [property: JsonPropertyName("venues")] IReadOnlyList<Venue> Venues,
    [property: JsonPropertyName("first")] First First,
    [property: JsonPropertyName("next")] Next Next,
    [property: JsonPropertyName("last")] Last Last
);