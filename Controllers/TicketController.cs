// TicketController.cs

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TheatreBookingSystem_MVC.Data.Enum;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC
{
    public class TicketController : Controller
    {
        // Założmy, że to jest przykładowa lista dostępnych biletów
        private List<Ticket> availableTickets = new List<Ticket>
    {
        new Ticket
        {
            Id = 1,
            Row = 1,
            Seat = 1,
            TicketType = TicketType.Normal,
            EventId = 1, // Id wydarzenia
            AppUserId = null, // Brak przypisanego użytkownika
            IsPurchased = false,
            PurchaseTime = DateTime.MinValue,
            IsReturned = false,
            ReturnTime = DateTime.MinValue
        },
    };
        public IActionResult Ticket()
        {
            Ticket initialTicket = availableTickets.FirstOrDefault();

            // Pass the initial ticket as the model to the view
            return View("Purchase", initialTicket);
        }

        [HttpPost]
        public IActionResult Purchase(int id)
        {
            // Pobierz bilet o podanym ID
            Ticket selectedTicket = availableTickets.FirstOrDefault(t => t.Id == id);

            if (selectedTicket != null && selectedTicket.CanBePurchased())
            {
                selectedTicket.IsPurchased = true;
                selectedTicket.PurchaseTime = DateTime.Now;

                // selectedTicket.AppUserId = userId;

                return RedirectToAction("PurchaseConfirmation", new { ticketId = selectedTicket.Id });
            }
            else
            {
                return RedirectToAction("PurchaseError");
            }
        }

        // Akcja potwierdzenia zakupu
        public IActionResult PurchaseConfirmation(int ticketId)
        {
            Ticket purchasedTicket = availableTickets.FirstOrDefault(t => t.Id == ticketId);
            return View(purchasedTicket);
        }

        // Akcja błędu zakupu
        public IActionResult PurchaseError()
        {
            return View();
        }
    }
}
