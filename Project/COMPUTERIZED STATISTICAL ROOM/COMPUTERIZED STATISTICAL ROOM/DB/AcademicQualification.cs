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
    
    public partial class AcademicQualification
    {
        public int StaffMemNum { get; set; }
        public int AqNumber { get; set; }
        public Nullable<int> degree { get; set; }
        public Nullable<int> Class { get; set; }
        public Nullable<System.DateTime> DateofAward { get; set; }
        public string Institute { get; set; }
        public Nullable<int> Country { get; set; }
        public string Address { get; set; }
        public Nullable<int> GeneralSpecialization { get; set; }
        public Nullable<int> SpecificSpecialization { get; set; }
    
        public virtual Class Class1 { get; set; }
        public virtual Degree Degree1 { get; set; }
        public virtual GeneralSpecialization GeneralSpecialization1 { get; set; }
        public virtual Main Main { get; set; }
        public virtual SpecificSpecialization SpecificSpecialization1 { get; set; }
    }
}
