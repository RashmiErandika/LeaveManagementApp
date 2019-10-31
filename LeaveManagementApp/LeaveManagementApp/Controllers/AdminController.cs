using LeaveManagementApp.Models;
using LeaveManagementApp.Persistence.Repositories;
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
    }
}