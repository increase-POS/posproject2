﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace POS.Classes
{
    public class ItemTransfer
    {
        public int itemsTransId { get; set; }
        public Nullable<int> itemId { get; set; }
        public string itemName { get; set; }
        public Nullable<long> quantity { get; set; }
        public Nullable<long> lockedQuantity { get; set; }
        public Nullable<long> newLocked { get; set; }
        public Nullable<long> availableQuantity { get; set; }
        public Nullable<int> invoiceId { get; set; }
        public Nullable<int> inventoryItemLocId { get; set; }
        public string invNumber { get; set; }
        public Nullable<int> locationIdNew { get; set; }
        public Nullable<int> locationIdOld { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public string notes { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> itemUnitId { get; set; }
        public Nullable<int> offerId { get; set; }
        public string itemSerial { get; set; }
        public string unitName { get; set; }
        public string barcode { get; set; }    
        public string itemType { get; set; }
        public bool isActive { get; set; }
        public string cause { get; set; }


    }
    public  class CouponInvoice
    {
        public int id { get; set; }
        public Nullable<int> couponId { get; set; }
        public Nullable<int> InvoiceId { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<decimal> discountValue { get; set; }
        public Nullable<byte> discountType { get; set; }
        public string couponCode { get; set; }
    }
    public  class invoiceStatus
    {
        public int invStatusId { get; set; }
        public Nullable<int> invoiceId { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> createDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> createUserId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public string notes { get; set; }
        public Nullable<byte> isActive { get; set; }
    }
    public class Invoice
    {
        public int invoiceId { get; set; }
        public string invNumber { get; set; }
        public Nullable<int> agentId { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> createUserId { get; set; }
        public string invType { get; set; }
        public string discountType { get; set; }
        public Nullable<decimal> discountValue { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> totalNet { get; set; }
        public Nullable<decimal> paid { get; set; }
        public Nullable<decimal> deserved { get; set; }
        public Nullable<System.DateTime> deservedDate { get; set; }
        public Nullable<System.DateTime> invDate { get; set; }
        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> invoiceMainId { get; set; }
        public string invCase { get; set; }
        public Nullable<System.TimeSpan> invTime { get; set; }
        public string notes { get; set; }
        public string vendorInvNum { get; set; }
        public string name { get; set; }
        public string branchName { get; set; }
        public Nullable<System.DateTime> vendorInvDate { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<int> itemsCount { get; set; }
        public Nullable<decimal> tax { get; set; }
        public decimal cashReturn { get; set; }
        public Nullable<int> taxtype { get; set; }
        public Nullable<int> posId { get; set; }
        public Nullable<byte> isApproved { get; set; }
        public Nullable<int> branchCreatorId { get; set; }
        public string branchCreatorName { get; set; }
        public Nullable<int> shippingCompanyId { get; set; }
        public Nullable<int> shipUserId { get; set; }
        public string shipUserName { get; set; }
        public string status { get; set; }
        public int invStatusId { get; set; }
        public decimal manualDiscountValue { get; set; }
        public string manualDiscountType { get; set; }
        public string createrUserName { get; set; }
        // for report
        public int countP { get; set; }
        public int countS { get; set; }
       public Nullable<decimal> totalS { get; set; }
       public Nullable<decimal> totalNetS { get; set; }
       public Nullable<decimal> totalP { get; set; }
       public Nullable<decimal> totalNetP { get; set; }  
        public string branchType { get; set; }
        public string posName { get; set; }
        public string posCode { get; set; }
        public string agentName { get; set; }
        public string agentCompany { get; set; }
        public string agentCode { get; set; }
        public string cuserName { get; set; }
        public string cuserLast { get; set; }
        public string cUserAccName { get; set; }
        public string uuserName { get; set; }
        public string uuserLast { get; set; }
        public string uUserAccName { get; set; }
        
            public int countPb { get; set; }
        public int countD { get; set; }
       public Nullable<decimal> totalPb{ get; set; }
       public Nullable<decimal> totalD{ get; set; }
       public Nullable<decimal> totalNetPb{ get; set; }
       public Nullable<decimal> totalNetD{ get; set; }
      
      
       public Nullable<decimal> paidPb { get; set; }
       public Nullable<decimal> deservedPb { get; set; }
       public Nullable<decimal> discountValuePb { get; set; }
       public Nullable<decimal> paidD { get; set; }
       public Nullable<decimal> deservedD { get; set; }
       public Nullable<decimal> discountValueD { get; set; }
        public int printedcount { get; set; }
        public bool isOrginal { get; set; }

        //*************************************************
        //------------------------------------------------------
        public async Task<int> GetLastNumOfInv(string invCode, int branchId)
        {
            int count =0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invCode", invCode);
            parameters.Add("branchId", branchId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetLastNumOfInv", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    count =int.Parse( c.Value);
                    break;
                }
            }
            return count;
        }
        public async Task<List<Invoice>> GetInvoicesByType(string invType, int branchId)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("branchId", branchId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetByInvoiceType", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> getOrdersForPay(int branchId)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("branchId", branchId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getOrdersForPay", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> GetInvoicesByCreator(string invType, int createUserId, int duration)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("createUserId", createUserId.ToString());
            parameters.Add("duration", duration.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetInvoicesByCreator", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> GetInvoicesForAdmin(string invType, int duration)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("duration", duration.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetInvoicesForAdmin", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<int> GetCountByCreator(string invType, int createUserId, int duration)
        {
            int count = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("createUserId", createUserId.ToString());
            parameters.Add("duration", duration.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetCountByCreator", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    count = int.Parse(c.Value);
                    break;
                }
            }
            return count;
        }
        public async Task<int> GetCountForAdmin(string invType, int duration)
        {
            int count = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("createUserId", createUserId.ToString());
            parameters.Add("duration", duration.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetCountInvoicesForAdmin", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    count = int.Parse(c.Value);
                    break;
                }
            }
            return count;
        }
        public async Task<List<Invoice>> getBranchInvoices(string invType, int branchCreatorId, int branchId=0 )
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("branchCreatorId", branchCreatorId.ToString());
            parameters.Add("branchId", branchId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getBranchInvoices", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> getUnHandeldOrders(string invType, int branchCreatorId, int branchId )
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("branchCreatorId", branchCreatorId.ToString());
            parameters.Add("branchId", branchId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getUnHandeldOrders", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> getInvoicesToReturn(string invType, int userId )
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("userId", userId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getInvoicesToReturn", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<int> GetCountBranchInvoices(string invType, int branchCreatorId, int branchId = 0)
        {
            int count = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("branchCreatorId", branchCreatorId.ToString());
            parameters.Add("branchId", branchId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetCountBranchInvoices", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    count = int.Parse(c.Value);
                    break;
                }
            }
            return count;
        }
        public async Task<int> GetCountUnHandeledOrders(string invType, int branchCreatorId, int branchId = 0)
        {
            int count = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("branchCreatorId", branchCreatorId.ToString());
            parameters.Add("branchId", branchId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetCountUnHandeledOrders", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    count = int.Parse(c.Value);
                    break;
                }
            }
            return count;
        }
        public async Task<int> getDeliverOrdersCount(string invType, string status, int userId)
        {
            int count = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("status", status);
            parameters.Add("userId", userId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getDeliverOrdersCount", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    count = int.Parse(c.Value);
                    break;
                }
            }
            return count;
        }
        public async Task<decimal> GetAvgItemPrice(int itemUnitId, int itemId)
        {
            decimal count = 0;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemUnitId", itemUnitId.ToString());
            parameters.Add("itemId", itemId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("invoices/GetAvgItemPrice", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    count = decimal.Parse(c.Value);
                    break;
                }
            }
            return count;
        }
        public async Task<Invoice> GetInvoicesByNum(string invNum, int branchId = 0)
        {
            Invoice item = new Invoice();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invNum", invNum);
            parameters.Add("branchId", branchId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetByInvNum", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    break;
                }
            }
            return item;
        }

        public async Task<Invoice> GetByInvoiceId(int itemId)
        {
            Invoice item = new Invoice();
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("itemId", itemId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetByInvoiceId", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    break;
                }
            }
            return item;
        }
        public async Task<Invoice> getById(int invoiceId)
        {
            Invoice item = new Invoice();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", invoiceId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetById", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    break;
                }
            }
            return item;
        }
        public async Task<Invoice> getgeneratedInvoice(int mainInvoiceId)
        {
            Invoice item = new Invoice();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", mainInvoiceId.ToString());
            //#################
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getgeneratedInvoice", parameters);

            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    item = JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" });
                    break;
                }
            }
            return item;
        }
        public async Task<List<Invoice>> getDeliverOrders(string invType, string status, int userId)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("status", status);
            parameters.Add("userId", userId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getDeliverOrders", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> GetOrderByType(string invType, int branchId)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("branchId", branchId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetOrderByType", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> GetinvCountBydate(string invType, string branchType, DateTime startDate, DateTime endDate)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invType", invType);
            parameters.Add("branchType", branchType);
            parameters.Add("startDate", startDate.ToString());
            parameters.Add("endDate", endDate.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/GetinvCountBydate", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> GetAll()
        {
            List<Invoice> items = new List<Invoice>();
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/Get");
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> getAgentInvoices(int branchId, int agentId, string type)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("branchId", branchId.ToString());
            parameters.Add("agentId", agentId.ToString());
            parameters.Add("type", type);
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getAgentInvoices", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> getNotPaidAgentInvoices(int agentId)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", agentId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getNotPaidAgentInvoices", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> getShipCompanyInvoices(int branchId, int shippingCompanyId, string type)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("branchId", branchId.ToString());
            parameters.Add("shippingCompanyId", shippingCompanyId.ToString());
            parameters.Add("type", type);
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getShipCompanyInvoices", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<Invoice>> getUserInvoices(int branchId, int userId, string type)
        {
            List<Invoice> items = new List<Invoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("branchId", branchId.ToString());
            parameters.Add("userId", userId.ToString());
            parameters.Add("type", type);
            IEnumerable<Claim> claims = await APIResult.getList("Invoices/getUserInvoices", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<Invoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<ItemTransfer>> GetInvoicesItems(int invoiceId)
        {
            List<ItemTransfer> items = new List<ItemTransfer>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", invoiceId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("ItemsTransfer/Get", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<ItemTransfer>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<ItemTransfer>> getOrderItems(int invoiceId, int branchId)
        {
            List<ItemTransfer> items = new List<ItemTransfer>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("invoiceId", invoiceId.ToString());
            parameters.Add("branchId", branchId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("ItemsTransfer/getOrderItems", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<ItemTransfer>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<ItemTransfer>> getShortageItems(int branchId)
        {
            List<ItemTransfer> items = new List<ItemTransfer>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", invoiceId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("itemsLocations/getShortageItems", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<ItemTransfer>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<CouponInvoice>> GetInvoiceCoupons(int invoiceId)
        {
            List<CouponInvoice> items = new List<CouponInvoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", invoiceId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("couponsInvoices/Get", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<CouponInvoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<List<CouponInvoice>> getOriginalCoupons(int invoiceId)
        {
            List<CouponInvoice> items = new List<CouponInvoice>();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", invoiceId.ToString());
            IEnumerable<Claim> claims = await APIResult.getList("couponsInvoices/GetOriginal", parameters);
            foreach (Claim c in claims)
            {
                if (c.Type == "scopes")
                {
                    items.Add(JsonConvert.DeserializeObject<CouponInvoice>(c.Value, new IsoDateTimeConverter { DateTimeFormat = "dd/MM/yyyy" }));
                }
            }
            return items;
        }
        public async Task<int> saveInvoice(Invoice item)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "Invoices/Save";
            var myContent = JsonConvert.SerializeObject(item);
            parameters.Add("itemObject", myContent);
           return await APIResult.post(method, parameters);
        }
        public async Task<int> saveOrderStatus(invoiceStatus item)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "InvoiceStatus/Save";
            var myContent = JsonConvert.SerializeObject(item);
            parameters.Add("itemObject", myContent);
           return await APIResult.post(method, parameters);
        }
        public async Task<int> saveInvoiceItems(List<ItemTransfer> invoiceItems, int invoiceId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "ItemsTransfer/Save";
            var myContent = JsonConvert.SerializeObject(invoiceItems);
            parameters.Add("itemTransferObject", myContent);
            parameters.Add("invoiceId", invoiceId.ToString());
           return await APIResult.post(method, parameters);
        }
        public async void saveAvgPurchasePrice(List<ItemTransfer> invoiceItems)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "Invoices/saveAvgPrice";
            var myContent = JsonConvert.SerializeObject(invoiceItems);
            parameters.Add("itemTransferObject", myContent);
            await APIResult.post(method, parameters);
        }
        public async Task<int> saveInvoiceCoupons(List<CouponInvoice> invoiceCoupons, int invoiceId, string invType)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "couponsInvoices/Save";
            var myContent = JsonConvert.SerializeObject(invoiceCoupons);
            parameters.Add("itemObject", myContent);
            parameters.Add("invoiceId", invoiceId.ToString());
            parameters.Add("invType", invType);
           return await APIResult.post(method, parameters);
        }
        public async Task<int> deleteInvoice(int invoiceId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", invoiceId.ToString());
            string method = "Invoices/delete";
           return await APIResult.post(method, parameters);
        }
        public async Task<int> deleteOrder(int invoiceId)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("itemId", invoiceId.ToString());
            string method = "Invoices/deleteOrder";
           return await APIResult.post(method, parameters);
        }
        public async Task<string> generateInvNumber(string invoiceCode, string branchCode, int branchId)
        {
            int sequence = await GetLastNumOfInv(invoiceCode, branchId);
            sequence++;
            string strSeq = sequence.ToString();
            if (sequence <= 999999)
                strSeq = sequence.ToString().PadLeft(6, '0');
            string invoiceNum = invoiceCode + "-" + branchCode + "-" + strSeq;
            return invoiceNum;
        }
        public async Task<Invoice> recordCashTransfer(Invoice invoice, string invType)
        {
            Agent agent = new Agent();
            float newBalance = 0;
            agent = await agent.getAgentById(invoice.agentId.Value);

            #region agent Cash transfer
            CashTransfer cashTrasnfer = new CashTransfer();
            cashTrasnfer.posId = MainWindow.posID;
            cashTrasnfer.agentId = invoice.agentId;
            cashTrasnfer.invId = invoice.invoiceId;
            cashTrasnfer.createUserId = invoice.createUserId;
            cashTrasnfer.processType = "balance";
            #endregion
            switch (invType)
            {
                #region purchase
                case "pi"://purchase invoice
                case "sb"://sale bounce
                    cashTrasnfer.transType = "p";
                    if (invType.Equals("pi"))
                    {
                        cashTrasnfer.side = "v"; // vendor
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("pv");
                    }
                    else
                    {
                        cashTrasnfer.side = "c"; // vendor                        
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("pc");

                    }
                    if (agent.balanceType == 1)
                    {
                        if (invoice.totalNet <= (decimal)agent.balance)
                        {
                            invoice.paid = invoice.totalNet;
                            invoice.deserved = 0;
                            newBalance = agent.balance - (float)invoice.totalNet;
                            agent.balance = newBalance;
                        }
                        else
                        {
                            invoice.paid = (decimal)agent.balance;
                            invoice.deserved = invoice.totalNet - (decimal)agent.balance;
                            newBalance = (float)invoice.totalNet - agent.balance;
                            agent.balance = newBalance;
                            agent.balanceType = 0;
                        }

                        cashTrasnfer.cash = invoice.paid;
                        cashTrasnfer.transType = "p"; //pull


                        await invoice.saveInvoice(invoice);

                        await cashTrasnfer.Save(cashTrasnfer); //add agent cash transfer
                        await agent.save(agent);
                    }
                    else if (agent.balanceType == 0)
                    {
                        newBalance = agent.balance + (float)invoice.totalNet;
                        agent.balance = newBalance;
                        await agent.save(agent);
                    }
                    break;
                #endregion
                #region purchase bounce
                case "pb"://purchase bounce invoice
                case "si"://sale invoice
                    cashTrasnfer.transType = "d";

                    if (invType.Equals("pb"))
                    {
                        cashTrasnfer.side = "v"; // vendor
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dv");

                    }
                    else
                    {
                        cashTrasnfer.side = "c"; // customer
                        cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dc");
                    }
                    if (agent.balanceType == 0)
                    {
                        if (invoice.totalNet <= (decimal)agent.balance)
                        {
                            invoice.paid = invoice.totalNet;
                            invoice.deserved = 0;
                            newBalance = agent.balance - (float)invoice.totalNet;
                            agent.balance = newBalance;
                        }
                        else
                        {
                            invoice.paid = (decimal)agent.balance;
                            invoice.deserved = invoice.totalNet - (decimal)agent.balance;
                            newBalance = (float)invoice.totalNet - agent.balance;
                            agent.balance = newBalance;
                            agent.balanceType = 1;
                        }

                        cashTrasnfer.cash = invoice.paid;
                        cashTrasnfer.transType = "d"; //deposit

                        await invoice.saveInvoice(invoice);
                        if (invoice.paid > 0)
                        {
                            await cashTrasnfer.Save(cashTrasnfer); //add cash transfer     
                        }
                        await agent.save(agent);
                    }
                    else if (agent.balanceType == 1)
                    {
                        newBalance = agent.balance + (float)invoice.totalNet;
                        agent.balance = newBalance;
                        await agent.save(agent);
                    }
                    break;
                    #endregion
            }

            return invoice;
        }
        public async Task<Invoice> recordConfiguredAgentCash(Invoice invoice, string invType, CashTransfer cashTransfer)
        {
            Agent agent = new Agent();
            float newBalance = 0;
            agent = await agent.getAgentById(invoice.agentId.Value);

            #region agent Cash transfer
            cashTransfer.posId = MainWindow.posID;
            cashTransfer.agentId = invoice.agentId;
            cashTransfer.invId = invoice.invoiceId;
            cashTransfer.createUserId = invoice.createUserId;
            #endregion
            switch (invType)
            {
                #region purchase
                case "pi"://purchase invoice
                case "sb"://sale bounce
                    cashTransfer.transType = "p";
                    if (invType.Equals("pi"))
                    {
                        cashTransfer.side = "v"; // vendor
                        cashTransfer.transNum = await cashTransfer.generateCashNumber("pv");
                    }
                    else
                    {
                        cashTransfer.side = "c"; // vendor                        
                        cashTransfer.transNum = await cashTransfer.generateCashNumber("pc");

                    }
                    if (agent.balanceType == 1)
                    {
                        if (cashTransfer.cash <= (decimal)agent.balance)
                        {
                            newBalance = agent.balance - (float)cashTransfer.cash;
                            agent.balance = newBalance;
                        }
                        else
                        {
                            newBalance = (float)cashTransfer.cash - agent.balance;
                            agent.balance = newBalance;
                            agent.balanceType = 0;
                        }
                        cashTransfer.transType = "p"; //pull

                        await cashTransfer.Save(cashTransfer); //add agent cash transfer
                        await agent.save(agent);
                    }
                    else if (agent.balanceType == 0)
                    {
                        newBalance = agent.balance + (float)cashTransfer.cash;
                        agent.balance = newBalance;
                        await agent.save(agent);
                    }
                    break;
                #endregion
                #region purchase bounce
                case "pb"://purchase bounce invoice
                case "si"://sale invoice
                    cashTransfer.transType = "d";

                    if (invType.Equals("pb"))
                    {
                        cashTransfer.side = "v"; // vendor
                        cashTransfer.transNum = await cashTransfer.generateCashNumber("dv");
                    }
                    else
                    {
                        cashTransfer.side = "c"; // customer
                        cashTransfer.transNum = await cashTransfer.generateCashNumber("dc");
                    }
                    if (agent.balanceType == 0)
                    {
                        if (cashTransfer.cash <= (decimal)agent.balance)
                        {
                            newBalance = agent.balance - (float)cashTransfer.cash;
                            agent.balance = newBalance;
                        }
                        else
                        {
                            newBalance = (float)cashTransfer.cash - agent.balance;
                            agent.balance = newBalance;
                            agent.balanceType = 1;
                        }
                        cashTransfer.transType = "d"; //deposit

                        if (cashTransfer.cash > 0)
                        {
                            await cashTransfer.Save(cashTransfer); //add cash transfer     
                        }
                        await agent.save(agent);
                    }
                    else if (agent.balanceType == 1)
                    {
                        newBalance = agent.balance + (float)cashTransfer.cash;
                        agent.balance = newBalance;
                        await agent.save(agent);
                    }
                    break;
                    #endregion
            }

            return invoice;
        }
        public async Task<Invoice> recordPosCashTransfer(Invoice invoice, string invType)
        {
            #region pos Cash transfer
            CashTransfer posCash = new CashTransfer();
            posCash.posId = MainWindow.posID;
            posCash.agentId = invoice.agentId;
            posCash.invId = invoice.invoiceId;
            posCash.createUserId = invoice.createUserId;
            posCash.processType = "inv";
            posCash.cash = invoice.totalNet;

            #endregion
            switch (invType)
            {
                #region purchase
                case "pi"://purchase invoice
                case "sb"://sale bounce
                    posCash.transType = "d";
                    if (invType.Equals("pi"))
                    {
                        posCash.side = "v"; // vendor
                        posCash.transNum = await posCash.generateCashNumber("dv");
                    }
                    else
                    {
                        posCash.side = "c"; // vendor
                        posCash.transNum = await posCash.generateCashNumber("dc");

                    }
                    await posCash.Save(posCash); //add pos cash transfer
                    break;
                #endregion
                #region purchase bounce
                case "pb"://purchase bounce invoice
                case "si"://sale invoice
                    posCash.transType = "p";

                    if (invType.Equals("pb"))
                    {
                        posCash.side = "v"; // vendor
                        posCash.transNum = await posCash.generateCashNumber("pv");
                    }
                    else
                    {
                        posCash.side = "c"; // customer
                        posCash.transNum = await posCash.generateCashNumber("pc");
                    }
                    await posCash.Save(posCash); //add pos cash transfer

                    break;
                    #endregion
            }

            return invoice;
        }
        public async Task<Invoice> recordCompanyCashTransfer(Invoice invoice, string invType)
        {
            ShippingCompanies company = new ShippingCompanies();
            decimal newBalance = 0;
            company = await company.GetByID(invoice.shippingCompanyId.Value);

            CashTransfer cashTrasnfer = new CashTransfer();
            cashTrasnfer.posId = MainWindow.posID;
            cashTrasnfer.shippingCompanyId = invoice.shippingCompanyId;
            cashTrasnfer.invId = invoice.invoiceId;
            cashTrasnfer.createUserId = invoice.createUserId;
            cashTrasnfer.processType = "balance";
            cashTrasnfer.transType = "d"; //deposit
            cashTrasnfer.side = "sh"; // vendor
            cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dsh");

            if (company.balanceType == 0)
            {
                if (invoice.totalNet <= (decimal)company.balance)
                {
                    invoice.paid = invoice.totalNet;
                    invoice.deserved = 0;
                    newBalance = (decimal)company.balance - (decimal)invoice.totalNet;
                    company.balance = newBalance;
                }
                else
                {
                    invoice.paid = (decimal)company.balance;
                    invoice.deserved = invoice.totalNet - (decimal)company.balance;
                    newBalance = (decimal)invoice.totalNet - company.balance;
                    company.balance = newBalance;
                    company.balanceType = 1;
                }

                cashTrasnfer.cash = invoice.paid;
                cashTrasnfer.transType = "d"; //deposit
                if (invoice.paid > 0)
                {
                    await cashTrasnfer.Save(cashTrasnfer); //add cash transfer
                    await invoice.saveInvoice(invoice);
                }
                await company.save(company);
            }
            else if (company.balanceType == 1)
            {
                newBalance = (decimal)company.balance + (decimal)invoice.totalNet;
                company.balance = newBalance;
                await company.save(company);
            }
            return invoice;
        }
        public async Task<Invoice> recordComSpecificPaidCash(Invoice invoice, string invType, CashTransfer cashTrasnfer)
        {
            ShippingCompanies company = new ShippingCompanies();
            decimal newBalance = 0;
            company = await company.GetByID(invoice.shippingCompanyId.Value);

            cashTrasnfer.posId = MainWindow.posID;
            cashTrasnfer.shippingCompanyId = invoice.shippingCompanyId;
            cashTrasnfer.invId = invoice.invoiceId;
            cashTrasnfer.createUserId = invoice.createUserId;
            cashTrasnfer.transType = "d"; //deposit
            cashTrasnfer.side = "sh"; // vendor
            cashTrasnfer.transNum = await cashTrasnfer.generateCashNumber("dsh");

            if (company.balanceType == 0)
            {
                if (cashTrasnfer.cash <= (decimal)company.balance)
                {
                    newBalance = (decimal)company.balance - (decimal)cashTrasnfer.cash;
                    company.balance = newBalance;
                }
                else
                {
                    newBalance = (decimal)cashTrasnfer.cash - company.balance;
                    company.balance = newBalance;
                    company.balanceType = 1;
                }
                cashTrasnfer.transType = "d"; //deposit
                if (cashTrasnfer.cash > 0)
                {
                    await cashTrasnfer.Save(cashTrasnfer); //add cash transfer
                }
                await company.save(company);
            }
            else if (company.balanceType == 1)
            {
                newBalance = (decimal)company.balance + (decimal)cashTrasnfer.cash;
                company.balance = newBalance;
                await company.save(company);
            }
            return invoice;
        }


        public async Task<int> updateprintstat(int id, int countstep, bool isOrginal, bool updateOrginalstate)
        {
        
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            string method = "Invoices/updateprintstat";
            parameters.Add("id", id.ToString());
            parameters.Add("countstep", countstep.ToString());
            parameters.Add("isOrginal", isOrginal.ToString());
            parameters.Add("updateOrginalstate", updateOrginalstate.ToString());
            return await APIResult.post(method, parameters);
        }
        //updateprintstat
    }
}
