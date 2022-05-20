using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record SubGenre(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name
);