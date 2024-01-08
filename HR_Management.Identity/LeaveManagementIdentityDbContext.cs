using HR_Management.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR.Management.Identity
{
    public class LeaveManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public LeaveManagementIdentityDbContext(DbContextOptions<LeaveManagementIdentityDbContext> options)
            : base(options) { }
    }
}
