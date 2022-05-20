using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Public
{
    [JsonPropertyName("startDateTime")]
    public StartDateTime? StartDateTime { get; set; }

    [JsonPropertyName("startTBD")]
    public StartTBD? StartTBD { get; set; }

    [JsonPropertyName("startTBA")]
    public StartTBA? StartTBA { get; set; }

    [JsonPropertyName("endDateTime")]
    public EndDateTime? EndDateTime { get; set; }
}