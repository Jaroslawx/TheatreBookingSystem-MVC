using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Repository
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDbContext _context;
        public ParticipantRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Participant @participant)
        {
            _context.Add(@participant);
            return Save();
        }

        public bool Delete(Participant @participant)
        {
            _context.Remove(@participant);
            return Save();
        }

        public async Task<IEnumerable<Participant>> GetAll()
        {
            return await _context.Participants.ToListAsync();
        }

        public async Task<Participant> GetByIdAsync(int id)
        {
            return await _context.Participants.FirstOrDefaultAsync(i => i.Id == id);
        }

        public Task<IEnumerable<Participant>> GetParticipantByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<string?> GetParticipantFullNameById(int id)
        {
            var participant = await _context.Participants.FirstOrDefaultAsync(p => p.Id == id);

            return participant != null ? $"{participant.Name} {participant.Surname}" : "Participant not found";
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool Update(Participant participant)
        {
            throw new NotImplementedException();
        }
    }
}
