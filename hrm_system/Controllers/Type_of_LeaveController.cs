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
    public class Type_of_LeaveController : Controller
    {
        private HRMEntities db = new HRMEntities();

        // GET: Type_of_Leave
        public ActionResult Index()
        {
            return View(db.Type_of_Leave.ToList());
        }

        // GET: Type_of_Leave/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_of_Leave type_of_Leave = db.Type_of_Leave.Find(id);
            if (type_of_Leave == null)
            {
                return HttpNotFound();
            }
            return View(type_of_Leave);
        }

        // GET: Type_of_Leave/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Type_of_Leave/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,leave_type,number_of_leaves")] Type_of_Leave type_of_Leave)
        {
            if (ModelState.IsValid)
            {
                db.Type_of_Leave.Add(type_of_Leave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(type_of_Leave);
        }

        // GET: Type_of_Leave/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_of_Leave type_of_Leave = db.Type_of_Leave.Find(id);
            if (type_of_Leave == null)
            {
                return HttpNotFound();
            }
            return View(type_of_Leave);
        }

        // POST: Type_of_Leave/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,leave_type,number_of_leaves")] Type_of_Leave type_of_Leave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(type_of_Leave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(type_of_Leave);
        }

        // GET: Type_of_Leave/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Type_of_Leave type_of_Leave = db.Type_of_Leave.Find(id);
            if (type_of_Leave == null)
            {
                return HttpNotFound();
            }
            return View(type_of_Leave);
        }

        // POST: Type_of_Leave/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Type_of_Leave type_of_Leave = db.Type_of_Leave.Find(id);
            db.Type_of_Leave.Remove(type_of_Leave);
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
