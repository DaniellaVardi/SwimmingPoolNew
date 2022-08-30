using Microsoft.AspNetCore.Identity;

namespace SwimmingPoolNew.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
