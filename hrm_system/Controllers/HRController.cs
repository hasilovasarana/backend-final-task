using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hrm_system.Models;
using hrm_system.ViewModel;

namespace hrm_system.Controllers
{
    public class HRController : Controller
    {
        HRMEntities db = new HRMEntities();
        HR_view_model vm = new HR_view_model();
        // GET: HR
       
       
       
        public ActionResult Index(int? id)
        {
            List<Notice> n = db.Notices.ToList();
            List<Departament> d = db.Departaments.ToList();
            List<Award> a = db.Awards.ToList();
            List<Holiday> h = db.Holidays.ToList();
            Employee find_emp = db.Employees.Find(id);
            Departament find_dep = db.Departaments.Find(id);
            Designation find_des = db.Designations.Find(id);
            Gender find_gen = db.Genders.Find(id);
            return View(new HR_view_model {hol=h, not=n,select_emp=find_emp,select_dep=find_dep,select_des=find_des,select_gen=find_gen});
        }
       
      
    }
}