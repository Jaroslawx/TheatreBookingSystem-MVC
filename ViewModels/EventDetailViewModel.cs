using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.ViewModels
{
    public class EventDetailViewModel
    {
        public Event CurrentEvent { get; set; }
        public List<Event> OtherEvents { get; set; }
    }
}
