using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EventController(IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor )
        {
            _eventRepository = eventRepository;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Event> events = await _eventRepository.GetAll();
            return View(events);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var @event = await _eventRepository.GetByIdAsync(id);
            var otherEvents = await _eventRepository.GetEventWithout(id);

            var viewModel = new EventDetailViewModel
            {
                CurrentEvent = @event,
                OtherEvents = otherEvents.ToList()
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var createEventViewModel = new CreateEventViewModel { AppUserId = curUserId };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Event @event)
        {
            if (!ModelState.IsValid)
            {
                return View(@event);
            }
            var curUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            @event.AppUserId = curUserId;
            _eventRepository.Add(@event);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Edit(int id)
        {
            //var curUserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var @event = await _eventRepository.GetByIdAsync(id);
            if (@event == null) return View("Error");
            var eventVM = new EditEventViewModel
            {
                Id = @event.Id,
                Name = @event.Name,
                AppUserId = @event.AppUserId,
                Description = @event.Description,
                Src = @event.Src,
                EventType = @event.EventType,
                Date = @event.Date,
                Duration = @event.Duration,
                RoomId = @event.RoomId,
                //AppUserId = curUserId
            };
            return View(eventVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditEventViewModel eventVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit event");
                return View("Edit", eventVM);
            }
            
            var @event = new Event
            {
                Id = id,
                Name = eventVM.Name,
                Description = eventVM.Description,
                Src = eventVM.Src,
                EventType = eventVM.EventType,
                Date = eventVM.Date,
                Duration = eventVM.Duration,
                RoomId = eventVM.RoomId
            };

            _eventRepository.Update(@event);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var @eventDetails = await _eventRepository.GetByIdAsync(id);
            if (@eventDetails == null) return View("Error");
            return View(@eventDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteEvent (int id)
        {
            var @eventDetails = await _eventRepository.GetByIdAsync(id);
            if (@eventDetails == null) return View("Error");

            _eventRepository.Delete(@eventDetails);
            return RedirectToAction("Index");
        }

    }
}
