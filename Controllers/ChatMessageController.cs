using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.Data;
using System;
using System.Linq;
namespace TheatreBookingSystem_MVC.Controllers
{
    [Authorize(Roles = UserRoles.User + "," + UserRoles.Admin)]
    public class ChatController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ChatController(UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        // User's chat view
        public IActionResult Index()
        {
            return View();
        }

        // Admin's chat view
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult AdminIndex()
        {
            var users = _userManager.GetUsersInRoleAsync(UserRoles.User).Result;
            return View(users);
        }

        // Get messages for a specific user
        [Authorize(Roles = UserRoles.Admin)]
        public IActionResult GetUserMessages(string userId)
        {
            var messages = _context.ChatMessages
                .Where(m => m.AppUserId == userId)
                .OrderBy(m => m.Timestamp)
                .ToList();

            return View(messages);
        }

        // Send message
        [HttpPost]
        public IActionResult SendMessage(string message)
        {
            var userId = _userManager.GetUserId(User);
            var newMessage = new ChatMessage
            {
                Title = "User",
                Message = message,
                AppUserId = userId,
                Timestamp = DateTime.Now
            };

            _context.ChatMessages.Add(newMessage);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // Reply to message
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public IActionResult ReplyToMessage(int messageId, string replyMessage)
        {
            var adminId = _userManager.GetUserId(User);
            var originalMessage = _context.ChatMessages.Find(messageId);

            var reply = new ChatMessage
            {
                Title = "Admin",
                Message = replyMessage,
                AppUserId = adminId,
                Timestamp = DateTime.Now
            };

            originalMessage.Replies.Add(reply);
            _context.SaveChanges();

            return RedirectToAction("AdminIndex");
        }
    }
}