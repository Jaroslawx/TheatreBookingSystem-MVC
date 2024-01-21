using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IPerformerRepository
    {
        Task<IEnumerable<Performer>> GetAll();
        Task<Performer> GetByIdAsync(int id);
        Task<IEnumerable<Performer>> GetEventByName(string name);
        bool Add(Performer @performer);
        bool Update(Performer @performer);
        bool Delete(Performer @performer);
        bool Save();
    }
}
