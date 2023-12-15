using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheatreBookingSystem_MVC.Models
{
    public class Transaction
    {
        [Key]
        public int? Id { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string BuyerName { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("Ticket")]
        public int? TicketId { get; set; }
        public Ticket? Ticket { get; set; }
    }
}

