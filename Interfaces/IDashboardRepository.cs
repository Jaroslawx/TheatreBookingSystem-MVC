using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Event>> GetAllUserEvents();
        Task<List<Event>> GetAllEvents();
    }
}
