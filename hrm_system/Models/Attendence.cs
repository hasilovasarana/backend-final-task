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
    
    public partial class Attendence
    {
        public int id { get; set; }
        public Nullable<int> employee_id { get; set; }
        public Nullable<int> type_of_leave_id { get; set; }
        public string reason { get; set; }
        public Nullable<int> attendence_status_id { get; set; }
    
        public virtual Attendence_Status Attendence_Status { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Type_of_Leave Type_of_Leave { get; set; }
    }
}
