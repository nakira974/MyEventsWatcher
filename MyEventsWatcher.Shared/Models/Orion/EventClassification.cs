using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record EventClassification
{
    [JsonPropertyName("value")]
    public Value? Details { get; set; }

    public record Value
    {
        public record Genre
        {
            [JsonPropertyName("type")]
            public string Type => "Text";

            [JsonPropertyName("value")]
            public string? Value { get; set; }
        }
        
        public record Segment
        {
            [JsonPropertyName("type")]
            public string Type => "Text";

            [JsonPropertyName("value")]
            public string? Value { get; set; }
        }
        
        public record EventType
        {
            [JsonPropertyName("type")]
            public string Type => "Text";

            [JsonPropertyName("value")]
            public string? Value { get; set; }
        }
        
        [JsonPropertyName("genre")]
        public Genre? EventGenre { get; set; }
        
        [JsonPropertyName("segment")]
        public Segment? EventSegment { get; set; }
        
        [JsonPropertyName("type")]
        public EventType? Type { get; set; }
        
    }
}