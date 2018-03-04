using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hrm_system.Models;

namespace hrm_system.Models
{
    public class Multi
    {
        HRMEntities db = new HRMEntities();
        public IEnumerable<HttpPostedFileBase> files { get; set; }
    }
}