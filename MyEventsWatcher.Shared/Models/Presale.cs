using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Presale(
    [property: JsonPropertyName("startDateTime")] System.DateTime StartDateTime,
    [property: JsonPropertyName("endDateTime")] System.DateTime EndDateTime,
    [property: JsonPropertyName("name")] string Name
);