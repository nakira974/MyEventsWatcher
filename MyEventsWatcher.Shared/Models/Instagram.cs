using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Instagram(
    [property: JsonPropertyName("url")] string Url
);