using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Name
{
    [JsonPropertyName("type")]
    public  string Type => "Text";

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}