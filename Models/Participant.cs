using System.ComponentModel.DataAnnotations;

namespace TheatreBookingSystem_MVC.Models
{
	public class Participant
    {
		[Key]
		public int? Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }

	}
}
