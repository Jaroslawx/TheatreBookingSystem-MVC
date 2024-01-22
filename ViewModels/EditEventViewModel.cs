using TheatreBookingSystem_MVC.Data.Enum;

namespace TheatreBookingSystem_MVC.ViewModels
{
    public class EditEventViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Src { get; set; }
        public EventType EventType { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? RoomId { get; set; }
        public string? AppUserId { get; set; }
    }
}
