using System.ComponentModel.DataAnnotations;

namespace HomeServicesApp.Models
{
    public class Service
    {
        [Key]
        public int ServiceId { get; set; }

        [Required]
        public string ServiceName { get; set; } = string.Empty;

        [Required]
        public decimal Price { get; set; }

        public string Icon { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}