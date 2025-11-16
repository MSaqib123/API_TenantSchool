using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        // RolesClaim is wn as "permissions" in the system
        // its used to define what actions a role can perform
        // e.g., "CanEditUsers", "CanDeletePosts", etc.
        // These claims are assigned to roles and then users inherit these claims through their assigned roles.

        public string Description { get; set; }
        public string Group { get; set; }

    }
}
