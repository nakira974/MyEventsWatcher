using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Page(
    [property: JsonPropertyName("size")] int Size,
    [property: JsonPropertyName("totalElements")] int TotalElements,
    [property: JsonPropertyName("totalPages")] int TotalPages,
    [property: JsonPropertyName("number")] int Number
);