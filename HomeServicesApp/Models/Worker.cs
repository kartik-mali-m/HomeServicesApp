using System.ComponentModel.DataAnnotations;

namespace HomeServicesApp.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [Required]
        public string SkillType { get; set; } = string.Empty;

        public int ExperienceYears { get; set; }

        public decimal ChargesPerHour { get; set; }

        public string Address { get; set; } = string.Empty;

        public string ProfileImagePath { get; set; } = string.Empty;

        public bool IsApproved { get; set; }

        public bool IsAvailable { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Navigation
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
    }
}