using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using hrm_system.Models;
namespace hrm_system.ViewModel
{
    public class Notice_view_model
    {
        HRMEntities db = new HRMEntities();
        public List<Notice> not { get; set; }
        public List<Notice_Status> not_stat { get; set; }
    }
}