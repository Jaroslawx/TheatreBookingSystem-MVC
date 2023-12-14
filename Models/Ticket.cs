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
        public int? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }

        public bool IsPurchased { get; set; }
        public DateTime PurchaseTime { get; set; }
        public bool IsReturned { get; set; }
        public DateTime ReturnTime { get; set; }

        public bool CanBePurchased()
        {
            // Check if the current time is within 2 hours before the event
            return !IsPurchased && Event?.Date != null && DateTime.Now < Event.Date.Value.AddHours(-2);
        }

        public bool CanBeReturned()
        {
            // Check if the current time is at least 2 days before the event
            return IsPurchased && Event?.Date != null && DateTime.Now < Event.Date.Value.AddDays(-2);
        }
    }
}
