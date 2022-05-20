using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record GeneralInfo
{
    [JsonPropertyName("type")] public const string Type = "string";
        
    [JsonPropertyName("value")] public int Value { get; set; }

}