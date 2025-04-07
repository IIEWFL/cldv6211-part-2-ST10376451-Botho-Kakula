public class Event
{
    public int EventId { get; set; }   
    public required string EventName { get; set; }
    public required string Description { get; set; }
    public required string Venue { get; set; } 
    public DateTime Date { get; set; } 

    // Relationship with EventOrganizer (if exists)
    public int EventOrganizerId { get; set; }
    public required EventOrganizer EventOrganizer { get; set; } // Navigation property to the EventOrganizer

    // Possible relationship to bookings (one-to-many relationship)
    public ICollection<Booking> Bookings { get; set; }

    // You can also include other properties as per your project requirements
}
