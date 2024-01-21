using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Ticket)
                .WithMany()
                .HasForeignKey(t => t.TicketId)
                .OnDelete(DeleteBehavior.Restrict); // This line prevents cascading delete

            base.OnModelCreating(modelBuilder);
        }

    }



}
