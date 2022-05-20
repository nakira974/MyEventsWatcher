using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Next(
    [property: JsonPropertyName("href")] string Href
);