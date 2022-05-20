using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Location
{
    [JsonPropertyName("longitude")]
    public Longitude Longitude { get; set; }

    [JsonPropertyName("latitude")]
    public Latitude Latitude { get; set; }
}