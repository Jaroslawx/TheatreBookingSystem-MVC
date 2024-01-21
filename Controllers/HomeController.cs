using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
//using System.Globalization;
//using System.Net;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly UserManager<AppUser> _userManager;
        //private readonly SignInManager<AppUser> _signInManager;
        //private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_userManager = userManager;
            //_signInManager = signInManager;
            //_config = config;
        }

        public IActionResult Index()
        {
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
}