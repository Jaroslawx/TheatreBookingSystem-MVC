using Microsoft.AspNetCore.Mvc;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class PerformerController : Controller
    {
        private readonly IPerformerRepository _performerRepository;
        private readonly IEventRepository _eventRepository;
        private readonly IParticipantRepository _participantRepository;
        public PerformerController(IPerformerRepository performerRepository, IEventRepository eventRepository, IParticipantRepository participantRepository)
        {
            _performerRepository = performerRepository;
            _eventRepository = eventRepository;
            _participantRepository = participantRepository;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Performer> performers = await _performerRepository.GetAll();

            var performerViewModels = await Task.WhenAll(performers.Select(async p => new PerformerViewModel
            {
                PerformerId = p.Id,
                Role = p.Role,
                EventId = p.EventId,
                EventName = await _eventRepository.GetEventNameById(p.EventId ?? 0),
                ParticipantId = p.ParticipantId,
                ParticipantFullName = await _participantRepository.GetParticipantFullNameById(p.ParticipantId ?? 0),
            }));

            return View(performerViewModels);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Performer @performer)
        {
            if (!ModelState.IsValid)
            {
                return View(@performer);
            }
            _performerRepository.Add(@performer);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var @performerDetails = await _performerRepository.GetByIdAsync(id);
            if (@performerDetails == null) return View("Error");
            return View(@performerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePerformer(int id)
        {
            var @performerDetails = await _performerRepository.GetByIdAsync(id);
            if (@performerDetails == null) return View("Error");

            _performerRepository.Delete(@performerDetails);
            return RedirectToAction("Index");
        }

    }
}
