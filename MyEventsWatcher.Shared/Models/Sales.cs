using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

public record Sales(
    [property: JsonPropertyName("public")] Public Public,
    [property: JsonPropertyName("presales")] IReadOnlyList<Presale> Presales
);