using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record ExternalLinks(
    [property: JsonPropertyName("twitter")] IReadOnlyList<Twitter> Twitter,
    [property: JsonPropertyName("facebook")] IReadOnlyList<Facebook> Facebook,
    [property: JsonPropertyName("wiki")] IReadOnlyList<Wiki> Wiki,
    [property: JsonPropertyName("instagram")] IReadOnlyList<Instagram> Instagram,
    [property: JsonPropertyName("homepage")] IReadOnlyList<Homepage> Homepage,
    [property: JsonPropertyName("youtube")] IReadOnlyList<Youtube> Youtube,
    [property: JsonPropertyName("lastfm")] IReadOnlyList<Lastfm> Lastfm,
    [property: JsonPropertyName("musicbrainz")] IReadOnlyList<Musicbrainz> Musicbrainz
);