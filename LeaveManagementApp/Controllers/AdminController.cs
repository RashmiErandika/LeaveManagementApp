using LeaveManagementApp.Models;
using LeaveManagementApp.Persistence.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace LeaveManagementApp.Controllers
{
    //[Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        //Use admin repository
        private readonly AdminRepository adminRepository;

        public AdminController()
        {
            adminRepository = new AdminRepository(new ApplicationDbContext());
        }

        public AdminController(AdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
        }
        // GET: Admin
        public ActionResult Index(string search)
        {
            return View(dbContext.Employee.Where(x => x.Name.Contains(search) || search == null).ToList());
        }
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(FormCollection form)
        {
            var userStore = new UserStore<ApplicationUser>(dbContext);
            var userManager = new UserManager<ApplicationUser>(userStore);

            string useName = form["username"];
            string email = form["email"];
            string password = form["password"];

            var user = new ApplicationUser();
            user.UserName = useName;
            user.Email = email;
            
            var newuser = userManager.Create(user, password);
            
            return View();
        }

        public ActionResult AssignRoles()
        {
            ViewBag.Name = new SelectList(dbContext.Roles.ToList(), "Name", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult AssignRoles(FormCollection form)
        {
            string userName = form["username"];
            string role = form["UserRole"];

            ApplicationUser applicationUser = dbContext.Users.Where(u => u.UserName.Equals(userName, System.StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
            userManager.AddToRoles(applicationUser.Id, role);
            return View("Index");
             
        }
    }
}