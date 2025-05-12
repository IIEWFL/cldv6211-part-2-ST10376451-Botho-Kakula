
// Models/Venue.cs
using System.ComponentModel.DataAnnotations;
using EventEase.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Models
{
    public class Venue
   {
     public int VenueId { get; set; }

     [Required]
     public string VenueName { get; set; }

     [Required]
     public string Location { get; set; }

     public int Capacity { get; set; }

     public string ImageUrl { get; set; }

     public ICollection<Event> Events { get; set; } = new List<Event>();
     public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}

}
