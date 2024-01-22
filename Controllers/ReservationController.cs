using Microsoft.AspNetCore.Mvc;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ReservationController(ApplicationDbContext context)
        {
            
            _context = context;
        }
        public IActionResult Index()
        {
            List<Reservation> reservations = _context.Reservations.ToList();
            return View();
        }
    }
}
