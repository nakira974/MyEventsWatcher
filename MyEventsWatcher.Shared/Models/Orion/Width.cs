using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Width
{
    [JsonPropertyName("type")] public const string Type = "integer";
    [JsonPropertyName("value")] public int Value { get; set; }
}