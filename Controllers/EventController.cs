using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Event> events = _context.Events.ToList();
            return View(events);
        }

        // TODO: have to fix
        public IActionResult Detail(int id)
        {
            var @event = _context.Events.Include(r => r.Room).FirstOrDefault(e => e.Id == id);
            return View(@event);
        }
    }
}
