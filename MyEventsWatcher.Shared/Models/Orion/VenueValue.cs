using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record VenueValue
{
    public VenueValue(string id)
    {
        VenueId = new EventId()
        {
            Value = id
        };
            
    }
    [JsonPropertyName("id")] public string Id
    {
        get { return $"urn:ngsi-ld:Venue:{VenueId.Value}"; }
    }

    [JsonPropertyName("type")] public string Type => $"Venue";

    [JsonIgnore]
    public Aliases? Aliases { get; set; }

    [JsonPropertyName("city")]
    public EventCity? City { get; set; }

    [JsonIgnore]
    public AcceptedPayment? AcceptedPayment { get; set; }

    [JsonPropertyName("country")]
    public EventCountry? Country { get; set; }

    [JsonPropertyName("location")]
    public VenueLocation? Location { get; set; }

    [JsonPropertyName("url")]
    public VenueUrl? Url { get; set; }

    [JsonIgnore]
    public EventParkingDetail? ParkingDetail { get; set; }

    [JsonPropertyName("name")]
    public VenueName? Name { get; set; }

   [JsonIgnore]
    public ChildrenRule? ChildrenRule { get; set; }

    [JsonIgnore]
    public GeneralRule? GeneralRule { get; set; }
        
    [JsonPropertyName("address")]
    public EventAddress? Address { get; set; }
        
    [JsonPropertyName("twitter")]
    public EventTwitter? Twitter { get; set; }
    
    [JsonPropertyName("venue_code")]
    public EventId VenueId { get; set; }
}