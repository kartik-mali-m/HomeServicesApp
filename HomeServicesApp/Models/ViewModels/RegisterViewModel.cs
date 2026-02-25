using System.ComponentModel.DataAnnotations;

namespace HomeServicesApp.Models.ViewModels
{
    public class RegisterViewModel
    {

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter valid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Enter valid phone number")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Skill type is required")]
        public string SkillType { get; set; } = string.Empty;

        [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years")]
        public int ExperienceYears { get; set; }

        [Required(ErrorMessage = "Charges per hour is required")]
        [Range(1, 100000, ErrorMessage = "Enter valid charge amount")]
        public decimal ChargesPerHour { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(250)]
        public string Address { get; set; } = string.Empty;
    }
}
