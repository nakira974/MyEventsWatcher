using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Attraction(
    [property: JsonPropertyName("href")] string Href,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("test")] bool Test,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("locale")] string Locale,
    [property: JsonPropertyName("externalLinks")] ExternalLinks ExternalLinks,
    [property: JsonPropertyName("aliases")] IReadOnlyList<string> Aliases,
    [property: JsonPropertyName("images")] IReadOnlyList<Image> Images,
    [property: JsonPropertyName("classifications")] IReadOnlyList<Classification> Classifications,
    [property: JsonPropertyName("upcomingEvents")] UpcomingEvents UpcomingEvents,
    [property: JsonPropertyName("_links")] Links Links
);