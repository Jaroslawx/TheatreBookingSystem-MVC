using System.Net;
using TheatreBookingSystem_MVC.Data.Enum;
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
                            Id=1,
                            Name = "Building 1",
                            Street = "Wiejska 5",
                            City = "Bialystok"
                         },
                        new Building()
                        {
                            Id=2,
                            Name = "Building 2",
                            Street = "Wiejska 6",
                            City = "Bialystok"
                        }
                    });
                    context.SaveChanges();
                }
                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(new List<Room>()
                    {
                        new Room
                        {
                            Id=1,
                            Number = 101,
                            Seats = 50,
                            BuildingId = 1
                        },
                        new Room
                        {
                            Id=2,
                            Number = 102,
                            Seats = 40,
                            BuildingId = 1
                        },
                        new Room
                        {
                            Id=3,
                            Number = 201,
                            Seats = 100,
                            BuildingId = 2
                        },
                        new Room
                        {
                            Id=4,
                            Number = 202,
                            Seats = 60,
                            BuildingId = 2
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Events.Any())
                {
                    context.Events.AddRange(new List<Event>()
                    {
                        new Event
                        {
                            Name = "Concert",
                            EventType = EventType.Concert,
                            Date = DateTime.Now.AddDays(7),
                            Time = DateTime.Now.Date.AddHours(19).TimeOfDay,
                            RoomId = 1
                        },
                        new Event
                        {
                            Name = "Theatre Play",
                            EventType = EventType.Play,
                            Date = DateTime.Now.AddDays(14),
                            Time = DateTime.Now.Date.AddHours(15).AddMinutes(30).TimeOfDay,
                            RoomId = 2
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
