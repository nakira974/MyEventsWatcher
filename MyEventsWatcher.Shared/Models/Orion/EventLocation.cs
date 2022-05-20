using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public record Address
    {
        [JsonPropertyName("line1")]
        public Line1 Line1 { get; set; }
    }

    public record BoxOfficeInfo
    {
        [JsonPropertyName("type")] public const string Type = "string";
        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public record City
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }
    }

    public record Country
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("countryCode")]
        public CountryCode CountryCode { get; set; }
    }

    public record CountryCode
    {
        [JsonPropertyName("type")] public const string Type = "string";
        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public record Dma
    {
        [JsonPropertyName("id")]
        public EventId Id { get; set; }
    }

    public record Fallback
    {
        [JsonPropertyName("type")] public const string Type = "boolean";
        [JsonPropertyName("value")] public bool Value { get; set; }
    }

    public record Filtered
    {
        [JsonPropertyName("type")] public const string Type = "integer";
        
        [JsonPropertyName("value")] public int Value { get; set; }
        
    }

    public record GeneralInfo
    {
        [JsonPropertyName("type")] public const string Type = "string";
        
        [JsonPropertyName("value")] public int Value { get; set; }

    }

    public record Height
    {
        [JsonPropertyName("type")] public const string Type = "integer";
        
        [JsonPropertyName("value")] public int Value { get; set; }
    }

    public record Href
    {
        [JsonPropertyName("type")] public const string Type = "string";

        [JsonPropertyName("value")] public string Value { get; set; }
    } 

public record Image
    {
        [JsonPropertyName("url")]
        public Url Url { get; set; }

        [JsonPropertyName("width")]
        public Width Width { get; set; }

        [JsonPropertyName("height")]
        public Height Height { get; set; }

        [JsonPropertyName("fallback")]
        public Fallback Fallback { get; set; }

        [JsonPropertyName("ratio")]
        public Ratio Ratio { get; set; }
    }

    public record Latitude
    {
        [JsonPropertyName("type")] public const string Type = "float";
        [JsonPropertyName("value")] public float Value { get; set; }
    }

    public record Line1
    {
        [JsonPropertyName("type")] public const string Type = "string";
        
        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public record Links
    {
        [JsonPropertyName("self")]
        public Self Self { get; set; }
    }

    public record Location
    {
        [JsonPropertyName("longitude")]
        public Longitude Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public Latitude Latitude { get; set; }
    }

    public record Longitude
    {
        [JsonPropertyName("type")] public const string Type = "float";
        [JsonPropertyName("value")] public float Value { get; set; }

        
    }

    public record Market
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("id")]
        public EventId Id { get; set; }
    }


    public record ParkingDetail
    {
        [JsonPropertyName("type")] public const string Type = "string";
        
        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public record PostalCode
    {
        [JsonPropertyName("type")] public const string Type = "string";
        
        [JsonPropertyName("value")] public string Value { get; set; }

    }

    public record Ratio
    {
        [JsonPropertyName("type")] public const string Type = "string";
        
        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public record EventLocation
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("type")]
        public Type Type { get; set; }

        [JsonPropertyName("id")]
        public EventId Id { get; set; }

        [JsonPropertyName("test")]
        public Test Test { get; set; }

        [JsonPropertyName("url")]
        public Url Url { get; set; }

        [JsonPropertyName("locale")]
        public Locale Locale { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        [JsonPropertyName("postalCode")]
        public PostalCode PostalCode { get; set; }

        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; }

        [JsonPropertyName("city")]
        public City City { get; set; }

        [JsonPropertyName("state")]
        public State State { get; set; }

        [JsonPropertyName("country")]
        public Country Country { get; set; }

        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("location")]
        public Location Location { get; set; }

        [JsonPropertyName("markets")]
        public List<Market> Markets { get; set; }

        [JsonPropertyName("dmas")]
        public List<Dma> Dmas { get; set; }

        [JsonPropertyName("boxOfficeInfo")]
        public BoxOfficeInfo BoxOfficeInfo { get; set; }

        [JsonPropertyName("parkingDetail")]
        public ParkingDetail ParkingDetail { get; set; }

        [JsonPropertyName("generalInfo")]
        public GeneralInfo GeneralInfo { get; set; }

        [JsonPropertyName("upcomingEvents")]
        public UpcomingEvents UpcomingEvents { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }
    }

    public record Self
    {
        [JsonPropertyName("href")]
        public Href Href { get; set; }
    }

    public record State
    {
        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("stateCode")]
        public StateCode StateCode { get; set; }
    }

    public record StateCode
    {
        [JsonPropertyName("type")] public const string Type = "string";
        
        [JsonPropertyName("value")] public string Value { get; set; }
    }

    public record Ticketmaster
    {
        [JsonPropertyName("type")] public const string Type = "integer";
        [JsonPropertyName("value")] public int Value { get; set; }
    }

    public record Total
    {
        [JsonPropertyName("type")] public const string Type = "integer";
        [JsonPropertyName("value")] public int Value { get; set; }
    }

    public record Type
    {
        [JsonPropertyName("type")]
        public string EventType { get; set; }
    }

    public record UpcomingEvents
    {
        [JsonPropertyName("_total")]
        public Total Total { get; set; }

        [JsonPropertyName("ticketmaster")]
        public Ticketmaster Ticketmaster { get; set; }

        [JsonPropertyName("_filtered")]
        public Filtered Filtered { get; set; }
    } 

public record Width
    {
        [JsonPropertyName("type")] public const string Type = "integer";
        [JsonPropertyName("value")] public int Value { get; set; }
    }

