using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record NoSpecificTime
{
    [JsonPropertyName("type")]
    public  string Type => "boolean";

    [JsonPropertyName("value")]
    public bool? Value { get; set; }
}