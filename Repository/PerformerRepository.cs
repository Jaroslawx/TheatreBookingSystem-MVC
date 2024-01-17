using Microsoft.AspNetCore.Mvc;
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
        public bool Add(Performer performer)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Performer performer)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Performer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Performer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Performer>> GetEventByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Performer performer)
        {
            throw new NotImplementedException();
        }
    }
}
