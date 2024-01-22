using Microsoft.AspNetCore.Mvc;
using TheatreBookingSystem_MVC.Data;
using TheatreBookingSystem_MVC.Interfaces;
using TheatreBookingSystem_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace TheatreBookingSystem_MVC.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<List<Event>> GetAllEvents()
        {
            return new List<Event>();
        }
        public async Task<List<Event>> GetAllUserEvents()
        {
            var curUserId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (curUserId != null)
            {
                var userEvents = _context.Events.Where(r => r.AppUserId == curUserId);
                return await userEvents.ToListAsync();
            }
            else
            {
                // Handle the case where user id is not found
                return new List<Event>();
            }
        }
    }
}
