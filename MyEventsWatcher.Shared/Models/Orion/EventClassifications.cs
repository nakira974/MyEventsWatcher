using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record EventClassifications
{
    [JsonPropertyName("value")]
    public List<EventClassification> Classifications { get; set; }
}