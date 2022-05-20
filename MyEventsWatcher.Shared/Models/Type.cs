using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Type(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("name")] string Name
);