using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EventEase.Models;
using EventEase.Data;

namespace EventEase.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.VenueCount = _context.Venues.Count();
        ViewBag.EventCount = _context.Events.Count(e => e.Date >= DateTime.Today);
        ViewBag.BookingCount = _context.Bookings.Count(b => b.BookingDate >= DateTime.Today.AddDays(-7));
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}