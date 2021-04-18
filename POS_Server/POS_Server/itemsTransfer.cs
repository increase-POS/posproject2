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
    
    public partial class itemsTransfer
    {
        public int itemsTransId { get; set; }
        public Nullable<int> itemId { get; set; }
        public Nullable<long> quantity { get; set; }
        public string type { get; set; }
        public Nullable<int> invoiceId { get; set; }
        public Nullable<decimal> discount { get; set; }
        public Nullable<short> discountType { get; set; }
        public Nullable<int> locationIdNew { get; set; }
        public Nullable<int> locationIdOld { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public string notes { get; set; }
    
        public virtual invoices invoices { get; set; }
        public virtual items items { get; set; }
        public virtual locations locations { get; set; }
        public virtual locations locations1 { get; set; }
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
    }
}