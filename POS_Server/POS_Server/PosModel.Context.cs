﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class incposdbEntities : DbContext
    {
        public incposdbEntities()
            : base("name=incposdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<agentMemberships> agentMemberships { get; set; }
        public virtual DbSet<agents> agents { get; set; }
        public virtual DbSet<banks> banks { get; set; }
        public virtual DbSet<bondes> bondes { get; set; }
        public virtual DbSet<branches> branches { get; set; }
        public virtual DbSet<branchesUsers> branchesUsers { get; set; }
        public virtual DbSet<branchStore> branchStore { get; set; }
        public virtual DbSet<cards> cards { get; set; }
        public virtual DbSet<cashTransfer> cashTransfer { get; set; }
        public virtual DbSet<categories> categories { get; set; }
        public virtual DbSet<categoryuser> categoryuser { get; set; }
        public virtual DbSet<cities> cities { get; set; }
        public virtual DbSet<countriesCodes> countriesCodes { get; set; }
        public virtual DbSet<coupons> coupons { get; set; }
        public virtual DbSet<couponsInvoices> couponsInvoices { get; set; }
        public virtual DbSet<docImages> docImages { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<groupObject> groupObject { get; set; }
        public virtual DbSet<groups> groups { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<inventoryItemLocation> inventoryItemLocation { get; set; }
        public virtual DbSet<invoices> invoices { get; set; }
        public virtual DbSet<invoicesOrders> invoicesOrders { get; set; }
        public virtual DbSet<invoiceStatus> invoiceStatus { get; set; }
        public virtual DbSet<items> items { get; set; }
        public virtual DbSet<itemsLocations> itemsLocations { get; set; }
        public virtual DbSet<itemsMaterials> itemsMaterials { get; set; }
        public virtual DbSet<itemsOffers> itemsOffers { get; set; }
        public virtual DbSet<itemsProp> itemsProp { get; set; }
        public virtual DbSet<itemsTransfer> itemsTransfer { get; set; }
        public virtual DbSet<itemsUnits> itemsUnits { get; set; }
        public virtual DbSet<itemTransferOffer> itemTransferOffer { get; set; }
        public virtual DbSet<locations> locations { get; set; }
        public virtual DbSet<medalAgent> medalAgent { get; set; }
        public virtual DbSet<medals> medals { get; set; }
        public virtual DbSet<memberships> memberships { get; set; }
        public virtual DbSet<objects> objects { get; set; }
        public virtual DbSet<offers> offers { get; set; }
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<orderscontents> orderscontents { get; set; }
        public virtual DbSet<Points> Points { get; set; }
        public virtual DbSet<pos> pos { get; set; }
        public virtual DbSet<posUsers> posUsers { get; set; }
        public virtual DbSet<properties> properties { get; set; }
        public virtual DbSet<propertiesItems> propertiesItems { get; set; }
        public virtual DbSet<sections> sections { get; set; }
        public virtual DbSet<serials> serials { get; set; }
        public virtual DbSet<servicesCosts> servicesCosts { get; set; }
        public virtual DbSet<setting> setting { get; set; }
        public virtual DbSet<setValues> setValues { get; set; }
        public virtual DbSet<shippingCompanies> shippingCompanies { get; set; }
        public virtual DbSet<subscriptionFees> subscriptionFees { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<units> units { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<userSetValues> userSetValues { get; set; }
        public virtual DbSet<usersLogs> usersLogs { get; set; }
    }
}
