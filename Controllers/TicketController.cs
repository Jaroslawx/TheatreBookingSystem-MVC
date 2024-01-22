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

    /*public IActionResult Index(TicketViewModel model)
    {
        var viewModel = new TicketViewModel
        {
            EventId = model.EventId,
            EventName = model.EventName,
                                                   
        };
        return View(viewModel);
    }*/

    public IActionResult Index(int? id)
    {
        if (id == null)
        {
            // Handle the case where EventId is not provided
            // You can redirect or show an error message
            return RedirectToAction("Index", "Home");
        }

        // Retrieve the event details based on the provided EventId
        var eventDetails = _context.Events.Find(id);

        if (eventDetails == null)
        {
            // Handle the case where the event is not found
            // You can redirect or show an error message
            return RedirectToAction("Index", "Home");
        }

        var viewModel = new TicketViewModel
        {
            EventId = eventDetails.Id,
            EventName = eventDetails.Name,
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
                IsPurchased = true,

            };

            _context.Tickets.Add(newTicket);
            _context.SaveChanges();

            // Retrieve event details to pass to the view
            var eventDetails = _context.Events.Find(model.EventId);

            // Pass EventName and other properties to the BuyTicket view
            var viewModel = new TicketViewModel
            {
                EventId = eventDetails.Id,
                EventName = eventDetails.Name,
            };

            return View(model);
        }
    }

    public IActionResult ReturnIndex(ReturnTicketViewModel model)
    {
        var viewModel = new ReturnTicketViewModel
        {
            EventId = model.EventId,
            EventName = model.EventName,

                                         
        };
        return View(viewModel);
    }
    [HttpPost]
    public IActionResult Return(ReturnTicketViewModel model, string transactionType)
    {
        // Find the ticket in the database based on the provided details
        var existingTicket = _context.Tickets
            .FirstOrDefault(t =>
                                 t.Row == model.SelectedRow &&
                                 t.Seat == model.SelectedSeat &&
                                 t.PurchaserEmail == model.PurchaserEmail &&
                                 t.PurchaserName == model.PurchaserName);

        if (existingTicket != null)
        {
            // Update the ticket's IsReturned property
            existingTicket.IsReturned = true;
            existingTicket.IsPurchased = false;
            existingTicket.ReturnTime = DateTime.Now;

            // Create a new Transaction object and set its properties
            Transaction newTransaction = new Transaction
            {
                PurchaseDate = DateTime.Now,
                Ticket = existingTicket,
                IsReturned = true,
            };

            // Save the updated ticket and the new transaction in the database
            _context.Tickets.Update(existingTicket);
            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();

            // Redirect to a suitable page (e.g., the ticket return confirmation page)
            return View(model);
        }
        else
        {
            TempData["Error"] = "Ticket not found. Please check the details and try again.";
            return RedirectToAction("ReturnIndex");
        }
    }

}