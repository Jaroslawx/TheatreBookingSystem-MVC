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
                if (!context.Rooms.Any())
                {
                    context.Rooms.AddRange(new List<Room>()
                    {
                        new Room
                        {
                            Number = 101,
                            Seats = 50,
                            BuildingId = 1
                        },
                        new Room
                        {
                            Number = 102,
                            Seats = 40,
                            BuildingId = 1
                        },
                        new Room
                        {
                            Number = 201,
                            Seats = 100,
                            BuildingId = 2
                        },
                        new Room
                        {
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
                            Date = new DateTime(2023, 12, 13),
                            Duration = TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(15)),
                            RoomId = 1
                        },
                        new Event
                        {
                            Name = "Theatre Play",
                            EventType = EventType.Play,
                            Date = new DateTime(2024, 1, 10),
                            Duration = TimeSpan.FromHours(1).Add(TimeSpan.FromMinutes(50)),
                            RoomId = 2
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
