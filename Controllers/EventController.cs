using Microsoft.AspNetCore.Mvc;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
