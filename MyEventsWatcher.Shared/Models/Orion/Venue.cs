// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion
{
    public record AcceptedPayment
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public record Aliases
    {
        [JsonPropertyName("value")]
        public List<string>? AlliasesValue { get; set; }
    }

    public record ChildrenRule
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public record EventCity
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public record EventCountry
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public record EventGeneralInfo
    {
        [JsonPropertyName("value")]
        public VenueValue? VenueValue { get; set; }
    }

    public record EventCoordinates
    {
        [JsonPropertyName("type")]
        public string Type => "Point";

        [JsonPropertyName("coordinates")]
        public List<float?>? Coordinates { get; set; }
    }

    public record GeneralRule
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public record VenueLocation
    {
        [JsonPropertyName("type")]
        public string Type => "geo:json";

        [JsonPropertyName("value")]
        public EventCoordinates? Value { get; set; }
    }

    public record VenueName
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public record EventParkingDetail
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

    public record EventVenues
    {
        [JsonPropertyName("value")]
        public List<VenueValue> Value { get; set; }
    }

    public record VenueUrl
    {
        [JsonPropertyName("type")]
        public string Type => "string";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }

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

  

    public record EventAddress
    {
        [JsonPropertyName("type")]
        public string Type => "Text";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }
    
    public record EventTwitter
    {
        [JsonPropertyName("type")]
        public string Type => "Text";

        [JsonPropertyName("value")]
        public string? Value { get; set; }
    }


}
