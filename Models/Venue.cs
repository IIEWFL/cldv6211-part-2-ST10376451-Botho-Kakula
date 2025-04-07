
public class Venue
{
    public int VenueId { get; set; }
    public required string VenueName { get; set; }
    public required string Location { get; set; }
    public int Capacity { get; set; }
    public required string ImageUrl { get; set; }

    public ICollection<Event> Events { get; set; }
}
