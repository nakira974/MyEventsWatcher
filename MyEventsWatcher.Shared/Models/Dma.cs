using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Dma(
    [property: JsonPropertyName("id")] int Id
);