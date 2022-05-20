using System.Text.Json.Serialization;
using MyEventsWatcher.Shared.Models.Orion;

namespace MyEventsWatcher.Api.Models.Orion;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

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