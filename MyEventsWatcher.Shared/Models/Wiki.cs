using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Wiki(
    [property: JsonPropertyName("url")] string Url
);