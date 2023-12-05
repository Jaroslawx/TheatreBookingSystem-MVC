using System.Net;
using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            // Here add seed data to the database
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Buildings.Any())
                {
                    context.Buildings.AddRange(new List<Building>()
                    {
                        new Building()
                        {
                            Name = "Building 1",
                            Street = "Wiejska 5",
                            City = "Bialystok"
                         },
                        new Building()
                        {
                            Name = "Building 2",
                            Street = "Wiejska 6",
                            City = "Bialystok"
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
