using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreBookingSystem_MVC.Models
{
	public class Ticket
	{
        [Key]
        public int? Id { get; set; }
		public int? Row { get; set; }
		public int? Seat { get; set; }
        public string? Type { get; set; }
        [ForeignKey("Event")]
        public int? EventId { get; set; }
        public Event? Event { get; set; }
        [ForeignKey("AppUser")]
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
