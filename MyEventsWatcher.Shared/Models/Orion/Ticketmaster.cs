using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public record Ticketmaster
{
    [JsonPropertyName("type")] public const string Type = "integer";
    [JsonPropertyName("value")] public int Value { get; set; }
}