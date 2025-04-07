using Microsoft.EntityFrameworkCore;
using EventEase.Models;

namespace EventEase.Data{
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Venue> Venues { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<EventOrganizer> EventOrganizers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Venue)
            .WithMany()
            .HasForeignKey(b => b.VenueId);

        modelBuilder.Entity<Booking>()
            .HasOne(b => b.Event)
            .WithMany(e => e.Bookings)
            .HasForeignKey(b => b.EventId);

        modelBuilder.Entity<Event>()
            .HasOne(e => e.EventOrganizer)
            .WithMany(o => o.Events)
            .HasForeignKey(e => e.EventOrganizerId);
    }
}
}
