using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Last(
    [property: JsonPropertyName("href")] string Href
);