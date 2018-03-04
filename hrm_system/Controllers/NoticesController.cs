using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hrm_system.Models;
using hrm_system.ViewModel;
namespace hrm_system.Controllers
{
    public class NoticesController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Notices
        public ActionResult Index()
        {
            var notices = db.Notices.Include(n => n.Employee).Include(n => n.Notice_Status);
            //List<Notice> no = db.Notices.ToList();
            //List<Notice_Status> not_status = db.Notice_Status.ToList();
            return View(notices.ToList());
        }

        // GET: Notices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // GET: Notices/Create
        public ActionResult Create()
        {
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image");
            ViewBag.notice_status_id = new SelectList(db.Notice_Status, "id", "status_name");
            return View();
        }

        // POST: Notices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Create([Bind(Include = "id,employee_id,notice_title,notice_description,notice_create_date,notice_status_id")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Notices.Add(notice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", notice.employee_id);
            ViewBag.notice_status_id = new SelectList(db.Notice_Status, "id", "status_name", notice.notice_status_id);
            return View(notice);
        }

        // GET: Notices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", notice.employee_id);
            ViewBag.notice_status_id = new SelectList(db.Notice_Status, "id", "status_name", notice.notice_status_id);
            return View(notice);
        }

        // POST: Notices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,employee_id,notice_title,notice_description,notice_create_date,notice_status_id")] Notice notice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", notice.employee_id);
            ViewBag.notice_status_id = new SelectList(db.Notice_Status, "id", "status_name", notice.notice_status_id);
            return View(notice);
        }

        // GET: Notices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notice notice = db.Notices.Find(id);
            if (notice == null)
            {
                return HttpNotFound();
            }
            return View(notice);
        }

        // POST: Notices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notice notice = db.Notices.Find(id);
            db.Notices.Remove(notice);
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
