using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

public record Dma
{
    [JsonPropertyName("id")]
    public EventId Id { get; set; }
}