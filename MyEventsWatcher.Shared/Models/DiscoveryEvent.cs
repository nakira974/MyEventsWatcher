using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);

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