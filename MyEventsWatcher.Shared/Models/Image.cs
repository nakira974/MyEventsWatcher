using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Image(
    [property: JsonPropertyName("ratio")] string Ratio,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("width")] int Width,
    [property: JsonPropertyName("height")] int Height,
    [property: JsonPropertyName("fallback")] bool Fallback,
    [property: JsonPropertyName("attribution")] string Attribution
);