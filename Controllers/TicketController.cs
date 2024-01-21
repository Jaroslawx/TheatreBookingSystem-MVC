using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Data.Enum;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;

public class TicketController : Controller
{
    private readonly ApplicationDbContext _context;

    public TicketController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index(TicketViewModel model)
    {
        var viewModel = new TicketViewModel
        {
            EventId = model.EventId,
            EventName = model.EventName, // Set the actual event name or retrieve it from the database
                                                   // Populate other properties as needed
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult BuyTicket(TicketViewModel model)

    {
        // Check if the selected seat in the row is already occupied
        bool isSeatOccupied = _context.Tickets
           .Any(t => t.EventId == model.EventId && t.Row == model.SelectedRow && t.Seat == model.SelectedSeat);

        if (isSeatOccupied)
        {
            // Display an alert using TempData for the use
            TempData["Error"] = "The selected seat is already occupied. Please choose another seat.";

            // Redirect back to the Index view with the original model
            return RedirectToAction("Index", model);
        }
        else
        {

            // Create a new Ticket object and set its properties from the model
            Ticket newTicket = new Ticket
            {
                EventId = model.EventId,
                Row = model.SelectedRow,
                Seat = model.SelectedSeat,
                TicketType = model.SelectedTicketType,
                PurchaserEmail = model.PurchaserEmail,
                PurchaserName = model.PurchaserName,
                // Set other properties as needed
            };

            _context.Tickets.Add(newTicket);
            _context.SaveChanges();

            return View(model);
        }
    }

    public IActionResult ReturnIndex(ReturnTicketViewModel model)
    {
        var viewModel = new TicketViewModel
        {
            EventId = model.EventId,
            EventName = model.EventName,
                                         
        };
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult Return(ReturnTicketViewModel model)
    {
        // Find the ticket in the database based on the provided details
        var existingTicket = _context.Tickets
            .FirstOrDefault(t => t.Row == model.SelectedRow &&
                                  t.Seat == model.SelectedSeat &&
                                  t.PurchaserEmail == model.PurchaserEmail &&
                                  t.PurchaserName == model.PurchaserName &&
                                  t.TicketType == model.SelectedTicketType);

        if (existingTicket != null)
        {
            // Remove the ticket from the database
            _context.Tickets.Remove(existingTicket);
            _context.SaveChanges();

            // Redirect to a suitable page (e.g., the ticket return confirmation page)
            return View(model);
        }
        else
        {
            TempData["Error"] = "Ticket not found. Please check the details and try again.";
            return RedirectToAction("ReturnIndex", model);
        }

    }
}