using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

public record VenueValue
{
    [NotMapped] public string? _id { get; set; }
    [JsonPropertyName("id")] public string Id => $"urn:ngsi-ld:Venue:{_id}";
    [JsonPropertyName("type")] public string Type => $"Venue";

    [JsonPropertyName("aliases")]
    public Aliases? Aliases { get; set; }

    [JsonPropertyName("city")]
    public EventCity? City { get; set; }

    [JsonPropertyName("accepted_payment")]
    public AcceptedPayment? AcceptedPayment { get; set; }

    [JsonPropertyName("country")]
    public EventCountry? Country { get; set; }

    [JsonPropertyName("location")]
    public VenueLocation? Location { get; set; }

    [JsonPropertyName("url")]
    public VenueUrl? Url { get; set; }

    [JsonPropertyName("parking_detail")]
    public EventParkingDetail? ParkingDetail { get; set; }

    [JsonPropertyName("name")]
    public VenueName? Name { get; set; }

    [JsonPropertyName("children_rule")]
    public ChildrenRule? ChildrenRule { get; set; }

    [JsonPropertyName("general_rule")]
    public GeneralRule? GeneralRule { get; set; }
        
    [JsonPropertyName("address")]
    public EventAddress? Address { get; set; }
        
    [JsonPropertyName("twitter")]
    public EventTwitter? Twitter { get; set; }
}