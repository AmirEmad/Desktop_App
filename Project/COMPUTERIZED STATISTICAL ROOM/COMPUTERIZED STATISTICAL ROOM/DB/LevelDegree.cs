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
    
    public partial class LevelDegree
    {
        public int StaffMemNum { get; set; }
        public int levelDegreeid { get; set; }
        public string title { get; set; }
        public string BriefOutlines { get; set; }
        public Nullable<int> levedegreeType { get; set; }
        public Nullable<int> EquivalentCourseCode { get; set; }
    
        public virtual levedegreeType levedegreeType1 { get; set; }
        public virtual Main Main { get; set; }
    }
}
