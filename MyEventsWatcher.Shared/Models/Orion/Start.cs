using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Start
{
    [JsonPropertyName("dateTime")]
    public DateTime? DateTime { get; set; }

    [JsonPropertyName("dateTBD")]
    public DateTBD? DateTBD { get; set; }

    [JsonPropertyName("dateTBA")]
    public DateTBA? DateTBA { get; set; }

    [JsonPropertyName("timeTBA")]
    public TimeTBA? TimeTBA { get; set; }

    [JsonPropertyName("noSpecificTime")]
    public NoSpecificTime? NoSpecificTime { get; set; }
}