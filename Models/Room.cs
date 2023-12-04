using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreBookingSystem_MVC.Models
{
	public class Room
	{
        [Key]
        public int? Id { get; set; }
		public int? Number { get; set; }
		public string? Category { get; set; }
		public int? Seats { get; set; }
		[ForeignKey("Building")]
		public string? BuildingId { get; set; }
		public Building? Building { get; set; }
	}
}
