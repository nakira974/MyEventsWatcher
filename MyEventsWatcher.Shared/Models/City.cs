using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record City(
    [property: JsonPropertyName("name")] string Name
);