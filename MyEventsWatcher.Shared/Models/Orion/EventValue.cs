using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public class EventValue
{
    [JsonPropertyName("public")]
    public Public? Public { get; set; }

    [JsonPropertyName("startDateTime")]
    public StartDateTime? StartDateTime { get; set; }

    [JsonPropertyName("startTBD")]
    public StartTBD? StartTBD { get; set; }

    [JsonPropertyName("startTBA")]
    public StartTBA? StartTBA { get; set; }

    [JsonPropertyName("endDateTime")]
    public EndDateTime? EndDateTime { get; set; }

    [JsonPropertyName("start")]
    public Start? Start { get; set; }

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