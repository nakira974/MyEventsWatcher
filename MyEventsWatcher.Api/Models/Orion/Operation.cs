using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;

public abstract class Operation
{
    public class EntityRelationship
    {
        public EntityRelationship(string sourceId, string destinationId)
        {
            Destination = destinationId;
            RefStore = new RefStore(sourceId);
        }

        [Required]
        [JsonPropertyName("id")]
        public string Destination { get; set; }

        [JsonPropertyName("type")]
        public string Type => "Shelf";

        [JsonPropertyName("refStore")]
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