using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Self(
    [property: JsonPropertyName("href")] string Href
);