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
    
    public partial class ProfessionalAffiliationMembership
    {
        public int StaffMemNum { get; set; }
        public int professionalaffiliationidID { get; set; }
        public Nullable<int> society { get; set; }
        public Nullable<System.DateTime> from { get; set; }
    
        public virtual Main Main { get; set; }
        public virtual society society1 { get; set; }
    }
}