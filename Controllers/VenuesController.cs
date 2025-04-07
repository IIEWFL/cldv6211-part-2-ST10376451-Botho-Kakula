using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using EventEase.Data;

public class VenuesController : Controller
{
    private readonly AppDbContext _context;

    public VenuesController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index() => View(await _context.Venues.ToListAsync());

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(Venue venue)
    {
        if (ModelState.IsValid)
        {
            _context.Add(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(venue);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var venue = await _context.Venues.FindAsync(id);
        return venue == null ? NotFound() : View(venue);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Venue venue)
    {
        if (ModelState.IsValid)
        {
            _context.Update(venue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(venue);
    }

    public async Task<IActionResult> Details(int id)
    {
        var venue = await _context.Venues.FindAsync(id);
        return venue == null ? NotFound() : View(venue);
    }
}