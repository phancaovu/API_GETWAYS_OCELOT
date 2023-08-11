using Microsoft.AspNetCore.Identity;

namespace UserAPI.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string Username { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
}
