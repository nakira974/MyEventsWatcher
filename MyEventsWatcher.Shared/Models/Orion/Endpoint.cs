using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Endpoint(
    [property: JsonPropertyName("uri")] string Uri,
    [property: JsonPropertyName("accept")] string Accept
);