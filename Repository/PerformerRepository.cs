using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Repository
{
    public class PerformerRepository : IPerformerRepository
    {
        private readonly ApplicationDbContext _context;
        public PerformerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Performer @performer)
        {
            _context.Add(@performer);
            return Save();
        }

        public bool Delete(Performer @performer)
        {
            _context.Remove(@performer);
            return Save();
        }

        public async Task<IEnumerable<Performer>> GetAll()
        {
            return await _context.Performers.ToListAsync();
        }

        public async Task<Performer> GetByIdAsync(int id)
        {
            return await _context.Performers.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<IEnumerable<Performer>> GetEventByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(Performer performer)
        {
            _context.Update(performer);
            return Save();
        }
    }
}
