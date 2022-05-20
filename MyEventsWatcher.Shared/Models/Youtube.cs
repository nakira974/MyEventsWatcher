using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Youtube(
    [property: JsonPropertyName("url")] string Url
);