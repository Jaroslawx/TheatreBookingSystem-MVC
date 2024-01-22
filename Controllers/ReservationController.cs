using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;
using TheatreBookingSystem_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TheatreBookingSystem_MVC.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
           
        }

        public async Task<IActionResult> Index(string userId)
        {
            IEnumerable<Reservation> reservations = await _reservationRepository.GetAll(userId);
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
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null) return View("Error") as IActionResult;

            _reservationRepository.Delete(reservation);
            return RedirectToAction("Index");
        }

    }
}
