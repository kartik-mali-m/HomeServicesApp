using System.ComponentModel.DataAnnotations;

namespace HomeServicesApp.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string SkillType { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        // Navigation
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}