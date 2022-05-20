using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

public record Image
{
    [JsonPropertyName("url")]
    public Url Url { get; set; }

    [JsonPropertyName("width")]
    public Width Width { get; set; }

    [JsonPropertyName("height")]
    public Height Height { get; set; }

    [JsonPropertyName("fallback")]
    public Fallback Fallback { get; set; }

    [JsonPropertyName("ratio")]
    public Ratio Ratio { get; set; }
}