using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheatreBookingSystem_MVC.Models
{
	public class Building
	{
        [Key]
        public int? Id { get; set; }
		public string? Name { get; set; }
		public string? Street { get; set; }
		public string? City { get; set; }

	}
}
