using TheatreBookingSystem_MVC.Models;

namespace TheatreBookingSystem_MVC.ViewModels
{
    public class PerformerViewModel
    {
        public int? PerformerId { get; set; }
        public string? Role { get; set; }
        public int? EventId { get; set; }
        public string? EventName { get; set; }
        public int? ParticipantId { get; set; }
        public string? ParticipantFullName { get; set; }
    }

}
