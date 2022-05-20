using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Product(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("classifications")] IReadOnlyList<Classification> Classifications
);