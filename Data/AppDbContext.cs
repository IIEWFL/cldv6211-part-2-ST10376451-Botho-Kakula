using Microsoft.EntityFrameworkCore;
using EventEase.Models; // Ensure this is at the top to reference your models

namespace EventEase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<EventOrganizer> EventOrganizers { get; set; } // Add this line if missing

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Booking to Venue relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany(v => v.Bookings)
                .HasForeignKey(b => b.VenueId)
                .OnDelete(DeleteBehavior.Cascade); // Delete behavior

            // Booking to Event relationship
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Cascade); // Delete behavior

            // Event to EventOrganizer relationship
            modelBuilder.Entity<Event>()
                .HasOne(e => e.EventOrganizer)
                .WithMany(o => o.Events)
                .HasForeignKey(e => e.EventOrganizerId)
                .OnDelete(DeleteBehavior.SetNull); // Optional: change delete behavior here
        }
    }
}
