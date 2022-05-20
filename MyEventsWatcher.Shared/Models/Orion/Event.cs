using System.Globalization;
using System.Text.Json.Serialization;
using MyNamespace;

namespace MyEventsWatcher.Shared.Models.Orion;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public record Code
    {
        [JsonPropertyName("type")]
        public string Type  {get => "Text";}

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public record Dates
    {
        [JsonPropertyName("value")] 
        public EventValue EventValue { get; set; }
    }

    public record DateTBA
    {
        [JsonPropertyName("type")]
        public string Type {get => "boolean";}

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record DateTBD
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record DateTime
    {
        [JsonPropertyName("type")]
        public  string Type {get => "DateTime";}

        [JsonPropertyName("value")]
        public System.DateTime Value { get; set; }
    }

    public record EndDateTime
    {
        [JsonPropertyName("type")]
        public  string Type {get => "DateTime";}

        [JsonPropertyName("value")]
        public System.DateTime Value { get; set; }
    }

 

    public record Info
    {
        [JsonPropertyName("type")]
        public  string Type {get => "Text";}

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public record Locale
    {
        [JsonPropertyName("type")]
        public  string Type {get => "Text";}

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public record Name
    {
        [JsonPropertyName("type")]
        public  string Type {get => "Text";}

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

    public record NoSpecificTime
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record Public
    {
        [JsonPropertyName("startDateTime")]
        public StartDateTime StartDateTime { get; set; }

        [JsonPropertyName("startTBD")]
        public StartTBD StartTBD { get; set; }

        [JsonPropertyName("startTBA")]
        public StartTBA StartTBA { get; set; }

        [JsonPropertyName("endDateTime")]
        public EndDateTime EndDateTime { get; set; }
    }

    public record Event
    {
        public Event()
        {
            
        }
        
        public Event(DiscoveryEvent? currentEvent, IEnumerable<Venue>? venues)
        {
            try
            {
                  Name = new Name()
            {
                Value = currentEvent.Name
            };

            Id = new EventId()
            {
                Value = currentEvent.Id
            };

            Info = new Info()
            {
                Value = currentEvent.Info
            };

            Test = new Test()
            {
                Value = currentEvent.Test
            };

            Url = new Url()
            {
                Value = currentEvent.Url
            };

            Locale = new Locale()
            {
                Value = currentEvent.Locale
            };

            Sales = new Sales()
            {
                EventValue = new EventValue()
                {
                    Public = new Public()
                    {
                        EndDateTime = new EndDateTime()
                        {
                            Value = currentEvent.Sales.Public.EndDateTime
                        },
                        StartDateTime = new StartDateTime()
                        {
                            Value = currentEvent.Sales.Public.StartDateTime
                        },
                        StartTBA = new StartTBA()
                        {
                            Value = currentEvent.Sales.Public.StartTBA
                        },
                        StartTBD = new StartTBD()
                        {
                            Value = currentEvent.Sales.Public.StartTBD
                        }
                        
                    }
                }
            };

            Dates = new Dates()
            {
                EventValue = new EventValue()
                {
                    Start = new Start()
                    {
                        DateTime = new DateTime()
                        {
                            Value = currentEvent.Dates.Start.DateTime
                        },
                        NoSpecificTime = new NoSpecificTime()
                        {
                            Value = currentEvent.Dates.Start.NoSpecificTime
                        },
                        DateTBA = new DateTBA()
                        {
                            Value = currentEvent.Dates.Start.DateTBA
                        },
                        DateTBD = new DateTBD()
                        {
                            Value = currentEvent.Dates.Start.DateTBD
                        },
                        TimeTBA = new TimeTBA()
                        {
                            Value = currentEvent.Dates.Start.TimeTBA
                        }
                    }
                }
            };

            Classifications = new EventClassifications()
            {
                Classifications = new List<EventClassification>(currentEvent.Classifications.Count)
            };
            
            Venues = new EventVenues()
            {
                Value = new List<VenueValue>()
            };
            
            foreach (var currentEventClassification in currentEvent.Classifications)
            {
                var classification = new EventClassification()
                {
                    Details = new EventClassification.Value()
                    {
                        Type = new EventClassification.Value.EventType()
                        {
                            Value = currentEventClassification?.Type?.Name ?? string.Empty
                        },
                        EventGenre = new EventClassification.Value.Genre()
                        {
                            Value = currentEventClassification?.Genre?.Name ?? string.Empty
                        },
                        EventSegment = new EventClassification.Value.Segment()
                        {
                            Value = currentEventClassification?.Segment?.Name ?? string.Empty
                        }
                    }
                };
                Classifications.Classifications.Add(classification);
            }
            
            foreach (var venue in venues)
            {
                var value = new VenueValue()
                {
                    Aliases = new Aliases()
                    {
                        AlliasesValue = venue?.Aliases ?? new List<string>()
                    },
                    City = new EventCity()
                    {
                        Value = venue?.City?.Name ?? string.Empty
                    },
                    Country = new EventCountry()
                    {
                        Value = venue?.Country?.Name ?? string.Empty
                    },
                    Location = new VenueLocation()
                    {
                        Value = new EventCoordinates()
                        {
                            Coordinates = new List<float>(2)
                            {
                                float.Parse(venue?.Location?.Latitude ?? "0.0", CultureInfo.InvariantCulture),
                                float.Parse(venue?.Location?.Longitude ?? "0.0", CultureInfo.InvariantCulture)
                            }
                        }
                    },
                    Name = new VenueName()
                    {
                        Value = venue?.Name ?? string.Empty 
                    },
                    Url = new VenueUrl()
                    { 
                        Value = venue?.Url ?? string.Empty
                    },
                    Address = new EventAddress()
                    {
                        Value = venue?.Address?.Line1 ?? string.Empty
                    },
                    Twitter = new EventTwitter()
                    {
                        Value = venue?.Social?.Twitter?.Handle ?? string.Empty
                    },
                    ChildrenRule = new ChildrenRule()
                    {
                        Value = venue?.GeneralInfo?.ChildRule ?? string.Empty
                    },
                    GeneralRule = new GeneralRule()
                    {
                        Value = venue?.GeneralInfo?.GeneralRule ?? string.Empty
                    },
                    ParkingDetail = new EventParkingDetail()
                    {
                        Value = venue?.ParkingDetail ?? string.Empty
                    }
                };
                Venues.Value.Add(value); 
            }
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
        
        [JsonPropertyName("id")]
        public string EventId {get => $"urn:ngsi-ld:Event:{Id.Value}";}

        [JsonPropertyName("type")]
        public string Type {get => "Event";}

        [JsonPropertyName("name")]
        public Name Name { get; set; }

        [JsonPropertyName("event_code")]
        public EventId Id { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }

        [JsonPropertyName("test")]
        public Test Test { get; set; }

        [JsonPropertyName("url")]
        public Url Url { get; set; }

        [JsonPropertyName("locale")]
        public Locale Locale { get; set; }

        [JsonPropertyName("sales")]
        public Sales Sales { get; set; }

        [JsonPropertyName("dates")]
        public Dates Dates { get; set; }
        
        [JsonPropertyName("classfications")]
        public EventClassifications Classifications { get; set; }
        
        [JsonPropertyName("venues")]
        public EventVenues Venues { get; set; }
    }

public record EventClassifications
{
    [JsonPropertyName("value")]
    public List<EventClassification> Classifications { get; set; }
}
    public record Sales
    {
        [JsonPropertyName("value")]
        public EventValue EventValue { get; set; }
    }

    public record SpanMultipleDays
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

public record EventClassification
{
    [JsonPropertyName("value")]
    public Value Details { get; set; }

    public record Value
    {
        public record Genre
        {
            [JsonPropertyName("type")]
            public string Type {get=> "Text";}
            
            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
        
        public record Segment
        {
            [JsonPropertyName("type")]
            public string Type {get=> "Text";}
            
            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
        
        public record EventType
        {
            [JsonPropertyName("type")]
            public string Type {get=> "Text";}
            
            [JsonPropertyName("value")]
            public string Value { get; set; }
        }
        
        [JsonPropertyName("genre")]
        public Genre? EventGenre { get; set; }
        
        [JsonPropertyName("segment")]
        public Segment? EventSegment { get; set; }
        
        [JsonPropertyName("type")]
        public EventType? Type { get; set; }
        
    }
}

    public record Start
    {
        [JsonPropertyName("dateTime")]
        public DateTime DateTime { get; set; }

        [JsonPropertyName("dateTBD")]
        public DateTBD DateTBD { get; set; }

        [JsonPropertyName("dateTBA")]
        public DateTBA DateTBA { get; set; }

        [JsonPropertyName("timeTBA")]
        public TimeTBA TimeTBA { get; set; }

        [JsonPropertyName("noSpecificTime")]
        public NoSpecificTime NoSpecificTime { get; set; }
    }

    public record StartDateTime
    {
        [JsonPropertyName("type")]
        public  string Type {get => "DateTime";}

        [JsonPropertyName("value")]
        public System.DateTime Value { get; set; }
    }

    public record StartTBA
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record StartTBD
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}
        
        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record Status
    {
        [JsonPropertyName("code")]
        public Code Code { get; set; }
    }

    public record Test
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}
        
        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record TimeTBA
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record Timezone
    {
        [JsonPropertyName("type")]
        public  string Type {get => "boolean";}

        [JsonPropertyName("value")]
        public bool Value { get; set; }
    }

    public record Url
    {
        [JsonPropertyName("type")]
        public  string Type {get => "Text";}

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }

public record EventId
{
    [JsonPropertyName("type")]
    public string Type {get => "Text";}
    
    [JsonPropertyName("value")]
    public string Value { get; set; }
}

public class EventValue
{
    [JsonPropertyName("public")]
    public Public Public { get; set; }

    [JsonPropertyName("startDateTime")]
    public StartDateTime StartDateTime { get; set; }

    [JsonPropertyName("startTBD")]
    public StartTBD StartTBD { get; set; }

    [JsonPropertyName("startTBA")]
    public StartTBA StartTBA { get; set; }

    [JsonPropertyName("endDateTime")]
    public EndDateTime EndDateTime { get; set; }

    [JsonPropertyName("start")]
    public Start Start { get; set; }

    [JsonPropertyName("dateTime")]
    public DateTime DateTime { get; set; }

    [JsonPropertyName("dateTBD")]
    public DateTBD DateTBD { get; set; }

    [JsonPropertyName("dateTBA")]
    public DateTBA DateTBA { get; set; }

    [JsonPropertyName("timeTBA")]
    public TimeTBA TimeTBA { get; set; }

    [JsonPropertyName("noSpecificTime")]
    public NoSpecificTime NoSpecificTime { get; set; }
}




