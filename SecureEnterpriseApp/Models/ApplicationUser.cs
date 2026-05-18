using Microsoft.AspNetCore.Identity;

namespace SecureEnterpriseApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}