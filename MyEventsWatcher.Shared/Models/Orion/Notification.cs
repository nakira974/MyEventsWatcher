using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Notification(
    [property: JsonPropertyName("attributes")] IReadOnlyList<string> Attributes,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("endpoint")] Endpoint Endpoint
);