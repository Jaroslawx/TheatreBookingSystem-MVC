using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheatreBookingSystem_MVC.Data.Enum;

namespace TheatreBookingSystem_MVC.Models
{
	public class Ticket
	{
        [Key]
        public int? Id { get; set; }
		public int? Row { get; set; }
		public int? Seat { get; set; }
        public TicketType TicketType { get; set; }
        [ForeignKey("Event")]
        public int? EventId { get; set; }
        public Event? Event { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

    }
}
