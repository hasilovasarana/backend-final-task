using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hrm_system.Models;
namespace hrm_system.ViewModel
{
    public class Department_view_model
    {
        public  List<Departament> depart { get; set; }
        public List<Designation> design { get; set; }
    }
}