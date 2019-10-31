using LeaveManagementApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LeaveManagementApp.Startup))]
namespace LeaveManagementApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateUserAndRoles();
        }

        public void CreateUserAndRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole("Employee");
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Supervisor1"))
            {
                var role = new IdentityRole("Supervisor1");
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Supervisor2"))
            {
                var role = new IdentityRole("Supervisor2");
                roleManager.Create(role);
            }
        }
    }
}
