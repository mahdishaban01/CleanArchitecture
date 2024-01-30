using HR_Management.Identity.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HR_Management.Identity
{
    public class LeaveManagementIdentityDbContext(DbContextOptions<LeaveManagementIdentityDbContext> options) : 
        IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }

    }

}
