using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;

public class TicketController : Controller
{
    private readonly ApplicationDbContext _context;

    public TicketController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult BuyTicket(TicketViewModel model)
    {
        // Validate model state
        if (!ModelState.IsValid)
        {
            // If validation fails, return to the view with the current model
            return View("Index", model);
        }

        // Your logic to process the ticket purchase
        Ticket ticket = new Ticket
        {
            Row = model.SelectedRow,
            Seat = model.SelectedSeat,
            TicketType = model.SelectedTicketType,
            EventId = model.EventId,
            PurchaserName = model.PurchaserName,
            PurchaserEmail = model.PurchaserEmail,
        };

        // You may want to add additional validation or business logic before saving the ticket
        _context.Tickets.Add(ticket);
        _context.SaveChanges();

        // Display an alert using TempData
        TempData["NotificationType"] = "success";
        TempData["NotificationMessage"] = "Ticket purchased successfully!";

        // Return to the original view
        return View("Index", model);
    }

    [HttpGet]
    public IActionResult Return(int id)
    {
        // Fetch the ticket for the given id from the database
        Ticket ticket = _context.Tickets.Find(id);

        // Check if the ticket is null or cannot be returned
        if (ticket == null || !ticket.CanBeReturned())
        {
            // Handle the case where the ticket cannot be returned
            TempData["NotificationType"] = "error";
            TempData["NotificationMessage"] = "This ticket cannot be returned.";

            // Redirect to the original view or another appropriate action
            return RedirectToAction("Index");
        }

        // Create a ReturnTicketViewModel to pass data to the view
        var returnViewModel = new ReturnTicketViewModel
        {
            TicketId = ticket.Id,
            EventName = ticket.Event?.Name,
            PurchaserName = ticket.PurchaserName
        };

        // Return the view with the ReturnTicketViewModel
        return View();
    }

    [HttpPost]
    public IActionResult Return(ReturnTicketViewModel model)
    {
        // Validate model state
        if (!ModelState.IsValid)
        {
            // If validation fails, return to the view with the current model
            return View(model);
        }

        // Fetch the ticket for the given id from the database
        Ticket ticket = _context.Tickets.Find(model.TicketId);

        // Check if the ticket is null or cannot be returned
        if (ticket == null || !ticket.CanBeReturned())
        {
            // Handle the case where the ticket cannot be returned
            TempData["NotificationType"] = "error";
            TempData["NotificationMessage"] = "This ticket cannot be returned.";

            // Redirect to the original view or another appropriate action
            return RedirectToAction("Index");
        }

        // Perform the ticket return logic
        ticket.IsReturned = true;
        ticket.ReturnTime = DateTime.Now;

        // Update the ticket in the database
        _context.Tickets.Update(ticket);
        _context.SaveChanges();

        // Display an alert using TempData
        TempData["NotificationType"] = "success";
        TempData["NotificationMessage"] = "Ticket returned successfully!";

        // Redirect to the original view or another appropriate action
        return RedirectToAction("Index");
    }
}