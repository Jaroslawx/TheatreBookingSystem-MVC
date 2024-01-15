
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Data.Enum;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Action to display available tickets for an event
        public IActionResult BuyTicket(int eventId)
        {
            var @event = _context.Events
                .Include(e => e.Room)
                .SingleOrDefault(e => e.Id == eventId);

            if (@event == null)
            {
                return NotFound(); // Event not found
            }

            var availableSeats = GetAvailableSeats(@event);

            // Przekazanie danych do widoku
            ViewBag.EventId = @event.Id;
            ViewBag.AvailableSeats = Enumerable.Range(1, availableSeats).ToList();
            ViewBag.TicketTypes = Enum.GetValues(typeof(TicketType)).Cast<TicketType>().ToList();

            return View();
        }

        // Action to process ticket purchase
        [HttpPost]
        public IActionResult BuyTicket(int eventId, int selectedSeat, TicketType selectedTicketType)
        {
            var @event = _context.Events
                .Include(e => e.Room)
                .SingleOrDefault(e => e.Id == eventId);

            if (@event == null)
            {
                return NotFound(); // Event not found
            }

            var availableSeats = GetAvailableSeats(@event);

            if (selectedSeat < 1 || selectedSeat > availableSeats)
            {
                ModelState.AddModelError("selectedSeat", "Invalid seat selection");
            }

            if (!Enum.IsDefined(typeof(TicketType), selectedTicketType))
            {
                ModelState.AddModelError("selectedTicketType", "Invalid ticket type");
            }

            if (!ModelState.IsValid)
            {
                // Przekazanie danych do widoku w przypadku błędów
                ViewBag.EventId = @event.Id;
                ViewBag.AvailableSeats = Enumerable.Range(1, availableSeats).ToList();
                ViewBag.TicketTypes = Enum.GetValues(typeof(TicketType)).Cast<TicketType>().ToList();

                return View();
            }

            // Kody logiczne dotyczące zakupu biletu, można użyć wcześniejszego kodu

            return RedirectToAction("Confirmation"); // Przekierowanie do strony potwierdzenia zakupu
        }


        private int GetAvailableSeats(Event @event)
        {
            var reservedSeats = _context.Tickets
                .Where(t => t.EventId == @event.Id && !t.IsReturned && !t.IsPurchased)
                .Sum(t => t.Seat.HasValue ? 1 : 0);

            return @event.Room.Seats - reservedSeats;
        }

        private void ReserveSeats(Room room, int requestedSeats)
        {
            // Implement logic to mark seats as reserved in the database
            // You may need to track reserved seats in a separate table or update the Room entity
            // This example assumes you have a SeatsReserved property in the Room entity
            room.SeatsReserved += requestedSeats;
            _context.SaveChanges();
        }


    }
}

