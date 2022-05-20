using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Lastfm(
    [property: JsonPropertyName("url")] string Url
);