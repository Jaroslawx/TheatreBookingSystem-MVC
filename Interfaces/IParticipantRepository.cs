using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetAll();
        Task<Participant> GetByIdAsync(int id);
        Task<IEnumerable<Participant>> GetParticipantByName(string name);
        Task<string> GetParticipantFullNameById(int id);
        bool Add(Participant @participant);
        bool Update(Participant @participant);
        bool Delete(Participant @participant);
        bool Save();
    }
}
