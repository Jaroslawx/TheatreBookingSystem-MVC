using Microsoft.AspNetCore.Mvc;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;

namespace TheatreBookingSystem_MVC.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _HttpContextAccessor = httpContextAccessor;
        }
        public async Task<List<IEventRepository>> GetAllReservations()
        {
            throw new NotImplementedException();
        }
        public async Task<List<IEventRepository>> GetAllEvents()
        {
            throw new NotImplementedException();
        }
    }
}
