using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hrm_system.Models;
namespace hrm_system.ViewModel
{
    public class Award_view_model
    {
        HRMEntities db = new HRMEntities();
          public List<Award> aw { get; set; }
          public List<Employee> emp { get; set; }
          public List<Year> ye { get; set; }
          public List<Month> mon { get; set; }
    }
}