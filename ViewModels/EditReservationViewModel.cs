using System;
using TheatreBookingSystem_MVC.Data.Enum;

namespace TheatreBookingSystem_MVC.ViewModels
{
    public class EditReservationViewModel
    {
        public int? Id { get; set; }
        public DateTime? Date { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? RoomId { get; set; }
        public int? AppUserId { get; set; }
    }

}