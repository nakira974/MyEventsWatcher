using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public abstract class Operation
{
    public class EntityRelationship
    {
        public EntityRelationship(string sourceId, string destinationId, string type)
        {
            Destination = destinationId;
            RefStore = new RefStore(sourceId);
            Type = type;
        }

        [Required]
        [JsonPropertyName("id")]
        public string Destination { get; set; }

        [JsonPropertyName("type")] public string Type { get; set; }

        [JsonPropertyName("refVenue")]
        public RefStore RefStore { get; set; }
    }

    public class RefStore
    {
        public RefStore(string source)
        {
            Source = source;
        }

        [JsonPropertyName("type")]
        public string Type => "Relationship";

        [Required]
        [JsonPropertyName("value")]
        public string Source { get; set; }
    }
}