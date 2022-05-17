using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MyEventsWatcher.Services;

namespace MyEventsWatcher.Shared.Models;

public record UserName : OrionEntityAttribute<UserName>{}
public record Password : OrionEntityAttribute<Password> {}

public record UserSubscription
{
    public UserSubscription()
    {
        
    }
    
    public UserSubscription(UserName? userName, Password? password, IEnumerable<string>? subscriptions)
    {
        UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        Subscriptions = subscriptions ?? throw new ArgumentNullException(nameof(subscriptions));
    }

    [JsonPropertyName("username")]
    [Required]
    public UserName? UserName { get; set; }

    [JsonPropertyName("user_subscriptions")]
    [Required]
    public IEnumerable<string>? Subscriptions { get; set; }
 };