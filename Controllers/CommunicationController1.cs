using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Models;


namespace TheatreBookingSystem_MVC.Controllers
{
    public class CommunicationController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public CommunicationController(ApplicationDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]
        public IActionResult SendMessage(string userName, string userMessage)
        {
            // Pobierz aktualnego użytkownika
            var currentUser = _userManager.GetUserAsync(User).Result;

            // Ustaw nową wiadomość
            currentUser.Message = userMessage;

            // Zapisz zmiany w bazie danych
            _context.SaveChanges();

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View("Confirmation/Index");
        }
    }


    }
