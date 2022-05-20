using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Promoter(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("description")] string Description
);