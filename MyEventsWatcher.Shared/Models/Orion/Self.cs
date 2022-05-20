using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Self
{
    [JsonPropertyName("href")]
    public Href Href { get; set; }
}