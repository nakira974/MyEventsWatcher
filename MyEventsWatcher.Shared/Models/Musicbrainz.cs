using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Musicbrainz(
    [property: JsonPropertyName("id")] string Id
);