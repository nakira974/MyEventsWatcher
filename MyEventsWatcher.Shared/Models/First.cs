using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record First(
    [property: JsonPropertyName("href")] string Href
);