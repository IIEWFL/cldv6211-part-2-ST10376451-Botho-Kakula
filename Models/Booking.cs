// Models/Booking.cs
using System.ComponentModel.DataAnnotations;
using EventEase.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Models
{
public class Booking
{
    public int BookingId { get; set; }
    public DateTime BookingDate { get; set; }

    [Required]
    public int EventId { get; set; }
    public Event Event { get; set; }

    [Required]
    public int VenueId { get; set; }  
    public Venue Venue { get; set; }
}
}
