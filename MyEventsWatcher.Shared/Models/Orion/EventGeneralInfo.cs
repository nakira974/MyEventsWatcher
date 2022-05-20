using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record EventGeneralInfo
{
    [JsonPropertyName("value")]
    public VenueValue? VenueValue { get; set; }
}