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
    public class AttendencesController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Attendences
        public ActionResult Index()
        {
            var attendences = db.Attendences.Include(a => a.Attendence_Status).Include(a => a.Employee).Include(a => a.Type_of_Leave);
            return View(attendences.ToList());
        }

        // GET: Attendences/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendence attendence = db.Attendences.Find(id);
            if (attendence == null)
            {
                return HttpNotFound();
            }
            return View(attendence);
        }

        // GET: Attendences/Create
        public ActionResult Create()
        {
            ViewBag.attendence_status_id = new SelectList(db.Attendence_Status, "id", "attendence_status_name");
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image");
            ViewBag.type_of_leave_id = new SelectList(db.Type_of_Leave, "id", "leave_type");
            return View();
        }

        // POST: Attendences/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,employee_id,type_of_leave_id,reason,attendence_status_id")] Attendence attendence)
        {
            if (ModelState.IsValid)
            {
                db.Attendences.Add(attendence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.attendence_status_id = new SelectList(db.Attendence_Status, "id", "attendence_status_name", attendence.attendence_status_id);
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", attendence.employee_id);
            ViewBag.type_of_leave_id = new SelectList(db.Type_of_Leave, "id", "leave_type", attendence.type_of_leave_id);
            return View(attendence);
        }

        // GET: Attendences/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendence attendence = db.Attendences.Find(id);
            if (attendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.attendence_status_id = new SelectList(db.Attendence_Status, "id", "attendence_status_name", attendence.attendence_status_id);
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", attendence.employee_id);
            ViewBag.type_of_leave_id = new SelectList(db.Type_of_Leave, "id", "leave_type", attendence.type_of_leave_id);
            return View(attendence);
        }

        // POST: Attendences/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,employee_id,type_of_leave_id,reason,attendence_status_id")] Attendence attendence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.attendence_status_id = new SelectList(db.Attendence_Status, "id", "attendence_status_name", attendence.attendence_status_id);
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", attendence.employee_id);
            ViewBag.type_of_leave_id = new SelectList(db.Type_of_Leave, "id", "leave_type", attendence.type_of_leave_id);
            return View(attendence);
        }

        // GET: Attendences/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendence attendence = db.Attendences.Find(id);
            if (attendence == null)
            {
                return HttpNotFound();
            }
            return View(attendence);
        }

        // POST: Attendences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendence attendence = db.Attendences.Find(id);
            db.Attendences.Remove(attendence);
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
