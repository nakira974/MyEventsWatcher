using System.Text.Json.Serialization;

namespace MyEventsWatcher.Api.Models.Orion;



public class UpdateOperation : Operation
{
    public UpdateOperation(IEnumerable<object> entities)
    {
        Entities = entities.ToList();
    }
    [JsonPropertyName("actionType")]
    public string ActionType => "APPEND";

    [JsonPropertyName("entities")]
    public List<object> Entities { get; set; }
}
