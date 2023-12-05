using Microsoft.AspNetCore.Mvc;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
