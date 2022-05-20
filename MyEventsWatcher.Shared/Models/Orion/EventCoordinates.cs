using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record EventCoordinates
{
    [JsonPropertyName("type")]
    public string Type => "Point";

    [JsonPropertyName("coordinates")]
    public List<float?>? Coordinates { get; set; }
}