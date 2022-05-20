namespace MyEventsWatcher.Shared.Models.Orion;

public record User
{
    public UserName? Username { get; set; }

    public Password? Password { get; set; }

    public Location? Location { get; set; }

}