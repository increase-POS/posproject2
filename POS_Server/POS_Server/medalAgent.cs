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
    
    public partial class medalAgent
    {
        public int id { get; set; }
        public Nullable<int> medalId { get; set; }
        public Nullable<int> agentId { get; set; }
        public Nullable<int> offerId { get; set; }
        public Nullable<int> couponId { get; set; }
        public string notes { get; set; }
        public Nullable<byte> isActive { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
    
        public virtual agents agents { get; set; }
        public virtual coupons coupons { get; set; }
        public virtual medals medals { get; set; }
        public virtual offers offers { get; set; }
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
    }
}