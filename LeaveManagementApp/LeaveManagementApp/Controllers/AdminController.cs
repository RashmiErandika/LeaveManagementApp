using LeaveManagementApp.Models;
using LeaveManagementApp.Persistence.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace LeaveManagementApp.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        //Use admin repository
        private AdminRepository adminRepository;

        public AdminController()
        {
            adminRepository = new AdminRepository(new ApplicationDbContext());
        }

        public AdminController(AdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
            string UseName = form["email"];
            string Email = form["email"];
            string Password = form["password"];

            var user = new ApplicationUser();
            user.UserName = UseName;
            user.Email = Email;
            user.PasswordHash = Password;

            var newuser = userManager.Create(user);
            return View();
        }
        public ActionResult AssignRoles()
        {
            return View();
        }
    }
}