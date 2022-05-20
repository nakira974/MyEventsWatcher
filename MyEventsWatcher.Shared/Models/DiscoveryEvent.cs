using System.Text.Json.Serialization;
using MyNamespace;

namespace MyEventsWatcher.Shared.Models;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
    public record Accessibility(
        [property: JsonPropertyName("ticketLimit")] int TicketLimit,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("urlText")] string UrlText,
        [property: JsonPropertyName("info")] string Info
    );

    public record Ada(
        [property: JsonPropertyName("adaPhones")] string AdaPhones,
        [property: JsonPropertyName("adaCustomCopy")] string AdaCustomCopy,
        [property: JsonPropertyName("adaHours")] string AdaHours
    );

    public record Address(
        [property: JsonPropertyName("line1")] string Line1
    );

    public record AgeRestrictions(
        [property: JsonPropertyName("legalAgeEnforced")] bool LegalAgeEnforced
    );

    public record Attraction(
        [property: JsonPropertyName("href")] string Href,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("test")] bool Test,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("locale")] string Locale,
        [property: JsonPropertyName("externalLinks")] ExternalLinks ExternalLinks,
        [property: JsonPropertyName("aliases")] IReadOnlyList<string> Aliases,
        [property: JsonPropertyName("images")] IReadOnlyList<Image> Images,
        [property: JsonPropertyName("classifications")] IReadOnlyList<Classification> Classifications,
        [property: JsonPropertyName("upcomingEvents")] UpcomingEvents UpcomingEvents,
        [property: JsonPropertyName("_links")] Links Links
    );

    public record BoxOfficeInfo(
        [property: JsonPropertyName("phoneNumberDetail")] string PhoneNumberDetail,
        [property: JsonPropertyName("willCallDetail")] string WillCallDetail,
        [property: JsonPropertyName("openHoursDetail")] string OpenHoursDetail,
        [property: JsonPropertyName("acceptedPaymentDetail")] string AcceptedPaymentDetail
    );

    public record City(
        [property: JsonPropertyName("name")] string Name
    );

    public record Classification(
        [property: JsonPropertyName("primary")] bool Primary,
        [property: JsonPropertyName("segment")] Segment Segment,
        [property: JsonPropertyName("genre")] Genre Genre,
        [property: JsonPropertyName("subGenre")] SubGenre SubGenre,
        [property: JsonPropertyName("type")] Type Type,
        [property: JsonPropertyName("subType")] SubType SubType,
        [property: JsonPropertyName("family")] bool Family
    );

    public record Country(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("countryCode")] string CountryCode
    );

    public record Dates(
        [property: JsonPropertyName("start")] Start Start,
        [property: JsonPropertyName("timezone")] string Timezone,
        [property: JsonPropertyName("status")] Status Status,
        [property: JsonPropertyName("spanMultipleDays")] bool SpanMultipleDays
    );

    public record Dma(
        [property: JsonPropertyName("id")] int Id
    );

    public record Embedded{
        [property: JsonPropertyName("events")] public List<DiscoveryEvent> Events { get; set; }
        [property: JsonPropertyName("venues")] public List<Venue>? Venues { get; set; }
        [property: JsonPropertyName("attractions")] public List<Attraction> Attractions { get; set; }
    }


