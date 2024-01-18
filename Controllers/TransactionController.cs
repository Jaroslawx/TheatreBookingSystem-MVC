using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Models;

public class TransactionController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransactionController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var transactions = _context.Transactions.Include(t => t.Ticket).Include(t => t.AppUser).ToList();
        return View(transactions);
    }
}

