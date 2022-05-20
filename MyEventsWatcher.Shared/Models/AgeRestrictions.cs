using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record AgeRestrictions(
    [property: JsonPropertyName("legalAgeEnforced")] bool LegalAgeEnforced
);