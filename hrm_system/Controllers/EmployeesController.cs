using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using hrm_system.Models;
using System.IO;
using hrm_system.ViewModel;
namespace hrm_system.Controllers
{
    public class EmployeesController : Controller
    {
        private HRMEntities db = new HRMEntities();

        Employee_view_model hr = new Employee_view_model();
        // GET: Employees
        public ActionResult Index()
        {       
            var employees = db.Employees.Include(e => e.Designation).Include(e => e.Employee_Status).Include(e => e.Gender);
            return View(employees.ToList());
        }

        //public ActionResult Employee_Search(string search)
        //{
        //    List<Employee> list = db.Employees.Where(e => e.employee_full_name.Contains(search)|| e.employee_email.Contains(search)).ToList();
        //    return PartialView("Employee_Result_Partial_View",list);
        //}
        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create

        public ActionResult Create()
        {
            ViewBag.designation_id = new SelectList(db.Designations, "id", "designation_name");
            ViewBag.employee_status_id = new SelectList(db.Employee_Status, "id", "employee_status_name");
            ViewBag.employee_gender_id = new SelectList(db.Genders, "id", "gender_name");
            List<Departament> depart = db.Departaments.ToList();
            List<Designation> design = db.Designations.ToList();
            List<Gender> gender = db.Genders.ToList();           
            
            return View(new Employee_view_model { dep = depart, des=design,gen=gender});
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
      
        public ActionResult Create([Bind(Include = "id,employee_full_name,employee_departament_id,employee_phone,employee_date_of_birth,employee_gender_id,employee_local_address,employee_permanent_address,designation_id,employee_father_name,employee_email,employee_password,employee_work_duration,date_of_join,join_salary,exit_date,employee_status_id,")] Employee employee,HttpPostedFileBase employee_image,HttpPostedFileBase resume_files,HttpPostedFileBase offer_letter,HttpPostedFileBase joinning_letter,HttpPostedFileBase contract_and_agreement,HttpPostedFileBase id_proof)
        {
                if (employee_image != null)
                {
                    var file_name1 = Path.GetFileName(employee_image.FileName);
                    if (employee_image.ContentLength > 0)
                    {
                        var file_path1 = Path.Combine(Server.MapPath("~/Upload/"), file_name1);
                        employee_image.SaveAs(file_path1);
                    }
                    employee.employee_image = file_name1;          
                    
                }
                if (resume_files!= null)
                {
                    var file_name2 = Path.GetFileName(resume_files.FileName);
                    if (resume_files.ContentLength > 0)
                    {
                        var file_path2 = Path.Combine(Server.MapPath("~/Upload/"), file_name2);
                    resume_files.SaveAs(file_path2);
                    }
                    employee.resume_files = file_name2;

                }
                
                db.Employees.Add(employee);
                db.SaveChanges();

               
                return RedirectToAction("Index");
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.designation_id = new SelectList(db.Designations, "id", "designation_name", employee.designation_id);
            ViewBag.employee_status_id = new SelectList(db.Employee_Status, "id", "employee_status_name", employee.employee_status_id);
            ViewBag.employee_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.employee_gender_id);

            Departament depart = db.Departaments.Find(id);
            Designation design = db.Designations.Find(id);
            Gender gender = db.Genders.Find(id);
            Employee employ = db.Employees.Find(id);
            Employee_Status emp_status = db.Employee_Status.Find(id);
            return View(new Employee_view_model { select_dep = depart, select_des = design, select_gen = gender,selected=employ,select_emp_status=emp_status });
          
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public ActionResult Edit([Bind(Include = "id,employee_full_name,employee_departament_id,employee_phone,employee_date_of_birth,employee_gender_id,employee_local_address,employee_permanent_address,designation_id,employee_father_name,employee_email,employee_password,employee_work_duration,date_of_join,join_salary,exit_date,employee_status_id,resume_files,offer_letter,joinning_letter,contract_and_agreement,id_proof")]  Employee employee, HttpPostedFileBase employee_image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.designation_id = new SelectList(db.Designations, "id", "designation_name", employee.designation_id);
            ViewBag.employee_status_id = new SelectList(db.Employee_Status, "id", "employee_status_name", employee.employee_status_id);
            ViewBag.employee_gender_id = new SelectList(db.Genders, "id", "gender_name", employee.employee_gender_id);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
