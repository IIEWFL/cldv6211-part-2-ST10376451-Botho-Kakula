using System.ComponentModel.DataAnnotations;
using EventEase.Models; 

namespace EventEase.Models
{
    public class EventOrganizer
    {
        public int EventOrganizerId { get; set; }

        [Required]
        public string Name { get; set; }

        public string ContactDetails { get; set; }

        public string Email { get; set; }

        public ICollection<Event> Events { get; set; }
        
        // You can add more fields related to the event organizer here, like:
        // public string OrganizationName { get; set; }
        // public string PhoneNumber { get; set; }
    }
}
