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
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole("Admin");
                roleManager.Create(role);

                //var user = new ApplicationUser
                //{
                //    UserName = "Priyanka",
                //    Email = "Priyanka@gmail.com"
                //};

                //string userPWD = "Priyanka@123";

                //var newUser = userManager.Create(user, userPWD);

                ////Add default User to Role Admin    
                //if (newUser.Succeeded)
                //{
                //    var result = userManager.AddToRole(user.Id, "Admin");

                //}
            }

            if (!roleManager.RoleExists("Employee"))
            {
                var role = new IdentityRole("Employee");
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Supervisor"))
            {
                var role = new IdentityRole("Supervisor");
                roleManager.Create(role);
            }
        }
    }
}
