using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheatreBookingSystem_MVC.Data.Enum;

namespace TheatreBookingSystem_MVC.Models
{
	public class Event
	{
        [Key]
        public int? Id { get; set; }
		public string? Name { get; set; }
        public EventType EventType { get; set; }
		public DateTime? Date { get; set; }
		public TimeSpan? Duration { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

    }
}
