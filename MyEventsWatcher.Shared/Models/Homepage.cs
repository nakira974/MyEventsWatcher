using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Homepage(
    [property: JsonPropertyName("url")] string Url
);