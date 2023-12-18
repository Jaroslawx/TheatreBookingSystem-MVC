using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAll();
        Task<Event> GetByIdAsync(int id);
        Task<IEnumerable<Event>> GetEventByName(string name);
        bool Add(Event @event);
        bool Update(Event @event);
        bool Delete(Event @event);
        bool Save();
    }
}
