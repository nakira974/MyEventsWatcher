using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record State(
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("stateCode")] string StateCode
);