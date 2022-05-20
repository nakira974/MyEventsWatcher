using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record Aliases
{
    [JsonPropertyName("value")]
    public List<string>? AlliasesValue { get; set; }
}