// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

using System.ComponentModel.DataAnnotations.Schema;

namespace MyNamespace;

using System.Text.Json.Serialization;

public class Ada
    {
        [JsonPropertyName("adaPhones")]
        public string AdaPhones { get; set; }

        [JsonPropertyName("adaCustomCopy")]
        public string AdaCustomCopy { get; set; }

        [JsonPropertyName("adaHours")]
        public string AdaHours { get; set; }
    }

    public class Address
    {
        [JsonPropertyName("line1")]
        public string Line1 { get; set; }
    }

    public class BoxOfficeInfo
    {
        [JsonPropertyName("phoneNumberDetail")]
        public string PhoneNumberDetail { get; set; }

        [JsonPropertyName("openHoursDetail")]
        public string OpenHoursDetail { get; set; }

        [JsonPropertyName("acceptedPaymentDetail")]
        public string AcceptedPaymentDetail { get; set; }

        [JsonPropertyName("willCallDetail")]
        public string WillCallDetail { get; set; }
    }

    public class City
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    public class Country
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("countryCode")]
        public string CountryCode { get; set; }
    }

    public class Dma
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }

    public class Embedded
    {
        [JsonPropertyName("venues")]
        public List<Venue> Venues { get; set; }
    }

    public class First
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }

    public class GeneralInfo
    {
        [JsonPropertyName("generalRule")]
        public string GeneralRule { get; set; }

        [JsonPropertyName("childRule")]
        public string ChildRule { get; set; }
    }

    public class Image
    {
        [JsonPropertyName("ratio")]
        public string Ratio { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("fallback")]
        public bool Fallback { get; set; }

        [JsonPropertyName("attribution")]
        public string Attribution { get; set; }
    }

    public class Last
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }

    public class Links
    {
        [JsonPropertyName("self")]
        public Self Self { get; set; }

        [JsonPropertyName("first")]
        public First First { get; set; }

        [JsonPropertyName("next")]
        public Next Next { get; set; }

        [JsonPropertyName("last")]
        public Last Last { get; set; }
    }

    public class Location
    {
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }
    }

    public class Market
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }
    }

    public class Next
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }

    public class Page
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("totalElements")]
        public int TotalElements { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("number")]
        public int Number { get; set; }
    }

    public class DiscoveryVenues
    {
        [JsonPropertyName("_embedded")]
        public Embedded Embedded { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("page")]
        public Page Page { get; set; }
    }

    public class Self
    {
        [JsonPropertyName("href")]
        public string Href { get; set; }
    }

    public class Social
    {
        [JsonPropertyName("twitter")]
        public Twitter Twitter { get; set; }
    }

    public class State
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("stateCode")]
        public string StateCode { get; set; }
    }

    public class Twitter
    {
        [JsonPropertyName("handle")]
        public string Handle { get; set; }
    }

    public class UpcomingEvents
    {
        [JsonPropertyName("_total")]
        public int Total { get; set; }

        [JsonPropertyName("ticketmaster")]
        public int Ticketmaster { get; set; }

        [JsonPropertyName("_filtered")]
        public int Filtered { get; set; }

        [JsonPropertyName("tmr")]
        public int? Tmr { get; set; }
    }

    public record Venue
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("images")]
        public List<Image> Images { get; set; }

        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

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

        [JsonPropertyName("upcomingEvents")]
        public UpcomingEvents UpcomingEvents { get; set; }

        [JsonPropertyName("_links")]
        public Links Links { get; set; }

        [JsonPropertyName("aliases")]
        public List<string> Aliases { get; set; }

        [JsonPropertyName("social")]
        public Social Social { get; set; }

        [JsonPropertyName("boxOfficeInfo")]
        public BoxOfficeInfo BoxOfficeInfo { get; set; }

        [JsonPropertyName("parkingDetail")]
        public string ParkingDetail { get; set; }

        [JsonPropertyName("accessibleSeatingDetail")]
        public string AccessibleSeatingDetail { get; set; }

        [JsonPropertyName("generalInfo")]
        public GeneralInfo GeneralInfo { get; set; }

        [JsonPropertyName("ada")]
        public Ada Ada { get; set; }
    }

