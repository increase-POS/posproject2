using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS_Server.Models
{
    public class ItemUnitInvoiceProfitModel
    {

        ///////////////
        public Nullable<decimal> avgPurchasePrice { get; set; }
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
        public decimal shippingCost { get; set; }
        public decimal realShippingCost { get; set; }
        public decimal shippingProfit { get; set; }
        public decimal totalNoShip { get; set; }
        public decimal totalNetNoShip { get; set; }

    }

    public class ItemTransferInvoiceTax
    {// new properties
        public Nullable<System.DateTime> updateDate { get; set; }
 
        public string agentCompany { get; set; }

        // ItemTransfer
        public int ITitemsTransId { get; set; }
        public Nullable<int> ITitemUnitId { get; set; }
        public Nullable<int> updateUserId { get; set; }
        public Nullable<int> ITitemId { get; set; }
        public Nullable<int> ITunitId { get; set; }

        public Nullable<decimal> ITprice { get; set; }

        public string ITnotes { get; set; }

        public string ITbarcode { get; set; }
    
        //invoice
        public int invoiceId { get; set; }
     
        public Nullable<int> agentId { get; set; }

        public string invType { get; set; }
        public string discountType { get; set; }
  
        public Nullable<decimal> discountValue { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> totalNet { get; set; }
        public Nullable<decimal> paid { get; set; }
        public Nullable<decimal> deserved { get; set; }
        public Nullable<System.DateTime> deservedDate { get; set; }
        public Nullable<System.DateTime> invDate { get; set; }
    
        public Nullable<int> IupdateUserId { get; set; }
    
        public string invCase { get; set; }
   
        public string Inotes { get; set; }
        public string vendorInvNum { get; set; }
       
        public string branchName { get; set; }
        public string posName { get; set; }
        public Nullable<System.DateTime> vendorInvDate { get; set; }
        public Nullable<int> branchId { get; set; }

     
        public Nullable<int> taxtype { get; set; }
        public Nullable<int> posId { get; set; }

        public string ITtype { get; set; }

        public string branchType { get; set; }
       
        public string posCode { get; set; }
        public string agentName { get; set; }

        public string agentType { get; set; }
        public string agentCode { get; set; }
      
        public string uuserName { get; set; }
        public string uuserLast { get; set; }
        public string uUserAccName { get; set; }
        public Nullable<decimal> itemUnitPrice { get; set; }

    
        public Nullable<decimal> subTotalTax { get; set; }
       
     
        public Nullable<decimal> OneitemUnitTax { get; set; }
      
     
        public Nullable<decimal> OneItemOfferVal { get; set; }
        public Nullable<decimal> OneItemPriceNoTax { get; set; }
  
        public Nullable<decimal> OneItemPricewithTax { get; set; }
      
        public Nullable<decimal> itemsTaxvalue { get; set; }


        //invoice
     
        public Nullable<decimal> tax { get; set; }//نسبة الضريبة
        public Nullable<decimal> totalwithTax { get; set; }//قيمة الفاتورة النهائية Totalnet
        public Nullable<decimal> totalNoTax { get; set; }//قيمة الفاتورة قبل الضريبة total
        public Nullable<decimal> invTaxVal { get; set; }//قيمة ضريبة الفاتورة TAX
        public Nullable<int> itemsRowsCount { get; set; }//عدداسطر الفاتورة
     
        //item
        public string ITitemName { get; set; }//اسم العنصر
        public string ITunitName { get; set; }//وحدة العنصر

        public Nullable<long> ITquantity { get; set; }//الكمية
        public Nullable<decimal> subTotalNotax { get; set; }//سعر العناصر قبل الضريبة Price
        public Nullable<decimal> itemUnitTaxwithQTY { get; set; }//قيم الضريبة للعناصر
        public string invNumber { get; set; }//رقم الفاتورة//item
        public Nullable<System.DateTime> IupdateDate { get; set; }//تاريخ الفاتورة//item

        public Nullable<decimal> ItemTaxes { get; set; }//نسبة ضريبة العنصر

        //public string invNumber { get; set; }//رقم الفاتورة
        //public Nullable<System.DateTime> IupdateDate { get; set; }//تاريخ الفاتورة
        //public Nullable<decimal> tax { get; set; }//نسبة الضريبة
        //public Nullable<decimal> totalwithTax { get; set; }//قيمة الفاتورة النهائية Totalnet
        //public Nullable<decimal> totalNoTax { get; set; }//قيمة الفاتورة قبل الضريبة total
        //public Nullable<decimal> invTaxVal { get; set; }//قيمة ضريبة الفاتورة TAX
        //public Nullable<int> itemsRowsCount { get; set; }//عدداسطر الفاتورة
        // public Nullable<decimal> totalNet { get; set; }

    }

    public class OpenClosOperatinModel
    {
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
        public string opSideNum { get; set; }
        public string docName { get; set; }
        public string docNum { get; set; }
        public string docImage { get; set; }
        public Nullable<int> bankId { get; set; }
        public string bankName { get; set; }
        public string agentName { get; set; }
        public string usersName { get; set; }
        public string usersLName { get; set; }
        public string posName { get; set; }
        public string posCreatorName { get; set; }
        public Nullable<byte> isConfirm2 { get; set; }
        public int cashTrans2Id { get; set; }
        public Nullable<int> pos2Id { get; set; }

        public string pos2Name { get; set; }
        public string processType { get; set; }
        public Nullable<int> cardId { get; set; }
        public Nullable<int> bondId { get; set; }
        public string createUserName { get; set; }
        public string updateUserName { get; set; }
        public string updateUserJob { get; set; }
        public string updateUserAcc { get; set; }
        public string createUserJob { get; set; }
        public string createUserLName { get; set; }
        public string updateUserLName { get; set; }
        public string cardName { get; set; }
        public Nullable<System.DateTime> bondDeserveDate { get; set; }
        public Nullable<byte> bondIsRecieved { get; set; }
        public string agentCompany { get; set; }
        public Nullable<int> shippingCompanyId { get; set; }
        public string shippingCompanyName { get; set; }
        public string userAcc { get; set; }

        public Nullable<int> branchCreatorId { get; set; }
        public string branchCreatorname { get; set; }
        public Nullable<int> branchId { get; set; }
        public string branchName { get; set; }
        public Nullable<int> branch2Id { get; set; }
        public string branch2Name { get; set; }




    }
    public class POSOpenCloseModel
    {
        public int cashTransId { get; set; }
        public string transType { get; set; }
        public Nullable<int> posId { get; set; }
   
        public string transNum { get; set; }
      
        public Nullable<decimal> cash { get; set; }
       
        public string notes { get; set; }
       
        public Nullable<byte> isConfirm { get; set; }
        public Nullable<int> cashTransIdSource { get; set; }
        public string side { get; set; }
        
        public string posName { get; set; }
       

        
        public string processType { get; set; }

        
        public Nullable<int> branchId { get; set; }
        public string branchName { get; set; }

        public Nullable<System.DateTime> updateDate { get; set; }
        public Nullable<System.DateTime> openDate { get; set; }
        public Nullable<decimal> openCash { get; set; }
        public Nullable<int> openCashTransId { get; set; }
         


    }
}