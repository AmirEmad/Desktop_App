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
    
    public partial class InvitedLecture
    {
        public int StaffMemNum { get; set; }
        public int LectureID { get; set; }
        public string title { get; set; }
        public string invier { get; set; }
        public string Organization { get; set; }
        public Nullable<System.DateTime> date { get; set; }
    
        public virtual Main Main { get; set; }
    }
}