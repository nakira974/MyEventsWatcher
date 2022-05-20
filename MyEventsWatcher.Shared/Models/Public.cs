using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Public(
    [property: JsonPropertyName("startDateTime")] System.DateTime StartDateTime,
    [property: JsonPropertyName("startTBD")] bool StartTBD,
    [property: JsonPropertyName("startTBA")] bool StartTBA,
    [property: JsonPropertyName("endDateTime")] System.DateTime EndDateTime
);