using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Locale
{
    [JsonPropertyName("type")]
    public  string Type => "Text";

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}