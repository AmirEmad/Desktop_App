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
    
    public partial class Referee
    {
        public int StaffMemNum { get; set; }
        public int RefereeID { get; set; }
        public string name { get; set; }
        public string Position { get; set; }
        public string Affiliation { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<int> ContactNumber { get; set; }
    
        public virtual Main Main { get; set; }
    }
}