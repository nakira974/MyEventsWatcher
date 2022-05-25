using System.Text.Json.Serialization;
using MyEventsWatcher.Api.Models.Orion;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Notification(
    [property: JsonPropertyName("attributes")] IReadOnlyList<string> Attributes,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("endpoint")] Endpoint Endpoint
);