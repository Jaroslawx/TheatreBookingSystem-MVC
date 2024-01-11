using System.Threading.Tasks;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAll(int userId);
        Task<IActionResult> GetByIdAsync(int id)
        bool Add(Reservation @reservation);
        bool Update(Reservation @reservation);
        bool Delete(Reservation @reservation);
        bool Save();

    }
}
