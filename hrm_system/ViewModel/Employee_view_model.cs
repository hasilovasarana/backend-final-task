using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hrm_system.Models;
namespace hrm_system.ViewModel
{
    
    public class Employee_view_model
    {
        HRMEntities db = new HRMEntities();

        //Create model

        public List<Employee> emp { get; set; }
        public List<Departament> dep { get; set; }
        public List<Gender> gen { get; set; }
        public List<Designation> des { get; set; }
        public List<Employee_Status> emp_st { get; set; }

        // Edit model
        public Employee selected { get; set; }
        public Employee_Status select_emp_status { get; set; }
        public Gender select_gen { get; set; }
        public Departament select_dep { get; set; }
        public Designation select_des { get; set; }
    }
}