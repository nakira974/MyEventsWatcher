using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Facebook(
    [property: JsonPropertyName("url")] string Url
);