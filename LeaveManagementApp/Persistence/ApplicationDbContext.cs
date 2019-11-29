using LeaveManagementApp.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace LeaveManagementApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<EmployeeLeaveCount> EmployeeLeaveCounts { get; set; }

        public System.Data.Entity.DbSet<LeaveManagementApp.Core.Models.LeaveRequest> LeaveRequests { get; set; }
    }
}