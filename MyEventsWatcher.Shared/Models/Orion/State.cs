using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

public record State
{
    [JsonPropertyName("name")]
    public Name Name { get; set; }

    [JsonPropertyName("stateCode")]
    public StateCode StateCode { get; set; }
}