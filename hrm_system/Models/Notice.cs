//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace hrm_system.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notice
    {
        public int id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public string notice_title { get; set; }
        public string notice_description { get; set; }
        public Nullable<System.DateTime> notice_create_date { get; set; }
        public Nullable<int> notice_status_id { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Notice_Status Notice_Status { get; set; }
    }
}