using Microsoft.AspNetCore.Mvc;

namespace TheatreBookingSystem_MVC.Interfaces
{
    public class IDashboardRepository : Controller
    {
        Task<List<IEventRepository>> GetAllUserEvents;
        Task<List<IEventRepository>> GetAllEvents;
    }
}
