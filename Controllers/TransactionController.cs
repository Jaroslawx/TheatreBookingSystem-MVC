using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Data.Enum;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;

public class TransactionController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransactionController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Transaction(string purchaserEmail)
    {

        // Filter transactions based on the provided user email
        var transactions = _context.Transactions
            .Include(t => t.Ticket)
            .Include(t => t.AppUser)
            .Where(t => t.Ticket.PurchaserEmail == purchaserEmail)
            .ToList();

        return View(transactions);
    }

    [HttpPost]
    public IActionResult SaveTransaction(TicketViewModel model)
    {
        // Check if the selected seat in the row is already occupied
        bool isSeatOccupied = _context.Tickets
            .Any(t => t.EventId == model.EventId && t.Row == model.SelectedRow && t.Seat == model.SelectedSeat);

        if (isSeatOccupied)
        {
            // Display an alert using TempData for the user
            TempData["Error"] = "The selected seat is already occupied. Please choose another seat.";

            // Redirect back to the Index view with the original model
            return RedirectToAction("Index", "Ticket", model);
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

            // Create a new Transaction object and set its properties
            Transaction newTransaction = new Transaction
            {
                PurchaseDate = DateTime.Now,
                Ticket = newTicket,
            };

            // Save the transaction and ticket in the database
            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home"); // Redirect to a suitable page
        }
    }


}

