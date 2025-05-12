using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EventEase.Models; 

namespace EventEase.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime EventDate { get; set; }

        public string Description { get; set; }

        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public int EventOrganizerId { get; set; }
        public EventOrganizer EventOrganizer { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
