using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheatreBookingSystem_MVC.Data.Enum;

namespace TheatreBookingSystem_MVC.Models
{
    public class Transaction
    {
        [Key]
        public int? Id { get; set; }
        public float? Price { get; set; }
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("Ticket")]
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public bool IsReturned { get; set; }

        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
