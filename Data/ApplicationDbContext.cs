using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
