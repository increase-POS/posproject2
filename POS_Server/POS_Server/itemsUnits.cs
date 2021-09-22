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
    
    public partial class itemsUnits
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public itemsUnits()
        {
            this.itemsLocations = new HashSet<itemsLocations>();
            this.itemsOffers = new HashSet<itemsOffers>();
            this.itemsTransfer = new HashSet<itemsTransfer>();
            this.packages = new HashSet<packages>();
            this.packages1 = new HashSet<packages>();
            this.itemUnitUser = new HashSet<itemUnitUser>();
        }
    
        public int itemUnitId { get; set; }
        public Nullable<int> itemId { get; set; }
        public Nullable<int> unitId { get; set; }
        public Nullable<int> unitValue { get; set; }
        public Nullable<short> defaultSale { get; set; }
        public Nullable<short> defaultPurchase { get; set; }
        public Nullable<decimal> price { get; set; }
        public string barcode { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> subUnitId { get; set; }
        public Nullable<decimal> purchasePrice { get; set; }
        public Nullable<int> storageCostId { get; set; }
        public Nullable<byte> isActive { get; set; }
    
        public virtual items items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itemsLocations> itemsLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itemsOffers> itemsOffers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itemsTransfer> itemsTransfer { get; set; }
        public virtual storageCost storageCost { get; set; }
        public virtual units units { get; set; }
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<packages> packages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<packages> packages1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<itemUnitUser> itemUnitUser { get; set; }
    }
}
