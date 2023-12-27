using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Event @event)
        {
            _context.Add(@event);
            return Save();
        }

        public bool Delete(Event @event)
        {
            _context.Remove(@event);
            return Save();
        }

        public async Task<IEnumerable<Event>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Event>> GetEventByName(string name)
        {
            return await _context.Events.Where(n => n.Name == name).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved >= 0 ? true : false;
        }

        public bool Update(Event @event)
        {
            _context.Update(@event);
            return Save();
        }
    }
}
