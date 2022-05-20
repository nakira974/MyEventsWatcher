using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Market(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("id")] string Id
);