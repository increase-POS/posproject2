//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS_Server
{
    using System;
    using System.Collections.Generic;
    
    public partial class error
    {
        public int errorId { get; set; }
        public string num { get; set; }
        public string msg { get; set; }
        public Nullable<int> posId { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public string stackTrace { get; set; }
        public string targetSite { get; set; }
    
        public virtual branches branches { get; set; }
        public virtual pos pos { get; set; }
        public virtual users users { get; set; }
    }
}
