using System;
using System.Collections.Generic;
using TheatreBookingSystem_MVC.Data.Enum;
namespace TheatreBookingSystem_MVC.ViewModels
{
    public class ReturnTicketViewModel
    {
        public int? EventId { get; set; }
        public string? EventName { get; set; }
        public TicketType SelectedTicketType { get; set; }
        public int? SelectedRow { get; set; }
        public int? SelectedSeat { get; set; }
        public string PurchaserName { get; set; }
        public string PurchaserEmail { get; set; }
    }
}
