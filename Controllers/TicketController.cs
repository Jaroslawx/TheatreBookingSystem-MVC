using Microsoft.AspNetCore.Mvc;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
