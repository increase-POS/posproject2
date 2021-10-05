using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class ItemUnitInvoiceProfitModel
    {

        ///////////////
        public string ITitemName { get; set; }
        public string ITunitName { get; set; }
        public int ITitemsTransId { get; set; }
        public Nullable<int> ITitemUnitId { get; set; }

        public Nullable<int> ITitemId { get; set; }
        public Nullable<int> ITunitId { get; set; }
        public Nullable<long> ITquantity { get; set; }

        public Nullable<System.DateTime> ITupdateDate { get; set; }
        //  public Nullable<int> IT.createUserId { get; set; } 
        public Nullable<int> ITupdateUserId { get; set; }

        public Nullable<decimal> ITprice { get; set; }
        public string ITbarcode { get; set; }

        public string ITUpdateuserNam { get; set; }
        public string ITUpdateuserLNam { get; set; }
        public string ITUpdateuserAccNam { get; set; }
        public int invoiceId { get; set; }
        public string invNumber { get; set; }
        public Nullable<int> agentId { get; set; }
        public Nullable<int> posId { get; set; }
        public string invType { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> totalNet { get; set; }

        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> branchId { get; set; }
        public Nullable<decimal> discountValue { get; set; }
        public string discountType { get; set; }
        public Nullable<decimal> tax { get; set; }
        // public string name { get; set; }
        //  isApproved { get; set; }


        public Nullable<int> branchCreatorId { get; set; }
        public string branchCreatorName { get; set; }


        public string posName { get; set; }
        public string posCode { get; set; }
        public string agentName { get; set; }
        public string agentCode { get; set; }
        public string agentType { get; set; }

        public string uuserName { get; set; }
        public string uuserLast { get; set; }
        public string uUserAccName { get; set; }
        public string agentCompany { get; set; }
        public Nullable<decimal> subTotal { get; set; }
        public decimal purchasePrice { get; set; }
       public  decimal totalwithTax  { get; set; } 
       public  decimal subTotalNet { get; set; } // with invoice discount 
        public decimal itemunitProfit { get; set; }
        public decimal invoiceProfit { get; set; }

    }
}