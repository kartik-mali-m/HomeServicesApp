using System.ComponentModel.DataAnnotations;

namespace HomeServicesApp.Models
{
    public class Service
    {
        public int ServiceId { get; set; }

        [Required]
        public string ServiceName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public string? IconPath { get; set; }



        public ICollection<Booking>? Bookings { get; set; }
    }
}