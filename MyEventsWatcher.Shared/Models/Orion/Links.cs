using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Links
{
    [JsonPropertyName("self")]
    public Self Self { get; set; }
}