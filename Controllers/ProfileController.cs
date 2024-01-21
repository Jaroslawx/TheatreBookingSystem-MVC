using Microsoft.AspNetCore.Mvc;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
