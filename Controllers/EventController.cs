using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await _eventRepository.GetAll();
            return View(events);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var @event = await _eventRepository.GetByIdAsync(id);
            return View(@event);
        }

        public IActionResult Create()
        {
            return View();
            // TODO: In Create instead of room id use room number
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return View(@event);
            }
            _eventRepository.Add(@event);
            return RedirectToAction("Index");
        }   

    }
}
