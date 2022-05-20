using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Dates(
    [property: JsonPropertyName("start")] Start Start,
    [property: JsonPropertyName("timezone")] string Timezone,
    [property: JsonPropertyName("status")] Status Status,
    [property: JsonPropertyName("spanMultipleDays")] bool SpanMultipleDays
);