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
    
    public partial class PublicationsInReferredJournal
    {
        public int StaffMemNum { get; set; }
        public int PuplishID { get; set; }
        public string Journal { get; set; }
        public string ArticleTitle { get; set; }
        public string authors { get; set; }
        public Nullable<int> Volume { get; set; }
        public Nullable<int> pages { get; set; }
        public Nullable<int> Year { get; set; }
        public string Indexer { get; set; }
    
        public virtual Main Main { get; set; }
        public virtual Year Year1 { get; set; }
    }
}
