using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Subscription(
    [property: JsonPropertyName("description")] string Description,
    [property: JsonPropertyName("type")] string Type,
    [property: JsonPropertyName("entities")] IReadOnlyList<Entity> Entities,
    [property: JsonPropertyName("watchedAttributes")] IReadOnlyList<string> WatchedAttributes,
    [property: JsonPropertyName("notification")] Notification Notification,
    [property: JsonPropertyName("@context")] string Context
);
