using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Seatmap(
    [property: JsonPropertyName("staticUrl")] string StaticUrl
);