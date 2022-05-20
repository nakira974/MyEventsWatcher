using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record BoxOfficeInfo
{
    [JsonPropertyName("type")] public const string Type = "string";
    [JsonPropertyName("value")] public string Value { get; set; }
}