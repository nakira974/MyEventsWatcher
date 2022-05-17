using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Services;

public abstract record OrionEntityAttribute<T>
{
    [JsonPropertyName("type")]
    [Required]
    public string? Type { get; set; }
    
    [JsonPropertyName("value")]
    [Required]
    public object? Value { get; set; }
}

public abstract record OrionEntityValue<T>
{
    [JsonPropertyName("value")]
    [Required]
    public object? Value { get; set; }
}