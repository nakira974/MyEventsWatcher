using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Classification(
    [property: JsonPropertyName("primary")] bool Primary,
    [property: JsonPropertyName("segment")] Segment Segment,
    [property: JsonPropertyName("genre")] Genre Genre,
    [property: JsonPropertyName("subGenre")] SubGenre SubGenre,
    [property: JsonPropertyName("type")] Type Type,
    [property: JsonPropertyName("subType")] SubType SubType,
    [property: JsonPropertyName("family")] bool Family
);