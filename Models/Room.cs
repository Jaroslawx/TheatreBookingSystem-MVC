using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheatreBookingSystem_MVC.Data.Enum;

namespace TheatreBookingSystem_MVC.Models
{
	public class Room
	{
        [Key]
        public int? Id { get; set; }
		public int? Number { get; set; }
		public int? Seats { get; set; }
        public int? SeatsReserved { get; set; }
        [ForeignKey("Building")]
		public int? BuildingId { get; set; }
		public Building? Building { get; set; }
	}
}
