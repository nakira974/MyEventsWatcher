using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record UpcomingEvents(
    [property: JsonPropertyName("_total")] int Total,
    [property: JsonPropertyName("tmr")] int Tmr,
    [property: JsonPropertyName("ticketmaster")] int Ticketmaster,
    [property: JsonPropertyName("_filtered")] int Filtered
);