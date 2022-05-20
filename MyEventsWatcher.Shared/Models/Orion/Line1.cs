using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Line1
{
    [JsonPropertyName("type")] public const string Type = "string";
        
    [JsonPropertyName("value")] public string Value { get; set; }
}