using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Endpoint(
    [property: JsonPropertyName("uri")] string Uri,
    [property: JsonPropertyName("accept")] string Accept
);

public record Entity(
    [property: JsonPropertyName("type")] string Type
);

public record Notification(
    [property: JsonPropertyName("attributes")] IReadOnlyList<string> Attributes,
    [property: JsonPropertyName("format")] string Format,
    [property: JsonPropertyName("endpoint")] Endpoint Endpoint
);

public record Subscription(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("entities")] IReadOnlyList<Entity> Entities,
    [property: JsonPropertyName("watchedAttributes")] IReadOnlyList<string> WatchedAttributes,
    [property: JsonPropertyName("notification")] Notification Notification,
    [property: JsonPropertyName("@context")] string Context
);
