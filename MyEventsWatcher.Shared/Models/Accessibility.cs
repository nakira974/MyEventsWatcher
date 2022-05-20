using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Accessibility(
    [property: JsonPropertyName("ticketLimit")] int TicketLimit,
    [property: JsonPropertyName("url")] string Url,
    [property: JsonPropertyName("urlText")] string UrlText,
    [property: JsonPropertyName("info")] string Info
);