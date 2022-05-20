using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;



public class UpdateOperation : Operation
{
    public UpdateOperation(IEnumerable<EntityRelationship> entities)
    {
        Entities = entities.ToList();
    }
    [JsonPropertyName("actionType")]
    public string ActionType { get =>"APPEND";}

    [JsonPropertyName("entities")]
    public List<EntityRelationship> Entities { get; set; }
}
