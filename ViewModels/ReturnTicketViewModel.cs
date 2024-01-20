using System;
using System.Collections.Generic;
namespace TheatreBookingSystem_MVC.ViewModels
{
    // ReturnTicketViewModel.cs
    public class ReturnTicketViewModel
    {
        public int? TicketId { get; set; }
        public string? EventName { get; set; }
        public string? PurchaserName { get; set; }
    }
}
