using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using EventEase.Data;

public class BookingsController : Controller
{
    private readonly AppDbContext _context;

    public BookingsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index() => View(await _context.Bookings.Include(b => b.Event).Include(b => b.Venue).ToListAsync());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Booking booking)
    {
        if (ModelState.IsValid)
        {
            _context.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(booking);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        return booking == null ? NotFound() : View(booking);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Booking booking)
    {
        if (ModelState.IsValid)
        {
            _context.Update(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(booking);
    }

    public async Task<IActionResult> Details(int id)
    {
        var booking = await _context.Bookings.Include(b => b.Event).Include(b => b.Venue).FirstOrDefaultAsync(b => b.BookingId == id);
        return booking == null ? NotFound() : View(booking);
    }
}