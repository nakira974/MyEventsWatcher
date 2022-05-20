using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MyEventsWatcher.Shared.Models.Orion;

// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
// Root myDeserializedClass = JsonSerializer.Deserialize<Root>(myJsonResponse);
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

/// <summary>
/// Modèle des évènements au sein de Orion.
/// </summary>
    public record Event
    {
        public Event()
        {
            
        }
        
        public Event(DiscoveryEvent? currentEvent)
        {
            try
            {
                  Name = new Name()
            {
                Value = currentEvent?.Name ?? string.Empty
            };

            EventIdentifier = new EventId()
            {
                Value = currentEvent?.Id ?? string.Empty
            };

            Info = new Info()
            {
                Value = currentEvent?.Info ?? string.Empty 
            };

            Test = new Test()
            {
                Value = currentEvent?.Test ?? false
            };

            Url = new Url()
            {
                Value = currentEvent?.Url ?? string.Empty
            };

            Locale = new Locale()
            {
                Value = currentEvent?.Locale ?? string.Empty
            };

            Sales = new Sales()
            {
                EventValue = new EventValue()
                {
                    Public = new Public()
                    {
                        EndDateTime = new EndDateTime()
                        {
                            Value = currentEvent?.Sales.Public.EndDateTime ?? System.DateTime.Now
                        },
                        StartDateTime = new StartDateTime()
                        {
                            Value = currentEvent?.Sales.Public.StartDateTime ?? System.DateTime.Now
                        },
                        StartTBA = new StartTBA()
                        {
                            Value = currentEvent?.Sales.Public.StartTBA ?? false
                        },
                        StartTBD = new StartTBD()
                        {
                            Value = currentEvent?.Sales.Public.StartTBD ?? false
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
                            Value = currentEvent?.Dates.Start.DateTime ?? System.DateTime.Now
                        },
                        NoSpecificTime = new NoSpecificTime()
                        {
                            Value = currentEvent?.Dates.Start.NoSpecificTime ?? false
                        },
                        DateTBA = new DateTBA()
                        {
                            Value = currentEvent?.Dates.Start.DateTBA ?? false
                        },
                        DateTBD = new DateTBD()
                        {
                            Value = currentEvent?.Dates.Start.DateTBD ?? false
                        },
                        TimeTBA = new TimeTBA()
                        {
                            Value = currentEvent?.Dates.Start.TimeTBA ?? false
                        }
                    }
                }
            };

            if (currentEvent is null) return;
            Classifications = new EventClassifications()
            {
                Classifications = new List<EventClassification>(currentEvent.Classifications.Count)
            };

            Venues = new EventVenues()
            {
                Value = new List<VenueValue>()
            };

            foreach (var classification in currentEvent.Classifications.Select(currentEventClassification => new EventClassification()
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
                     }))
            {
                Classifications.Classifications.Add(classification);
            }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }
        
        [JsonPropertyName("id")]
        public string EventId => $"urn:ngsi-ld:Event:{EventIdentifier.Value}";

        [JsonPropertyName("type")]
        public string Type => "Event";

        [JsonPropertyName("name")]
        public Name? Name { get; set; }

        [JsonPropertyName("event_code")]
        public EventId? EventIdentifier { get; set; }

        [JsonPropertyName("info")]
        public Info? Info { get; set; }

        [JsonPropertyName("test")]
        public Test? Test { get; set; }

        [JsonPropertyName("url")]
        public Url? Url { get; set; }

        [JsonPropertyName("locale")]
        public Locale? Locale { get; set; }

        [JsonPropertyName("sales")]
        public Sales? Sales { get; set; }

        [JsonPropertyName("dates")]
        public Dates? Dates { get; set; }
        
        [JsonPropertyName("classfications")]
        public EventClassifications? Classifications { get; set; }
        
        [JsonPropertyName("venues")]
        public EventVenues? Venues { get; set; }
    }