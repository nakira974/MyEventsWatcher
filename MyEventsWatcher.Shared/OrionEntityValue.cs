using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Services;

public abstract record OrionEntityValue<T>
{
    [JsonPropertyName("value")]
    [Required]
    public object? Value { get; set; }
}