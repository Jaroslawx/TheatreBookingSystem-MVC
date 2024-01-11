using System.Threading.Tasks;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        public EventController(IEventRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<IActionResult> Index(int userId)
        {
            IEnumerable<Event> reservations = await _reservationRepository.GetAll(int userId);
            return View(reservations);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Reservation @reservation)
        {
            if (!ModelState.IsValid)
            {
                return View(@reservation);
            }
            _reservationRepository.Add(@reservation);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Detail(int id)
        {
            var @reservation = await _reservationRepository.GetByIdAsync(id);
            return View(@reservation);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditReservationViewModel reservationVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit reservation");
                return View("Edit", reservationVM);
            }

            var @reservation = new Reservation
            {
                Id = id,
                Date = reservationVM.Date,
                Duration = reservationVM.Duration,
                RoomId = reservationVM.RoomId,
                AppUserId = reservationVM.AppUserId,
            };

            _reservationRepository.Update(@reservation);

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var @reservation = await _reservationRepository.GetByIdAsync(id);
            if (@reservation == null) return View("Error");

            _reservationRepository.Delete(@reservation);
            return RedirectToAction("Index");
        }

    }
}
