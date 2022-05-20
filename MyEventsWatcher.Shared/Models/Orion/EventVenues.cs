using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record EventVenues
{
    [JsonPropertyName("value")]
    public List<VenueValue> Value { get; set; }
}