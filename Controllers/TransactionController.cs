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

}

