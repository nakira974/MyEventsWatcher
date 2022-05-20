using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Outlet(
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("type")] string Type
);