public record DiscoveryEvent
{
    [property: JsonPropertyName("name")] public string Name { get; set; }
    [property: JsonPropertyName("type")] public string Type { get; set; }
    [property: JsonPropertyName("id")]  public string Id { get; set; }
    [property: JsonPropertyName("test")]  public bool Test { get; set; }
    [property: JsonPropertyName("url")] public string Url { get; set; }
    [property: JsonPropertyName("locale")] public string Locale { get; set; }
    [property: JsonPropertyName("images")] public List<Image> Images{ get; set; }
    [property: JsonPropertyName("sales")] public Sales Sales{ get; set; }
    [property: JsonPropertyName("dates")] public Dates Dates { get; set; }
    [property: JsonPropertyName("classifications")] public List<Classification> Classifications { get; set; }
    [property: JsonPropertyName("promoter")] public Promoter Promoter { get; set; }
    [property: JsonPropertyName("promoters")]  public List<Promoter> Promoters { get; set; } 
    [property: JsonPropertyName("info")] public string Info { get; set; }
    [property: JsonPropertyName("pleaseNote")] public string PleaseNote { get; set; }
    [property: JsonPropertyName("priceRanges")] public List<PriceRange> PriceRanges { get; set; }
    [property: JsonPropertyName("seatmap")] public Seatmap Seatmap { get; set; }
    [property: JsonPropertyName("accessibility")] public Accessibility Accessibility { get; set; }
    [property: JsonPropertyName("ticketLimit")] public TicketLimit TicketLimit { get; set; }
    [property: JsonPropertyName("ageRestrictions")] public AgeRestrictions AgeRestriction { get; set; }
    [property: JsonPropertyName("code")] public string Code { get; set; }
    [property: JsonPropertyName("_links")] public Links Links { get; set; }
    [property: JsonPropertyName("_embedded")] public Embedded Embedded { get; set; }
    [property: JsonPropertyName("products")] public List<Product> Products { get; set; }
    [property: JsonPropertyName("outlets")] public List<Outlet> Outlets { get; set; }
}


      

    public record ExternalLinks(
        [property: JsonPropertyName("twitter")] IReadOnlyList<Twitter> Twitter,
        [property: JsonPropertyName("facebook")] IReadOnlyList<Facebook> Facebook,
        [property: JsonPropertyName("wiki")] IReadOnlyList<Wiki> Wiki,
        [property: JsonPropertyName("instagram")] IReadOnlyList<Instagram> Instagram,
        [property: JsonPropertyName("homepage")] IReadOnlyList<Homepage> Homepage,
        [property: JsonPropertyName("youtube")] IReadOnlyList<Youtube> Youtube,
        [property: JsonPropertyName("lastfm")] IReadOnlyList<Lastfm> Lastfm,
        [property: JsonPropertyName("musicbrainz")] IReadOnlyList<Musicbrainz> Musicbrainz
    );

    public record Facebook(
        [property: JsonPropertyName("url")] string Url
    );

    public record First(
        [property: JsonPropertyName("href")] string Href
    );

    public record GeneralInfo(
        [property: JsonPropertyName("childRule")] string ChildRule,
        [property: JsonPropertyName("generalRule")] string GeneralRule
    );

    public record Genre(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name
    );

    public record Homepage(
        [property: JsonPropertyName("url")] string Url
    );

    public record Image(
        [property: JsonPropertyName("ratio")] string Ratio,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("width")] int Width,
        [property: JsonPropertyName("height")] int Height,
        [property: JsonPropertyName("fallback")] bool Fallback,
        [property: JsonPropertyName("attribution")] string Attribution
    );

    public record Instagram(
        [property: JsonPropertyName("url")] string Url
    );

    public record Last(
        [property: JsonPropertyName("href")] string Href
    );

    public record Lastfm(
        [property: JsonPropertyName("url")] string Url
    );

    public record Links(
        [property: JsonPropertyName("self")] Self Self,
        [property: JsonPropertyName("attractions")] IReadOnlyList<Attraction> Attractions,
        [property: JsonPropertyName("venues")] IReadOnlyList<Venue> Venues,
        [property: JsonPropertyName("first")] First First,
        [property: JsonPropertyName("next")] Next Next,
        [property: JsonPropertyName("last")] Last Last
    );

    public record Location(
        [property: JsonPropertyName("longitude")] string Longitude,
        [property: JsonPropertyName("latitude")] string Latitude
    );

    public record Market(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("id")] string Id
    );

    public record Musicbrainz(
        [property: JsonPropertyName("id")] string Id
    );

    public record Next(
        [property: JsonPropertyName("href")] string Href
    );

    public record Outlet(
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("type")] string Type
    );

    public record Page(
        [property: JsonPropertyName("size")] int Size,
        [property: JsonPropertyName("totalElements")] int TotalElements,
        [property: JsonPropertyName("totalPages")] int TotalPages,
        [property: JsonPropertyName("number")] int Number
    );

    public record Presale(
        [property: JsonPropertyName("startDateTime")] System.DateTime StartDateTime,
        [property: JsonPropertyName("endDateTime")] System.DateTime EndDateTime,
        [property: JsonPropertyName("name")] string Name
    );

    public record PriceRange(
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("currency")] string Currency,
        [property: JsonPropertyName("min")] double Min,
        [property: JsonPropertyName("max")] double Max
    );

    public record Product(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("url")] string Url,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("classifications")] IReadOnlyList<Classification> Classifications
    );

    public record Promoter(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string Description
    );

    public record Promoter2(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("description")] string Description
    );

    public record Public(
        [property: JsonPropertyName("startDateTime")] System.DateTime StartDateTime,
        [property: JsonPropertyName("startTBD")] bool StartTBD,
        [property: JsonPropertyName("startTBA")] bool StartTBA,
        [property: JsonPropertyName("endDateTime")] System.DateTime EndDateTime
    );

    public record DiscoveryEvents(
        [property: JsonPropertyName("_embedded")] Embedded Embedded,
        [property: JsonPropertyName("_links")] Links Links,
        [property: JsonPropertyName("page")] Page Page
    );

    public record Sales(
        [property: JsonPropertyName("public")] Public Public,
        [property: JsonPropertyName("presales")] IReadOnlyList<Presale> Presales
    );

    public record Seatmap(
        [property: JsonPropertyName("staticUrl")] string StaticUrl
    );

    public record Segment(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name
    );

    public record Self(
        [property: JsonPropertyName("href")] string Href
    );

    public record Social(
        [property: JsonPropertyName("twitter")] Twitter Twitter
    );

    public record Start(
        [property: JsonPropertyName("localDate")] string LocalDate,
        [property: JsonPropertyName("localTime")] string LocalTime,
        [property: JsonPropertyName("dateTime")] System.DateTime DateTime,
        [property: JsonPropertyName("dateTBD")] bool DateTBD,
        [property: JsonPropertyName("dateTBA")] bool DateTBA,
        [property: JsonPropertyName("timeTBA")] bool TimeTBA,
        [property: JsonPropertyName("noSpecificTime")] bool NoSpecificTime
    );

    public record State(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("stateCode")] string StateCode
    );

    public record Status(
        [property: JsonPropertyName("code")] string Code
    );

    public record SubGenre(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name
    );

    public record SubType(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name
    );

    public record TicketLimit(
        [property: JsonPropertyName("info")] string Info
    );

    public partial record Twitter(
        [property: JsonPropertyName("handle")] string Handle,
        [property: JsonPropertyName("url")] string Url
    );

    public record Type(
        [property: JsonPropertyName("id")] string Id,
        [property: JsonPropertyName("name")] string Name
    );

    public record UpcomingEvents(
        [property: JsonPropertyName("_total")] int Total,
        [property: JsonPropertyName("tmr")] int Tmr,
        [property: JsonPropertyName("ticketmaster")] int Ticketmaster,
        [property: JsonPropertyName("_filtered")] int Filtered
    );

    public record Wiki(
        [property: JsonPropertyName("url")] string Url
    );

    public record Youtube(
        [property: JsonPropertyName("url")] string Url
    );

