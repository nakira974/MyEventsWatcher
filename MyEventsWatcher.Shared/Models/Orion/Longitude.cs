using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Longitude
{
    [JsonPropertyName("type")] public const string Type = "float";
    [JsonPropertyName("value")] public float Value { get; set; }

        
}