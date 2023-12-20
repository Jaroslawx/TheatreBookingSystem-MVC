using System.ComponentModel.DataAnnotations;

namespace TheatreBookingSystem_MVC.Models
{
	public class Participant
    {
		[Key]
		public int? Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }

		// Rename to people taking part in event (with include music stars etc.)

	}
}
