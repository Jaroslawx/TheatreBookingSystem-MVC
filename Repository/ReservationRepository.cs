using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Repository
{

    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reservation>> GetAll(string userId)
        {
            return await _context.Reservations.Where(r => r.AppUserId == userId).ToListAsync();
        }


        public async Task<Reservation> GetByIdAsync(int id)
        {
            return await _context.Reservations.FirstOrDefaultAsync(i => i.Id == id);
        }


        public bool Add(Reservation @reservation)
        {
            _context.Add(@reservation);
            return Save();
        }

        public bool Delete(Reservation @reservation)
        {
            _context.Remove(@reservation);
            return Save();
        }

        public bool Update(Reservation @reservation)
        {
            _context.Update(@reservation);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }







    }

}

