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
    
    public partial class Publication
    {
        public int StaffMemNum { get; set; }
        public int PublicationsID { get; set; }
        public Nullable<int> PublicationsType { get; set; }
        public Nullable<int> EditionalRole { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> From { get; set; }
        public Nullable<System.DateTime> To { get; set; }
    
        public virtual EditionalRole EditionalRole1 { get; set; }
        public virtual Main Main { get; set; }
        public virtual PublicationsType PublicationsType1 { get; set; }
    }
}