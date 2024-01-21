using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<IEventRepository>> GetAllUserEvents();
        Task<List<IEventRepository>> GetAllEvents();
    }
}
