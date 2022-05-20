using System.Text.Json.Serialization;
using MyNamespace;

namespace MyEventsWatcher.Shared.Models;

public record Embedded{
    [property: JsonPropertyName("events")] public List<DiscoveryEvent> Events { get; set; }
    [property: JsonPropertyName("venues")] public List<Venue>? Venues { get; set; }
    [property: JsonPropertyName("attractions")] public List<Attraction> Attractions { get; set; }
}