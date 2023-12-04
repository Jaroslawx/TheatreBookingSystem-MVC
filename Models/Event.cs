using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreBookingSystem_MVC.Models
{
	public class Event
	{
        [Key]
        public int? Id { get; set; }
		public string? Name { get; set; }
        public string? Type { get; set; }
		public DateTime? Date { get; set; }
		public DateTime? Time { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }

    }
}
