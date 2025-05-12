using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using EventEase.Data;
using EventEase.Models;

// Controllers/BookingsController.cs
public class BookingsController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Bookings/Create
    public IActionResult Create()
    {
        ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName");
        ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueName");
        return View();
    }

    // POST: Bookings/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("BookingId,BookingDate,EventId,VenueId")] Booking booking)
    {
        var exists = await _context.Bookings.AnyAsync(b =>
            b.BookingDate == booking.BookingDate &&
            b.VenueId == booking.VenueId
        );

        if (exists)
        {
            ModelState.AddModelError("", "This venue is already booked for the selected date.");
        }

        if (ModelState.IsValid)
        {
            _context.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewData["EventId"] = new SelectList(_context.Events, "EventId", "EventName", booking.EventId);
        ViewData["VenueId"] = new SelectList(_context.Venues, "VenueId", "VenueName", booking.VenueId);
        return View(booking);
    }

}
