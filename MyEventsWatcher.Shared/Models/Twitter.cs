using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public partial record Twitter(
    [property: JsonPropertyName("handle")] string Handle,
    [property: JsonPropertyName("url")] string Url
);