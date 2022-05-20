using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Fallback
{
    [JsonPropertyName("type")] public const string Type = "boolean";
    [JsonPropertyName("value")] public bool Value { get; set; }
}