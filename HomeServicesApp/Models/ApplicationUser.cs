using Microsoft.AspNetCore.Identity;

namespace HomeServicesApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
