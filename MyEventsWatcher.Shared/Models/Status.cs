using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Status(
    [property: JsonPropertyName("code")] string Code
);