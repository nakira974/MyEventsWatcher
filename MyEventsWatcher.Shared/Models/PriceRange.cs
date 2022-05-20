using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record PriceRange(
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("currency")] string Currency,
    [property: JsonPropertyName("min")] double Min,
    [property: JsonPropertyName("max")] double Max
);