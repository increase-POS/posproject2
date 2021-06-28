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
    
    public partial class cashTransfer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cashTransfer()
        {
            this.bondes = new HashSet<bondes>();
            this.cashTransfer1 = new HashSet<cashTransfer>();
            this.agentMemberships = new HashSet<agentMemberships>();
        }
    
        public int cashTransId { get; set; }
        public string transType { get; set; }
        public Nullable<int> posId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> agentId { get; set; }
        public Nullable<int> invId { get; set; }
        public string transNum { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<decimal> cash { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> createUserId { get; set; }
        public string notes { get; set; }
        public Nullable<int> posIdCreator { get; set; }
        public Nullable<byte> isConfirm { get; set; }
        public Nullable<int> cashTransIdSource { get; set; }
        public string side { get; set; }
        public string docName { get; set; }
        public string docNum { get; set; }
        public string docImage { get; set; }
        public Nullable<int> bankId { get; set; }
        public string processType { get; set; }
        public Nullable<int> cardId { get; set; }
        public Nullable<int> bondId { get; set; }
        public Nullable<int> agentMembershipsId { get; set; }
    
        public virtual agents agents { get; set; }
        public virtual banks banks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bondes> bondes { get; set; }
        public virtual bondes bondes1 { get; set; }
        public virtual cards cards { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cashTransfer> cashTransfer1 { get; set; }
        public virtual cashTransfer cashTransfer2 { get; set; }
        public virtual invoices invoices { get; set; }
        public virtual pos pos { get; set; }
        public virtual pos pos1 { get; set; }
        public virtual users users { get; set; }
        public virtual users users1 { get; set; }
        public virtual users users2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<agentMemberships> agentMemberships { get; set; }
        public virtual agentMemberships agentMemberships1 { get; set; }
    }
}
