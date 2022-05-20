using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Social(
    [property: JsonPropertyName("twitter")] Twitter Twitter
);