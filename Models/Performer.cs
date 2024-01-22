using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreBookingSystem_MVC.Models
{
	public class Performer
    {
        [Key]
        public int? Id { get; set; }
		public string? Role { get; set; }
        [ForeignKey("Event")]
        public int? EventId { get; set; }
        public Event? Event { get; set; }
        [ForeignKey("Participant")]
		public int? ParticipantId { get; set; }
		public Participant? Participant { get; set; }
	}
}
