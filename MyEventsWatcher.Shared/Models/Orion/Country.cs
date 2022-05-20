using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

public record Country
{
    [JsonPropertyName("name")]
    public Name Name { get; set; }

    [JsonPropertyName("countryCode")]
    public CountryCode CountryCode { get; set; }
}