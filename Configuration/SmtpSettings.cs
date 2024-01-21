namespace TheatreBookingSystem_MVC.Configuration
{
    public class SmtpSettings
    {
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? SenderAddress { get; set; }
        public string? SenderDisplayName { get; set; }
    }


}
