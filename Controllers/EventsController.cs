using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using EventEase.Data;

public class EventsController : Controller
{
    private readonly AppDbContext _context;

    public EventsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index() => View(await _context.Events.Include(e => e.Venue).ToListAsync());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Event @event)
    {
        if (ModelState.IsValid)
        {
            _context.Add(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(@event);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var @event = await _context.Events.FindAsync(id);
        return @event == null ? NotFound() : View(@event);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Event @event)
    {
        if (ModelState.IsValid)
        {
            _context.Update(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(@event);
    }

    public async Task<IActionResult> Details(int id)
    {
        var @event = await _context.Events.Include(e => e.Venue).FirstOrDefaultAsync(e => e.EventId == id);
        return @event == null ? NotFound() : View(@event);
    }
}