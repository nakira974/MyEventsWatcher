using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Address(
    [property: JsonPropertyName("line1")] string Line1
);