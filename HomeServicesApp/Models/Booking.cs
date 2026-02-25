using System.ComponentModel.DataAnnotations;
using HomeServicesApp.Enum;

namespace HomeServicesApp.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public int UserId { get; set; }

        public int WorkerId { get; set; }

        // ✅ THIS WAS MISSING
        public int ServiceId { get; set; }

        public DateTime BookingDate { get; set; }

        public BookingStatus Status { get; set; } = BookingStatus.Pending;

        // Navigation
        public User User { get; set; } = null!;
        public Worker Worker { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }
}