using System.ComponentModel.DataAnnotations;

namespace TheatreBookingSystem_MVC.Models
{
    public class ChatMessage
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string AppUserId { get; set; }
    }
}
