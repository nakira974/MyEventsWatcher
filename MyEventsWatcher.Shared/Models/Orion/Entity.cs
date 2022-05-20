using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Entity(
    [property: JsonPropertyName("type")] string Type
);