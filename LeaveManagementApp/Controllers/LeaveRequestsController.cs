using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeaveManagementApp.Core.Models;
using LeaveManagementApp.Models;

namespace LeaveManagementApp.Controllers
{
    public class LeaveRequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LeaveRequests
        public ActionResult Index()
        {
            var leaveRequests = db.LeaveRequests.Include(l => l.Leave);
            return View(leaveRequests.ToList());
        }

        // GET: LeaveRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = db.LeaveRequests.Find(id);
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Create
        public ActionResult Create()
        {
            ViewBag.Leave_Type = new SelectList(db.Leaves, "Id", "LeaveType");
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Leave_Type,StartDate,EndDate,Reason")] LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                db.LeaveRequests.Add(leaveRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Leave_Type = new SelectList(db.Leaves, "Id", "LeaveType", leaveRequest.Leave_Type);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = db.LeaveRequests.Find(id);
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.Leave_Type = new SelectList(db.Leaves, "Id", "LeaveType", leaveRequest.Leave_Type);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Leave_Type,StartDate,EndDate,Reason")] LeaveRequest leaveRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leaveRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Leave_Type = new SelectList(db.Leaves, "Id", "LeaveType", leaveRequest.Leave_Type);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeaveRequest leaveRequest = db.LeaveRequests.Find(id);
            if (leaveRequest == null)
            {
                return HttpNotFound();
            }
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LeaveRequest leaveRequest = db.LeaveRequests.Find(id);
            db.LeaveRequests.Remove(leaveRequest);
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
