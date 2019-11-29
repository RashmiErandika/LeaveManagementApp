using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using LeaveManagementApp.Core.Models;
using LeaveManagementApp.Models;

namespace LeaveManagementApp.Controllers
{
    public class EmployeeLeaveCountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeeLeaveCounts
        public ActionResult Index(string searching)
        {
            var employeeLeaveCounts = db.EmployeeLeaveCounts.Include(e => e.Employee).Include(e => e.Leave);
            if (!String.IsNullOrEmpty(searching))
            {
                employeeLeaveCounts = employeeLeaveCounts.Where(x => x.EmployeeId.Equals(searching));
                
            }
            return View(employeeLeaveCounts.ToList());
        }

        // GET: EmployeeLeaveCounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLeaveCount employeeLeaveCount = db.EmployeeLeaveCounts.Find(id);
            if (employeeLeaveCount == null)
            {
                return HttpNotFound();
            }
            return View(employeeLeaveCount);
        }

        // GET: EmployeeLeaveCounts/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "Name");
            ViewBag.LeaveTypeId = new SelectList(db.Leaves, "Id", "LeaveType");
            return View();
        }

        // POST: EmployeeLeaveCounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,LeaveTypeId,Year,EntitleCount,RemainCount")] EmployeeLeaveCount employeeLeaveCount)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeLeaveCounts.Add(employeeLeaveCount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "Name", employeeLeaveCount.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.Leaves, "Id", "LeaveType", employeeLeaveCount.LeaveTypeId);
            return View(employeeLeaveCount);
        }

        // GET: EmployeeLeaveCounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLeaveCount employeeLeaveCount = db.EmployeeLeaveCounts.Find(id);
            if (employeeLeaveCount == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "Name", employeeLeaveCount.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.Leaves, "Id", "LeaveType", employeeLeaveCount.LeaveTypeId);
            return View(employeeLeaveCount);
        }

        // POST: EmployeeLeaveCounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,LeaveTypeId,Year,EntitleCount,RemainCount")] EmployeeLeaveCount employeeLeaveCount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeLeaveCount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employee, "Id", "Name", employeeLeaveCount.EmployeeId);
            ViewBag.LeaveTypeId = new SelectList(db.Leaves, "Id", "LeaveType", employeeLeaveCount.LeaveTypeId);
            return View(employeeLeaveCount);
        }

        // GET: EmployeeLeaveCounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLeaveCount employeeLeaveCount = db.EmployeeLeaveCounts.Find(id);
            if (employeeLeaveCount == null)
            {
                return HttpNotFound();
            }
            return View(employeeLeaveCount);
        }

        // POST: EmployeeLeaveCounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeLeaveCount employeeLeaveCount = db.EmployeeLeaveCounts.Find(id);
            db.EmployeeLeaveCounts.Remove(employeeLeaveCount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
