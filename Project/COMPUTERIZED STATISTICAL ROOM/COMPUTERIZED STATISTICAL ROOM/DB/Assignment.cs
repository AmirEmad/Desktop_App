//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace COMPUTERIZED_STATISTICAL_ROOM.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Assignment
    {
        public int StaffMemNum { get; set; }
        public int AssignmentsID { get; set; }
        public string Assignmentstype { get; set; }
        public string AssignmentsName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Entity { get; set; }
    
        public virtual Main Main { get; set; }
    }
}
