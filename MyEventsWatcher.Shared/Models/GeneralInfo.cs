using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record GeneralInfo(
    [property: JsonPropertyName("childRule")] string ChildRule,
    [property: JsonPropertyName("generalRule")] string GeneralRule
);