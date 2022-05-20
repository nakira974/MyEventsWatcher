using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record DiscoveryEvents(
    [property: JsonPropertyName("_embedded")] Embedded Embedded,
    [property: JsonPropertyName("_links")] Links Links,
    [property: JsonPropertyName("page")] Page Page
);