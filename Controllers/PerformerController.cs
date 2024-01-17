using Microsoft.AspNetCore.Mvc;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class PerformerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
