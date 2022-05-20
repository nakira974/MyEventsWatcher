using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Start(
    [property: JsonPropertyName("localDate")] string LocalDate,
    [property: JsonPropertyName("localTime")] string LocalTime,
    [property: JsonPropertyName("dateTime")] System.DateTime DateTime,
    [property: JsonPropertyName("dateTBD")] bool DateTBD,
    [property: JsonPropertyName("dateTBA")] bool DateTBA,
    [property: JsonPropertyName("timeTBA")] bool TimeTBA,
    [property: JsonPropertyName("noSpecificTime")] bool NoSpecificTime
);