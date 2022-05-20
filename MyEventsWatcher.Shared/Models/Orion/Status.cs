using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Status
{
    [JsonPropertyName("code")]
    public Code? Code { get; set; }
}