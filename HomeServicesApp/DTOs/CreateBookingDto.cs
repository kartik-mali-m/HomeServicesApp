namespace HomeServicesApp.DTOs
{
    public class CreateBookingDto
    {
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
