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
    
    public partial class itemsOffers
    {
        public int ioId { get; set; }
        public Nullable<int> iuId { get; set; }
        public Nullable<int> offerId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
    
        public virtual itemsUnits itemsUnits { get; set; }
        public virtual offers offers { get; set; }
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
    }
}
