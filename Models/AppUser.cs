using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TheatreBookingSystem_MVC.Models
{
	public class AppUser : IdentityUser
	{

    public ICollection<Ticket> Tickets { get; set; }
		public ICollection<Reservation> Reservations { get; set; }
		public ICollection<Transaction>? Transactions { get; set; }

		// TODO: Leave transaction or remove from models?
	}
}
