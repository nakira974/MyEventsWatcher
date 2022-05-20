using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Genre(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name
);