using System.Threading.Tasks;
using TheatreBookingSystem_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IReservationRepository
    {
        Task<IEnumerable<Reservation>> GetAll(string userId);
        Task<Reservation> GetByIdAsync(int id);
        bool Add(Reservation @reservation);
        bool Update(Reservation @reservation);
        bool Delete(Reservation @reservation);
        bool Save();

    }
}
