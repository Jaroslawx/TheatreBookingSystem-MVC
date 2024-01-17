
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Data.Enum;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;


namespace TheatreBookingSystem_MVC.Controllers
{
    public class TicketController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TicketController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        public IActionResult BuyTicket(int eventId, int row, int seat)
        {
            // Fetch event details, available seats, etc.
            var eventData = _context.Events
                .Include(e => e.Room)
                .FirstOrDefault(e => e.Id == eventId);

            if (eventData == null)
            {
                return NotFound();
            }

            var isSeatAvailable = !_context.Tickets
               .Any(t => t.EventId == eventId && t.Row == row && t.Seat == seat && t.IsPurchased);

            if (!isSeatAvailable)
            {
                return View("Error", new ErrorViewModel { RequestId = "Seat not available for purchase." });
            }

            // Create a new TicketViewModel with necessary data for the view
            var ticketViewModel = new TicketViewModel
            {
                EventId = eventId,
                EventName = eventData.Name,
                SelectedTicketType = Enum.GetValues(typeof(TicketType)).Cast<TicketType>().FirstOrDefault(),
            };

            return View(ticketViewModel);
        }

        [HttpPost]
        public IActionResult BuyTicket(TicketViewModel ticketViewModel)
        {

            if (!ModelState.IsValid)
            {
                // If model validation fails, return to the purchase view with errors
                return View(ticketViewModel);
            }

            // Fetch event details
            var eventData = _context.Events
                .Include(e => e.Room)
                .FirstOrDefault(e => e.Id == ticketViewModel.EventId);

            if (eventData == null)
            {
                return NotFound();
            }

            // Check if the selected seat is available for purchase
            var isSeatAvailable = !_context.Tickets
                .Any(t => t.EventId == ticketViewModel.EventId && t.Row == ticketViewModel.SelectedRow
                       && t.Seat == ticketViewModel.SelectedSeat && t.IsPurchased);

            if (!isSeatAvailable)
            {
                ModelState.AddModelError(string.Empty, "The selected seat is not available for purchase.");
                return View(ticketViewModel);
            }

                // Create and save the new ticket
                var newTicket = new Ticket
                {
                    Row = ticketViewModel.SelectedRow,
                    Seat = ticketViewModel.SelectedSeat,
                    TicketType = ticketViewModel.SelectedTicketType,
                    EventId = ticketViewModel.EventId,
                    IsPurchased = true,
                    PurchaseTime = DateTime.Now,
                    PurchaserName = ticketViewModel.PurchaserName,
                    PurchaserEmail = ticketViewModel.PurchaserEmail
                };

                _context.Tickets.Add(newTicket);
                _context.SaveChanges();

            // Redirect to a confirmation page
            return RedirectToAction("TicketConfirmation", new { ticketId = newTicket.Id });
        }

        public IActionResult Return(int ticketId)
        {
            // Fetch ticket details for return
            var ticketData = _context.Tickets
                .Include(t => t.Event)
                .FirstOrDefault(t => t.Id == ticketId);

            if (ticketData == null)
            {
                return NotFound();
            }

            // Create a new ReturnTicketViewModel with necessary data for the view
            var returnTicketViewModel = new ReturnTicketViewModel
            {
                TicketId = ticketId,
                EventName = ticketData.Event?.Name,
                PurchaserName = ticketData.PurchaserName
            };

            return View(returnTicketViewModel);
        }

        [HttpPost]
        public IActionResult Return(ReturnTicketViewModel returnTicketViewModel)
        {
            if (!ModelState.IsValid)
            {
                // If model validation fails, return to the return view with errors
                return View(returnTicketViewModel);
            }

            // Fetch ticket details for return
            var ticketData = _context.Tickets
                .FirstOrDefault(t => t.Id == returnTicketViewModel.TicketId);

            if (ticketData == null)
            {
                return NotFound();
            }

            // Check if the ticket can be returned based on business rules
            if (!ticketData.CanBeReturned())
            {
                ModelState.AddModelError(string.Empty, "This ticket cannot be returned.");
                return View(returnTicketViewModel);
            }

            // Perform the ticket return logic
            ticketData.IsReturned = true;
            ticketData.ReturnTime = DateTime.Now;

            _context.SaveChanges();

            // Redirect to a confirmation page
            return RedirectToAction("ReturnConfirmation", new { ticketId = ticketData.Id });
        }

        public IActionResult CheckAvailability(int eventId, int row, int seat)
        {
            // Check if the seat is available for purchase for the specified event
            var isSeatAvailable = !_context.Tickets
                .Any(t => t.EventId == eventId && t.Row == row && t.Seat == seat && t.IsPurchased);

            // Return a JSON result indicating seat availability
            return Json(new { IsSeatAvailable = isSeatAvailable });
        }

        // GET: Ticket/TicketConfirmation/1
        public IActionResult TicketConfirmation(int ticketId)
        {
            // Fetch ticket details for display on the confirmation page
            var ticket = _context.Tickets
                .Include(t => t.Event)
                .FirstOrDefault(t => t.Id == ticketId);

            if (ticket == null)
            {
                return NotFound(); // Ticket not found
            }

            return View(ticket);
        }

        // GET: Ticket/ReturnConfirmation/1
        public IActionResult ReturnConfirmation(int ticketId)
        {
            // Fetch ticket details for display on the return confirmation page
            var ticket = _context.Tickets
                .Include(t => t.Event)
                .FirstOrDefault(t => t.Id == ticketId);

            if (ticket == null)
            {
                return NotFound(); // Ticket not found
            }

            return View(ticket);
        }
    }
}