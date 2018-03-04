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
    public class AwardsController : Controller
    {
        private HRMEntities db = new HRMEntities();

        Award_view_model vm = new Award_view_model();
        // GET: Awards
        public ActionResult Index()
        {
            ViewBag.awards = db.Awards.ToList();
                           
            var awards = db.Awards.Include(a => a.Employee).Include(a => a.Month).Include(a => a.Year);
            return View(awards.ToList());
        }

        // GET: Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // GET: Awards/Create
        public ActionResult Create()
        {
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image");
            ViewBag.month_id = new SelectList(db.Months, "id", "month_name");
            ViewBag.year_id = new SelectList(db.Years, "id", "id");

            List<Employee> employ = db.Employees.ToList();
            List<Award> award = db.Awards.ToList();
            List<Year> year = db.Years.ToList();
            List<Month> month = db.Months.ToList();
            return View(new Award_view_model {emp=employ,aw=award,ye=year,mon=month });
        }

        // POST: Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
       
        public ActionResult Create([Bind(Include = "id,employee_id,award,gift,cash_price,month_id,year_id")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Awards.Add(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", award.employee_id);
            ViewBag.month_id = new SelectList(db.Months, "id", "month_name", award.month_id);
            ViewBag.year_id = new SelectList(db.Years, "id", "id", award.year_id);
            return View(award);
        }

        // GET: Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", award.employee_id);
            ViewBag.month_id = new SelectList(db.Months, "id", "month_name", award.month_id);
            ViewBag.year_id = new SelectList(db.Years, "id", "id", award.year_id);
            return View(award);
        }

        // POST: Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,employee_id,award,gift,cash_price,month_id,year_id")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Entry(award).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.employee_id = new SelectList(db.Employees, "id", "employee_image", award.employee_id);
            ViewBag.month_id = new SelectList(db.Months, "id", "month_name", award.month_id);
            ViewBag.year_id = new SelectList(db.Years, "id", "id", award.year_id);
            return View(award);
        }

        // GET: Awards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Award award = db.Awards.Find(id);
            db.Awards.Remove(award);
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
