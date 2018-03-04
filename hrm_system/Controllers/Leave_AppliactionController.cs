using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hrm_system.Models;

namespace hrm_system.Controllers
{
    public class Leave_AppliactionController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Leave_Appliaction
        public ActionResult Index()
        {
            var leave_Appliaction = db.Leave_Appliaction.Include(l => l.Employee).Include(l => l.Leave_Status).Include(l => l.Type_of_Leave);
            return View(leave_Appliaction.ToList());
        }

        // GET: Leave_Appliaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave_Appliaction leave_Appliaction = db.Leave_Appliaction.Find(id);
            if (leave_Appliaction == null)
            {
                return HttpNotFound();
            }
            return View(leave_Appliaction);
        }

        // GET: Leave_Appliaction/Create
        public ActionResult Create()
        {
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image");
            ViewBag.leave_status_id = new SelectList(db.Leave_Status, "id", "leave_status_name");
            ViewBag.leave_type_id = new SelectList(db.Type_of_Leave, "id", "leave_type");
            return View();
        }

        // POST: Leave_Appliaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,employee_id,app_date,leave_type_id,reason,app_on_date,leave_status_id")] Leave_Appliaction leave_Appliaction)
        {
            if (ModelState.IsValid)
            {
                db.Leave_Appliaction.Add(leave_Appliaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", leave_Appliaction.employee_id);
            ViewBag.leave_status_id = new SelectList(db.Leave_Status, "id", "leave_status_name", leave_Appliaction.leave_status_id);
            ViewBag.leave_type_id = new SelectList(db.Type_of_Leave, "id", "leave_type", leave_Appliaction.leave_type_id);
            return View(leave_Appliaction);
        }

        // GET: Leave_Appliaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave_Appliaction leave_Appliaction = db.Leave_Appliaction.Find(id);
            if (leave_Appliaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", leave_Appliaction.employee_id);
            ViewBag.leave_status_id = new SelectList(db.Leave_Status, "id", "leave_status_name", leave_Appliaction.leave_status_id);
            ViewBag.leave_type_id = new SelectList(db.Type_of_Leave, "id", "leave_type", leave_Appliaction.leave_type_id);
            return View(leave_Appliaction);
        }

        // POST: Leave_Appliaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,employee_id,app_date,leave_type_id,reason,app_on_date,leave_status_id")] Leave_Appliaction leave_Appliaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leave_Appliaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", leave_Appliaction.employee_id);
            ViewBag.leave_status_id = new SelectList(db.Leave_Status, "id", "leave_status_name", leave_Appliaction.leave_status_id);
            ViewBag.leave_type_id = new SelectList(db.Type_of_Leave, "id", "leave_type", leave_Appliaction.leave_type_id);
            return View(leave_Appliaction);
        }

        // GET: Leave_Appliaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leave_Appliaction leave_Appliaction = db.Leave_Appliaction.Find(id);
            if (leave_Appliaction == null)
            {
                return HttpNotFound();
            }
            return View(leave_Appliaction);
        }

        // POST: Leave_Appliaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leave_Appliaction leave_Appliaction = db.Leave_Appliaction.Find(id);
            db.Leave_Appliaction.Remove(leave_Appliaction);
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
