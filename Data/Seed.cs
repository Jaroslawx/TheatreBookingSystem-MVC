using System.Net;
using TheatreBookingSystem_MVC.Data.Enum;
using TheatreBookingSystem_MVC.Models;
using static System.Net.WebRequestMethods;

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
                            Name = "House of Culture Building 1",
                            Street = "Freedom St. 3",
                            City = "Warsaw"
                         },
                        new Building()
                        {
                            Name = "House of Culture Building 2",
                            Street = "Freedom St. 4",
                            City = "Warsaw"
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
                            Number = 8,
                            Seats = 100,
                            BuildingId = 1
                        },
                        new Room
                        {
                            Number = 9,
                            Seats = 85,
                            BuildingId = 1
                        },
                        new Room
                        {
                            Number = 10,
                            Seats = 30,
                            BuildingId = 1
                        },
                        new Room
                        {
                            Number = 8,
                            Seats = 110,
                            BuildingId = 2
                        },
                        new Room
                        {
                            Number = 9,
                            Seats = 90,
                            BuildingId = 2
                        },
                        new Room
                        {
                            Number = 10,
                            Seats = 20,
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
                            Name = "The Phantom of the Opera",
                            Description = "A classic musical by Andrew Lloyd Webber",
                            Src = "https://i.ytimg.com/vi/F1nmDJmMvUc/maxresdefault.jpg",
                            EventType = EventType.Musical,
                            Date = new DateTime(2023, 12, 13),
                            Duration = TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(30)),
                            RoomId = 1
                        },
                        new Event
                        {
                            Name = "Rock Concert: Legends of the 80s",
                            Description = "An unforgettable night with iconic 80s rock hits",
                            Src = "https://techaeris.com/wp-content/uploads/2023/08/80s-Rock-Bands.jpg",
                            EventType = EventType.Concert,
                            Date = new DateTime(2023, 12, 15),
                            Duration = TimeSpan.FromHours(3),
                            RoomId = 2
                        },
                        new Event
                        {
                            Name = "Shakespearean Play: Hamlet",
                            Description = "To be or not to be...",
                            Src = "https://i.ytimg.com/vi/6_Y-tYrGBDc/maxresdefault.jpg",
                            EventType = EventType.Play,
                            Date = new DateTime(2023, 12, 17),
                            Duration = TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(45)),
                            RoomId = 1
                        },
                        new Event
                        {
                            Name = "Jazz Night: Tribute to Miles Davis",
                            Description = "A night of smooth jazz paying tribute to the legendary Miles Davis",                            
                            Src = "https://variety.com/wp-content/uploads/2010/01/miles-davis.jpg?w=1000&h=563&crop=1",
                            EventType = EventType.Concert,
                            Date = new DateTime(2023, 12, 19),
                            Duration = TimeSpan.FromHours(2),
                            RoomId = 4
                        },
                        new Event
                        {
                            Name = "Ballet: Swan Lake",
                            Description = "A timeless ballet performance",
                            Src = "https://assets.classicfm.com/2012/31/swan-lake-at-the-coliseum---london-1343916817-view-0.jpg",
                            EventType = EventType.Other,
                            Date = new DateTime(2023, 12, 20),
                            Duration = TimeSpan.FromHours(2).Add(TimeSpan.FromMinutes(15)),
                            RoomId = 5
                        }

                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
