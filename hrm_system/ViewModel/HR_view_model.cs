using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hrm_system.Models;

namespace hrm_system.ViewModel
{
    public class HR_view_model
    {
        HRMEntities db = new HRMEntities();
        public List<Employee> emp { get; set; }
        public List<Notice> not { get; set; }
        public List<Holiday> hol { get; set; }
        public List<Award> awar { get; set; }
        public List<Attendence> aten { get; set; }


        //Employee profile info
       public Employee select_emp { get; set; }
       public Departament select_dep { get; set; }
       public Designation select_des { get; set; }
       public Gender select_gen { get; set; }
    }
}