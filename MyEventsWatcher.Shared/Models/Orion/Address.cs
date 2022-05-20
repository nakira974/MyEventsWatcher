using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Address
{
    [JsonPropertyName("line1")]
    public Line1 Line1 { get; set; }
}