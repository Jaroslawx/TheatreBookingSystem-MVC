using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreBookingSystem_MVC.Models
{
	public class Reservation
	{
        [Key]
        public int? Id { get; set; }
		public DateTime? Date { get; set; }
        public TimeSpan? Duration { get; set; }
        [ForeignKey("Room")]
        public int? RoomId { get; set; }
        public Room? Room { get; set; }
        [ForeignKey("AppUser")]
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
