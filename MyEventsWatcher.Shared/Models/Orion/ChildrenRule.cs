using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record ChildrenRule
{
    [JsonPropertyName("type")] public const string Type = "Text";


    [JsonPropertyName("value")]
    public string? Value { get; set; }
}