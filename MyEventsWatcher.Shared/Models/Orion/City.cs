using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

public record City
{
    [JsonPropertyName("name")]
    public Name Name { get; set; }
}