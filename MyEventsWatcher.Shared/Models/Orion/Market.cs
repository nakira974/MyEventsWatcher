using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

public record Market
{
    [JsonPropertyName("name")]
    public Name Name { get; set; }

    [JsonPropertyName("id")]
    public EventId Id { get; set; }
}