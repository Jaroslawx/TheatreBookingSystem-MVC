
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

            if (initialTicket != null)
            {
                // Pass the initial ticket as the model to the view
                return View("Purchase", initialTicket);
            }
            else
            {
                ViewBag.ErrorMessage = "Brak dostępnych biletów do zakupu.";
                return RedirectToAction("PurchaseError");
            }
        }

        [HttpPost]
        public IActionResult Purchase(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                // Perform validation and processing as needed

                // For example, update the selected ticket with the provided information
                Ticket selectedTicket = availableTickets.FirstOrDefault(t => t.Id == ticket.Id);

                if (selectedTicket != null)// && selectedTicket.CanBePurchased())
                {
                    selectedTicket.IsPurchased = true;
                    selectedTicket.PurchaseTime = DateTime.Now;
                    selectedTicket.TicketType = ticket.TicketType; // Update ticket type

                    // selectedTicket.AppUserId = userId;

                    return RedirectToAction("PurchaseConfirmation", new { ticketId = selectedTicket.Id });
                }
            }

            // If validation fails or other errors occur, return to the purchase page with the existing model
            return View("Purchase", ticket);
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
