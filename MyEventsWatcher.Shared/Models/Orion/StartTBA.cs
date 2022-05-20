using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record StartTBA
{
    [JsonPropertyName("type")]
    public  string Type => "boolean";

    [JsonPropertyName("value")]
    public bool? Value { get; set; }
}