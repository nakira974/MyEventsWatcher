using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record UpcomingEvents
{
    [JsonPropertyName("_total")]
    public Total Total { get; set; }

    [JsonPropertyName("ticketmaster")]
    public Ticketmaster Ticketmaster { get; set; }

    [JsonPropertyName("_filtered")]
    public Filtered Filtered { get; set; }
}