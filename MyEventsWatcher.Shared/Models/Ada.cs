using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Ada(
    [property: JsonPropertyName("adaPhones")] string AdaPhones,
    [property: JsonPropertyName("adaCustomCopy")] string AdaCustomCopy,
    [property: JsonPropertyName("adaHours")] string AdaHours
);