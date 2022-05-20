using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record EndDateTime
{
    [JsonPropertyName("type")]
    public  string Type => "DateTime";

    [JsonPropertyName("value")]
    public System.DateTime? Value { get; set; }
}