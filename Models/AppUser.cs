using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TheatreBookingSystem_MVC.Models
{
	public class AppUser : IdentityUser
	{
		[Key]
		public int? Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }
        public string? Password { get; set; }
		public string? Phone { get; set; }
		public bool? IsAdmin { get; set; }

		// Leave only ticket list and IsAdmin? Rest in view model?

	}
}
