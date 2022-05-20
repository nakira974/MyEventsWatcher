using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record TicketLimit(
    [property: JsonPropertyName("info")] string Info
);