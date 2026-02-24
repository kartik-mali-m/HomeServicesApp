using System.ComponentModel.DataAnnotations;

namespace HomeServicesApp.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        // Navigation
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}