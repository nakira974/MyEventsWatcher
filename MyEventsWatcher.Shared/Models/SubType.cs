using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record SubType(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name
);