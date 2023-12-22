using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TheatreBookingSystem_MVC.Models
{
	public class AppUser : IdentityUser
	{
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Phone { get; set; }
		public bool? IsAdmin { get; set; }

	}
}
