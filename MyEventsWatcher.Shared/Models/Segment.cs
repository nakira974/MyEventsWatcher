using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Segment(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name
);