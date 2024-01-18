using Microsoft.AspNetCore.Mvc;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class PerformerController : Controller
    {
        private readonly IPerformerRepository _performerRepository;
        public PerformerController(IPerformerRepository performerRepository)
        {
            _performerRepository = performerRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Performer> performers = await _performerRepository.GetAll();

            var performerViewModels = performers.Select(p => new PerformerViewModel
            {
                PerformerId = p.Id,
                Role = p.Role,
                EventId = p.EventId,
                EventName = p.Event?.Name,
                ParticipantId = p.ParticipantId,
                ParticipantName = p.Participant?.Name,
                ParticipantSurname = p.Participant?.Surname
            });

            return View(performerViewModels);
        }
    }
}
