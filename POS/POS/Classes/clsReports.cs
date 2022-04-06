using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using POS.View.storage;
namespace POS.Classes
{
    class clsReports
    {
        public static void setReportLanguage(List<ReportParameter> paramarr)
        {

            paramarr.Add(new ReportParameter("lang", MainWindow.Reportlang));

        }

        public static void Header(List<ReportParameter> paramarr)
        {

            ReportCls rep = new ReportCls();
            paramarr.Add(new ReportParameter("companyName", MainWindow.companyName));
            paramarr.Add(new ReportParameter("Fax", MainWindow.Fax));
            paramarr.Add(new ReportParameter("Tel", MainWindow.Mobile));
            paramarr.Add(new ReportParameter("Address", MainWindow.Address));
            paramarr.Add(new ReportParameter("Email", MainWindow.Email));
            paramarr.Add(new ReportParameter("logoImage", "file:\\" + rep.GetLogoImagePath()));
            paramarr.Add(new ReportParameter("show_header", MainWindow.show_header));

        }
        public static void HeaderNoLogo(List<ReportParameter> paramarr)
        {

            ReportCls rep = new ReportCls();
            paramarr.Add(new ReportParameter("companyName", MainWindow.companyName));
            paramarr.Add(new ReportParameter("Fax", MainWindow.Fax));
            paramarr.Add(new ReportParameter("Tel", MainWindow.Mobile));
            paramarr.Add(new ReportParameter("Address", MainWindow.Address));
            paramarr.Add(new ReportParameter("Email", MainWindow.Email));
            paramarr.Add(new ReportParameter("show_header", MainWindow.show_header));


        }
        public static void bankdg(List<ReportParameter> paramarr)
        {

            ReportCls rep = new ReportCls();
            paramarr.Add(new ReportParameter("trTransferNumber", MainWindow.resourcemanagerreport.GetString("trTransferNumberTooltip")));


        }
        public static void bondsReport(IEnumerable<Bonds> bondsQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            paramarr.Add(new ReportParameter("trDocNumTooltip", MainWindow.resourcemanagerreport.GetString("trDocNumTooltip")));
            paramarr.Add(new ReportParameter("trRecipientTooltip", MainWindow.resourcemanagerreport.GetString("trRecipientTooltip")));

            paramarr.Add(new ReportParameter("trPaymentTypeTooltip", MainWindow.resourcemanagerreport.GetString("trPaymentTypeTooltip")));

            paramarr.Add(new ReportParameter("trDocDateTooltip", MainWindow.resourcemanagerreport.GetString("trDocDateTooltip")));

            paramarr.Add(new ReportParameter("trPayDate", MainWindow.resourcemanagerreport.GetString("trPayDate")));
            paramarr.Add(new ReportParameter("trCashTooltip", MainWindow.resourcemanagerreport.GetString("trCashTooltip")));

            foreach (var c in bondsQuery)
            {

                c.amount = decimal.Parse(SectionData.DecTostring(c.amount));
            }
            rep.DataSources.Add(new ReportDataSource("DataSetBond", bondsQuery));

            DateFormConv(paramarr);
            AccountSideConv(paramarr);
            cashTransTypeConv(paramarr);

        }

        public static void bondsDocReport(LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();



            DateFormConv(paramarr);


        }
        //public static void orderReport(IEnumerable<Invoice> invoiceQuery, LocalReport rep, string reppath)
        //{
        //    rep.ReportPath = reppath;
        //    rep.EnableExternalImages = true;
        //    rep.DataSources.Clear();
        //    foreach(var o in invoiceQuery)
        //    {
        //        string status = "";
        //        switch (o.status)
        //        {
        //            case "tr":
        //                status = MainWindow.resourcemanager.GetString("trDelivered");
        //                break;
        //            case "rc":
        //                status = MainWindow.resourcemanager.GetString("trInDelivery");
        //                break;
        //            default:
        //                status = "";
        //                break;
        //        }
        //        o.status = status;
        //        o.deserved = decimal.Parse(SectionData.DecTostring(o.deserved));
        //    }
        //    rep.DataSources.Add(new ReportDataSource("DataSetInvoice", invoiceQuery));
        //}
        public static void orderReport(IEnumerable<Invoice> invoiceQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            foreach (var o in invoiceQuery)
            {
                o.deserved = decimal.Parse(SectionData.DecTostring(o.deserved));
                o.payStatus = invoicePayStatusConvert(o.payStatus);
            }
            DeliverStateConv(paramarr);

            paramarr.Add(new ReportParameter("trInvoiceNumber", MainWindow.resourcemanagerreport.GetString("trInvoiceNumber")));
            paramarr.Add(new ReportParameter("trSalesMan", MainWindow.resourcemanagerreport.GetString("trSalesMan")));
            paramarr.Add(new ReportParameter("trCustomer", MainWindow.resourcemanagerreport.GetString("trCustomer")));
            paramarr.Add(new ReportParameter("trDate", MainWindow.resourcemanagerreport.GetString("trDate")));
            paramarr.Add(new ReportParameter("trCashTooltip", MainWindow.resourcemanagerreport.GetString("trCashTooltip")));
            paramarr.Add(new ReportParameter("trState", MainWindow.resourcemanagerreport.GetString("trState")));

            DateFormConv(paramarr);


            rep.DataSources.Add(new ReportDataSource("DataSetInvoice", invoiceQuery));
        }

        
            public static string  invoicePayStatusConvert(string payStatus)
            {
            
                switch (payStatus)
                {
                    case "payed": return MainWindow.resourcemanagerreport.GetString("trPaid_");

                    case "unpayed": return MainWindow.resourcemanagerreport.GetString("trUnPaid");

                    case "partpayed": return MainWindow.resourcemanagerreport.GetString("trCredit");

                    default: return "";

                }
            }
            public static void DeliverStateConv(List<ReportParameter> paramarr)
        {
            paramarr.Add(new ReportParameter("trDelivered", MainWindow.resourcemanagerreport.GetString("trDelivered")));
            paramarr.Add(new ReportParameter("trInDelivery", MainWindow.resourcemanagerreport.GetString("trInDelivery")));

        }

        public static void bankAccReport(IEnumerable<CashTransfer> cash, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {



            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            paramarr.Add(new ReportParameter("trTransferNumberTooltip", MainWindow.resourcemanagerreport.GetString("trTransferNumberTooltip")));
            paramarr.Add(new ReportParameter("trBank", MainWindow.resourcemanagerreport.GetString("trBank")));
            paramarr.Add(new ReportParameter("trDepositeNumTooltip", MainWindow.resourcemanagerreport.GetString("trDepositeNumTooltip")));
            paramarr.Add(new ReportParameter("trDate", MainWindow.resourcemanagerreport.GetString("trDate")));
            paramarr.Add(new ReportParameter("trCashTooltip", MainWindow.resourcemanagerreport.GetString("trCashTooltip")));
            DateFormConv(paramarr);
            foreach (var c in cash)
            {
                ///////////////////
                c.cash = decimal.Parse(SectionData.DecTostring(c.cash));
                string s;
                switch (c.processType)
                {
                    case "cash":
                        s = MainWindow.resourcemanagerreport.GetString("trCash");
                        break;
                    case "doc":
                        s = MainWindow.resourcemanagerreport.GetString("trDocument");
                        break;
                    case "cheque":
                        s = MainWindow.resourcemanagerreport.GetString("trCheque");
                        break;
                    case "balance":
                        s = MainWindow.resourcemanagerreport.GetString("trCredit");
                        break;
                    case "card":
                        s = MainWindow.resourcemanagerreport.GetString("trCreditCard");
                        break;
                    default:
                        s = c.processType;
                        break;
                }
                ///////////////////
                c.processType = s;
                string name = "";
                switch (c.side)
                {
                    case "bnd": break;
                    case "v": name = MainWindow.resourcemanagerreport.GetString("trVendor"); break;
                    case "c": name = MainWindow.resourcemanagerreport.GetString("trCustomer"); break;
                    case "u": name = MainWindow.resourcemanagerreport.GetString("trUser"); break;
                    case "s": name = MainWindow.resourcemanagerreport.GetString("trSalary"); break;
                    case "e": name = MainWindow.resourcemanagerreport.GetString("trGeneralExpenses"); break;
                    case "m":
                        if (c.transType == "d")
                            name = MainWindow.resourcemanagerreport.GetString("trAdministrativeDeposit");
                        if (c.transType == "p")
                            name = MainWindow.resourcemanagerreport.GetString("trAdministrativePull");
                        break;
                    case "sh": name = MainWindow.resourcemanagerreport.GetString("trShippingCompany"); break;
                    default: break;
                }
                string fullName = "";
                if (!string.IsNullOrEmpty(c.agentName))
                    fullName = name + " " + c.agentName;
                else if (!string.IsNullOrEmpty(c.usersLName))
                    fullName = name + " " + c.usersLName;
                else if (!string.IsNullOrEmpty(c.shippingCompanyName))
                    fullName = name + " " + c.shippingCompanyName;
                else
                    fullName = name;
                /////////////////////
                c.side = fullName;

                string type;
                if (c.transType.Equals("p")) type = MainWindow.resourcemanagerreport.GetString("trPull");
                else type = MainWindow.resourcemanagerreport.GetString("trDeposit");
                ////////////////////
                c.transType = type;
            }
            rep.DataSources.Add(new ReportDataSource("DataSetBankAcc", cash));
        }

        public static void paymentAccReport(IEnumerable<CashTransfer> cash, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            //foreach (var c in cash)
            //{
            //    ///////////////////
            //    c.cash = decimal.Parse(SectionData.DecTostring(c.cash));
            //    string s;
            //    switch (c.processType)
            //    {
            //        case "cash":
            //            s = MainWindow.resourcemanagerreport.GetString("trCash");
            //            break;
            //        case "doc":
            //            s = MainWindow.resourcemanagerreport.GetString("trDocument");
            //            break;
            //        case "cheque":
            //            s = MainWindow.resourcemanagerreport.GetString("trCheque");
            //            break;
            //        case "balance":
            //            s = MainWindow.resourcemanagerreport.GetString("trCredit");
            //            break;
            //        default:
            //            s = c.processType;
            //            break;
            //    }


            //}
         

            AccountSideConv(paramarr);

            cashTransTypeConv(paramarr);
            cashTransferProcessTypeConv(paramarr);

            paramarr.Add(new ReportParameter("trTransferNumberTooltip", MainWindow.resourcemanagerreport.GetString("trTransferNumberTooltip")));
            paramarr.Add(new ReportParameter("trRecepient", MainWindow.resourcemanagerreport.GetString("trRecepient")));
            paramarr.Add(new ReportParameter("trPaymentTypeTooltip", MainWindow.resourcemanagerreport.GetString("trPaymentTypeTooltip")));
            paramarr.Add(new ReportParameter("trDate", MainWindow.resourcemanagerreport.GetString("trDate")));
            paramarr.Add(new ReportParameter("trCashTooltip", MainWindow.resourcemanagerreport.GetString("trCashTooltip")));
            paramarr.Add(new ReportParameter("accuracy", MainWindow.accuracy));
            paramarr.Add(new ReportParameter("trUnKnown", MainWindow.resourcemanagerreport.GetString("trUnKnown")));
            paramarr.Add(new ReportParameter("trCashCustomer", MainWindow.resourcemanagerreport.GetString("trCashCustomer")));
    
            DateFormConv(paramarr);


            foreach (var c in cash)
            {

                c.cash = decimal.Parse(SectionData.DecTostring(c.cash));
                // c.notes = SectionData.DecTostring(c.cash);
                c.agentName = AgentUnKnownConvert(c.agentId,c.side,c.agentName);
              
            }
            rep.DataSources.Add(new ReportDataSource("DataSetBankAcc", cash));
        }

        public static void receivedAccReport(IEnumerable<CashTransfer> cash, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {

            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            foreach (var c in cash)
            {

                c.cash = decimal.Parse(SectionData.DecTostring(c.cash));
            }
            DateFormConv(paramarr);
            AccountSideConv(paramarr);

            cashTransTypeConv(paramarr);
            cashTransferProcessTypeConv(paramarr);

            paramarr.Add(new ReportParameter("trTransferNumberTooltip", MainWindow.resourcemanagerreport.GetString("trTransferNumberTooltip")));
            paramarr.Add(new ReportParameter("trDepositor", MainWindow.resourcemanagerreport.GetString("trDepositor")));
            paramarr.Add(new ReportParameter("trPaymentTypeTooltip", MainWindow.resourcemanagerreport.GetString("trPaymentTypeTooltip")));
            paramarr.Add(new ReportParameter("trDate", MainWindow.resourcemanagerreport.GetString("trDate")));
            paramarr.Add(new ReportParameter("trCashTooltip", MainWindow.resourcemanagerreport.GetString("trCashTooltip")));
            paramarr.Add(new ReportParameter("accuracy", MainWindow.accuracy));
            paramarr.Add(new ReportParameter("trUnKnown", MainWindow.resourcemanagerreport.GetString("trUnKnown")));
            paramarr.Add(new ReportParameter("trCashCustomer", MainWindow.resourcemanagerreport.GetString("trCashCustomer")));

            rep.DataSources.Add(new ReportDataSource("DataSetBankAcc", cash));
        }

        public static void posAccReport(IEnumerable<CashTransfer> cash, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var c in cash)
            {

                c.cash = decimal.Parse(SectionData.DecTostring(c.cash));
            }

            paramarr.Add(new ReportParameter("trTransferNumberTooltip", MainWindow.resourcemanagerreport.GetString("trTransferNumberTooltip")));
            paramarr.Add(new ReportParameter("trCreator", MainWindow.resourcemanagerreport.GetString("trCreator")));
            paramarr.Add(new ReportParameter("trStatus", MainWindow.resourcemanagerreport.GetString("trStatus")));
            paramarr.Add(new ReportParameter("trDate", MainWindow.resourcemanagerreport.GetString("trDate")));
            paramarr.Add(new ReportParameter("trCashTooltip", MainWindow.resourcemanagerreport.GetString("trCashTooltip")));
            paramarr.Add(new ReportParameter("trConfirmed", MainWindow.resourcemanagerreport.GetString("trConfirmed")));
            paramarr.Add(new ReportParameter("trCanceled", MainWindow.resourcemanagerreport.GetString("trCanceled")));
            paramarr.Add(new ReportParameter("trWaiting", MainWindow.resourcemanagerreport.GetString("trWaiting")));

            DateFormConv(paramarr);

            rep.DataSources.Add(new ReportDataSource("DataSetBankAcc", cash));
        }

        public static void posAccReportSTS(IEnumerable<CashTransfer> cash, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            posAccReport(cash, rep, reppath, paramarr);
            paramarr.Add(new ReportParameter("trNum", MainWindow.resourcemanagerreport.GetString("trNo")));

            paramarr.Add(new ReportParameter("trAccoutant", MainWindow.resourcemanagerreport.GetString("trAccoutant")));
            paramarr.Add(new ReportParameter("trAmount", MainWindow.resourcemanagerreport.GetString("trAmount")));



        }
        public string posTransfersStatusConverter(byte isConfirm1, byte isConfirm2)
        {

            if ((isConfirm1 == 1) && (isConfirm2 == 1))
                return MainWindow.resourcemanager.GetString("trConfirmed");
            else if ((isConfirm1 == 2) || (isConfirm2 == 2))
                return MainWindow.resourcemanager.GetString("trCanceled");
            else
                return MainWindow.resourcemanager.GetString("trWaiting");
        }
        public static void invItem(IEnumerable<InventoryItemLocation> itemLocations, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            rep.DataSources.Add(new ReportDataSource("DataSetInvItemLocation", itemLocations));
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
        }
        public static void section(IEnumerable<Section> sections, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetSection", sections));
        }
        public static void location(IEnumerable<Location> locations, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetLocation", locations));
        }
        public static void itemLocation(IEnumerable<ItemLocation> itemLocations, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemLocation", itemLocations));
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
        }
        public static void bankReport(IEnumerable<Bank> banksQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            paramarr.Add(new ReportParameter("trBankName", MainWindow.resourcemanagerreport.GetString("trBankName")));
            paramarr.Add(new ReportParameter("trAccNumber", MainWindow.resourcemanagerreport.GetString("trAccNumber")));
            paramarr.Add(new ReportParameter("trAddress", MainWindow.resourcemanagerreport.GetString("trAddress")));
            paramarr.Add(new ReportParameter("trMobile", MainWindow.resourcemanagerreport.GetString("trMobile")));
         



            rep.DataSources.Add(new ReportDataSource("DataSetBank", banksQuery));

        }
        public static void ErrorsReport(IEnumerable<ErrorClass> Query, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetError", Query));
        }

        public static void couponReport(IEnumerable<Coupon> CouponQuery2, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {

            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var c in CouponQuery2)
            {
                 
               c.discountValue = decimal.Parse(DiscountConvert(c.discountType.ToString(), c.discountValue));

                c.invMin = decimal.Parse(SectionData.DecTostring(c.invMin));
                c.invMax = decimal.Parse(SectionData.DecTostring(c.invMax));
              
                string state = "";

                if ((c.isActive == 1) && ((c.endDate > DateTime.Now) || (c.endDate == null)) && ((c.quantity == 0) || (c.quantity > 0 && c.remainQ != 0)))
                    state = MainWindow.resourcemanager.GetString("trValid");
                else
                    state = MainWindow.resourcemanager.GetString("trExpired");

                c.state = state;

            }

            rep.DataSources.Add(new ReportDataSource("DataSetCoupon", CouponQuery2));
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trCoupon")));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trDiscount", MainWindow.resourcemanagerreport.GetString("trValue")));
            paramarr.Add(new ReportParameter("trQuantity", MainWindow.resourcemanagerreport.GetString("trQuantity")));
            paramarr.Add(new ReportParameter("trRemainQ", MainWindow.resourcemanagerreport.GetString("trRemainQuantity")));
            paramarr.Add(new ReportParameter("trEndDate", MainWindow.resourcemanagerreport.GetString("trvalidity")));
            paramarr.Add(new ReportParameter("trUnlimited", MainWindow.resourcemanagerreport.GetString("trUnlimited")));
        }
        public static void couponExportReport(LocalReport rep, string reppath, List<ReportParameter> paramarr, string barcode)
        {

            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            ReportCls repcls = new ReportCls();


            paramarr.Add(new ReportParameter("invNumber", barcode));
            paramarr.Add(new ReportParameter("barcodeimage", "file:\\" + repcls.BarcodeToImage(barcode, "barcode")));

        }

        public static void packageReport(IEnumerable<Item> packageQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();


            rep.DataSources.Add(new ReportDataSource("DataSetItem", packageQuery));
            //    paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trPackageItems")));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trPackage")));
            paramarr.Add(new ReportParameter("trDetails", MainWindow.resourcemanagerreport.GetString("trDetails")));
            paramarr.Add(new ReportParameter("trCategory", MainWindow.resourcemanagerreport.GetString("trCategorie")));

        }
        public static void serviceReport(IEnumerable<Item> serviceQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();


            rep.DataSources.Add(new ReportDataSource("DataSetItem", serviceQuery));
            //    paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));trTheService trTheServices
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trTheServices")));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trTheService")));
            paramarr.Add(new ReportParameter("trDetails", MainWindow.resourcemanagerreport.GetString("trDetails")));
            paramarr.Add(new ReportParameter("trCategory", MainWindow.resourcemanagerreport.GetString("trCategorie")));

        }
        public static void offerReport(IEnumerable<Offer> OfferQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var o in OfferQuery)
            {

             
                o.discountValue = decimal.Parse(DiscountConvert(o.discountType.ToString(),o.discountValue));
            }

            rep.DataSources.Add(new ReportDataSource("DataSetOffer", OfferQuery));
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trDiscount", MainWindow.resourcemanagerreport.GetString("trValue")));
            paramarr.Add(new ReportParameter("trStartDate", MainWindow.resourcemanagerreport.GetString("trStartDate")));
            paramarr.Add(new ReportParameter("trEndDate", MainWindow.resourcemanagerreport.GetString("trEndDate")));



        }
        public static void cardReport(IEnumerable<Card> cardsQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            rep.DataSources.Add(new ReportDataSource("DataSetCard", cardsQuery));
        }
        public static void shippingReport(IEnumerable<ShippingCompanies> shippingCompanies, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in shippingCompanies)
            {
                r.RealDeliveryCost = decimal.Parse(SectionData.DecTostring(r.RealDeliveryCost));
                r.deliveryCost = decimal.Parse(SectionData.DecTostring(r.deliveryCost));
                r.deliveryType = deliveryTypeConvert(r.deliveryType);
            }
                paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trRealDeliveryCost", MainWindow.resourcemanagerreport.GetString("trRealDeliveryCost")));
            paramarr.Add(new ReportParameter("trDeliveryCost", MainWindow.resourcemanagerreport.GetString("trDeliveryCost")));
            paramarr.Add(new ReportParameter("trDeliveryType", MainWindow.resourcemanagerreport.GetString("trDeliveryType")));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trShippingCompanies")));
            rep.DataSources.Add(new ReportDataSource("DataSetShipping", shippingCompanies));
        }
        public static string deliveryTypeConvert(string deliveryType)
        {
            switch (deliveryType)
            {
                case "local": return MainWindow.resourcemanagerreport.GetString("trLocaly");
                //break;
                case "com": return MainWindow.resourcemanagerreport.GetString("trShippingCompany");
                //break;
                default: return MainWindow.resourcemanagerreport.GetString("");
                    //break;
            }

        }
        public static string itemTypeConverter(string value)
        {
            string s = "";
            switch (value)
            {
                case "n": s = MainWindow.resourcemanagerreport.GetString("trNormals"); break;
                case "d": s = MainWindow.resourcemanagerreport.GetString("trHaveExpirationDates"); break;
                case "sn": s = MainWindow.resourcemanagerreport.GetString("trHaveSerialNumbers"); break;
                case "sr": s = MainWindow.resourcemanagerreport.GetString("trServices"); break;
                case "p": s = MainWindow.resourcemanagerreport.GetString("trPackages"); break;
            }

            return s;
        }
        public static string BranchStoreConverter(string type)
        {
            string s = "";
            switch (type)
            {
                case "b": s = MainWindow.resourcemanagerreport.GetString("tr_Branch"); break;
                case "s": s = MainWindow.resourcemanagerreport.GetString("tr_Store"); break;

            }

            return s;
        }
        public static void PurStsReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in tempquery)
            {
                //   r.CopdiscountValue = decimal.Parse(SectionData.DecTostring(r.CopdiscountValue));
                r.CopdiscountValue = decimal.Parse(DiscountConvert(r.CopdiscountType.ToString(), r.CopdiscountValue));
                r.couponTotalValue = decimal.Parse(SectionData.DecTostring(r.couponTotalValue));//
                                                                                                //  r.OdiscountValue = decimal.Parse(SectionData.DecTostring(r.OdiscountValue));
                r.OdiscountValue = decimal.Parse(DiscountConvert(r.OdiscountType, r.OdiscountValue));


                r.offerTotalValue = decimal.Parse(SectionData.DecTostring(r.offerTotalValue));
                r.ITprice = decimal.Parse(SectionData.DecTostring(r.ITprice));
                r.price = decimal.Parse(SectionData.DecTostring(r.price));
                r.subTotal = decimal.Parse(SectionData.DecTostring(r.subTotal));
                r.totalNet = decimal.Parse(SectionData.DecTostring(r.totalNet));
                r.discountValue = decimal.Parse(DiscountConvert(r.discountType, r.discountValue));
                r.tax = decimal.Parse(SectionData.PercentageDecTostring(r.tax));
                if (r.itemAvg != null)
                {
                    // r.itemAvg = double.Parse(SectionData.DecTostring(decimal.Parse(r.itemAvg.ToString())));
                    r.ITnotes = SectionData.DecTostring(decimal.Parse(r.itemAvg.ToString()));
                    r.itemAvg = double.Parse(r.ITnotes);
                }

            }
            rep.DataSources.Add(new ReportDataSource("DataSetITinvoice", tempquery));
        }
        public static string DiscountConvert(string type, decimal? value)
        {
            if (value != null)
            {
                decimal num = (decimal)value;
                string s = num.ToString();

                switch (MainWindow.accuracy)
                {
                    case "0":
                        s = string.Format("{0:F0}", num);
                        break;
                    case "1":
                        s = string.Format("{0:F1}", num);
                        break;
                    case "2":
                        s = string.Format("{0:F2}", num);
                        break;
                    case "3":
                        s = string.Format("{0:F3}", num);
                        break;
                    default:
                        s = string.Format("{0:F1}", num);
                        break;
                }


                if (type == "2")
                {
                    string sdc = string.Format("{0:G29}", decimal.Parse(s));
                    return sdc;
                }
                else
                {

                    return s;
                }
            }
            else
            {
                return "0";
            }

        }
        public static void saleitemStsReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {

            itemTypeConv(paramarr);
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            PurStsReport(tempquery, rep, reppath);

        }

        public static void SalePromoStsReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            PurStsReport(tempquery, rep, reppath);
            paramarr.Add(new ReportParameter("Currency", MainWindow.Currency));
            itemTransferDiscountTypeConv(paramarr);
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));

            /*
             =IIF(Fields!CopdiscountType.Value="2",
Parameters!trPercentageDiscount.Value,
Parameters!trValueDiscount.Value)
             * */
        }
        public static void itemTransferDiscountTypeConv(List<ReportParameter> paramarr)
        {

            paramarr.Add(new ReportParameter("trValueDiscount", MainWindow.resourcemanagerreport.GetString("trValueDiscount")));
            paramarr.Add(new ReportParameter("trPercentageDiscount", MainWindow.resourcemanagerreport.GetString("trPercentageDiscount")));


        }

        public static void itemTypeConv(List<ReportParameter> paramarr)
        {
            paramarr.Add(new ReportParameter("trNormal", MainWindow.resourcemanagerreport.GetString("trNormal")));
            paramarr.Add(new ReportParameter("trHaveExpirationDate", MainWindow.resourcemanagerreport.GetString("trHaveExpirationDate")));
            paramarr.Add(new ReportParameter("trHaveSerialNumber", MainWindow.resourcemanagerreport.GetString("trHaveSerialNumber")));
            paramarr.Add(new ReportParameter("trService", MainWindow.resourcemanagerreport.GetString("trService")));
            paramarr.Add(new ReportParameter("trPackage", MainWindow.resourcemanagerreport.GetString("trPackage")));
        }
        //clsReports.SaleInvoiceStsReport(itemTransfers, rep, reppath, paramarr);

        public static void SaleInvoiceStsReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            PurStsReport(tempquery, rep, reppath);
            paramarr.Add(new ReportParameter("isTax", MainWindow.invoiceTax_bool.ToString()));
            itemTransferInvTypeConv(paramarr);

        }

        public static void SaledailyReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            string date = "";
            PurStsReport(tempquery, rep, reppath);
            if (tempquery == null || tempquery.Count() == 0)
            {
                date = "";
            }
            else
            {
                date = SectionData.DateToString(tempquery.FirstOrDefault().updateDate);
            }
            paramarr.Add(new ReportParameter("isTax", MainWindow.invoiceTax_bool.ToString()));
            paramarr.Add(new ReportParameter("invDate", date));

            paramarr.Add(new ReportParameter("trPaymentMethodsheader", MainWindow.resourcemanagerreport.GetString("trPaymentMethods")));

            paramarr.Add(new ReportParameter("trCash", MainWindow.resourcemanagerreport.GetString("trCash")));
            paramarr.Add(new ReportParameter("trDocument", MainWindow.resourcemanagerreport.GetString("trDocument")));
            paramarr.Add(new ReportParameter("trCheque", MainWindow.resourcemanagerreport.GetString("trCheque")));
            paramarr.Add(new ReportParameter("trCredit", MainWindow.resourcemanagerreport.GetString("trCredit")));
            paramarr.Add(new ReportParameter("trMultiplePayment", MainWindow.resourcemanagerreport.GetString("trMultiplePayment")));

            itemTransferInvTypeConv(paramarr);

        }
        public static void ProfitReport(IEnumerable<ItemUnitInvoiceProfit> tempquery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in tempquery)
            {

                r.totalNet = decimal.Parse(SectionData.DecTostring(r.totalNet));
                r.invoiceProfit = decimal.Parse(SectionData.DecTostring(r.invoiceProfit));
                r.itemProfit = decimal.Parse(SectionData.DecTostring(r.itemProfit));
                r.itemunitProfit = decimal.Parse(SectionData.DecTostring(r.itemunitProfit));

            }
            rep.DataSources.Add(new ReportDataSource("DataSetProfit", tempquery));
            paramarr.Add(new ReportParameter("title", MainWindow.resourcemanagerreport.GetString("trProfits")));
            paramarr.Add(new ReportParameter("Currency", MainWindow.Currency));
            itemTransferInvTypeConv(paramarr);

        }

        public static void AccTaxReport(IEnumerable<ItemTransferInvoiceTax> invoiceItems, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetITinvoice", invoiceItems));
            paramarr.Add(new ReportParameter("trNum", MainWindow.resourcemanagerreport.GetString("trNo")));// tt
            paramarr.Add(new ReportParameter("trDate", MainWindow.resourcemanagerreport.GetString("trDate")));
            paramarr.Add(new ReportParameter("trBranch", MainWindow.resourcemanagerreport.GetString("trBranch")));
            paramarr.Add(new ReportParameter("trQTR", MainWindow.resourcemanagerreport.GetString("trQTR")));
            paramarr.Add(new ReportParameter("trTotal", MainWindow.resourcemanagerreport.GetString("trTotal")));
            paramarr.Add(new ReportParameter("trTaxValue", MainWindow.resourcemanagerreport.GetString("trTaxValue")));
            paramarr.Add(new ReportParameter("trTaxPercentage", MainWindow.resourcemanagerreport.GetString("trTaxPercentage")));
            paramarr.Add(new ReportParameter("trTotalInvoice", MainWindow.resourcemanagerreport.GetString("trTotalInvoice")));
            paramarr.Add(new ReportParameter("trItemUnit", MainWindow.resourcemanagerreport.GetString("trItemUnit")));
            paramarr.Add(new ReportParameter("trOnItem", MainWindow.resourcemanagerreport.GetString("trOnItem")));
            paramarr.Add(new ReportParameter("trPrice", MainWindow.resourcemanagerreport.GetString("trPrice")));

            paramarr.Add(new ReportParameter("trSum", MainWindow.resourcemanagerreport.GetString("trTotalTax")));
            foreach (var r in invoiceItems)
            {
                r.OneItemPriceNoTax = decimal.Parse(SectionData.DecTostring(r.OneItemPriceNoTax));
                r.subTotalNotax = decimal.Parse(SectionData.DecTostring(r.subTotalNotax));//
                r.ItemTaxes = decimal.Parse(SectionData.PercentageDecTostring(r.ItemTaxes));
                r.itemUnitTaxwithQTY = decimal.Parse(SectionData.DecTostring(r.itemUnitTaxwithQTY));
                r.subTotalTax = decimal.Parse(SectionData.DecTostring(r.subTotalTax));

                r.totalNoTax = decimal.Parse(SectionData.DecTostring(r.totalNoTax));
                r.tax = decimal.Parse(SectionData.PercentageDecTostring(r.tax));
                r.invTaxVal = decimal.Parse(SectionData.DecTostring(r.invTaxVal));
                r.totalNet = decimal.Parse(SectionData.DecTostring(r.totalNet));

            }
            paramarr.Add(new ReportParameter("Currency", MainWindow.Currency));

        }
        public static string ReportTabTitle(string firstTitle, string secondTitle)
        {
            string trtext = "";
            //////////////////////////////////////////////////////////////////////////////
            if (firstTitle == "invoice")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trInvoices");
            else if (firstTitle == "quotation")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trQuotations");
            else if (firstTitle == "promotion")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trThePromotion");
            else if (firstTitle == "internal")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trInternal");
            else if (firstTitle == "external")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trExternal");
            else if (firstTitle == "banksReport")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trBanks");
            else if (firstTitle == "destroied")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trDestructives");
            else if (firstTitle == "usersReport")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trUsers");
            else if (firstTitle == "storageReports")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trStorage");
            else if (firstTitle == "stocktaking")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trStocktaking");
            else if (firstTitle == "stock")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trStock");
            else if (firstTitle == "purchaseOrders")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trPurchaseOrders");
            else if (firstTitle == "saleOrders")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trSalesOrders");

            else if (firstTitle == "saleItems" || firstTitle == "purchaseItem")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trItems");
            else if (firstTitle == "recipientReport")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trReceived");
            else if (firstTitle == "accountStatement")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trAccountStatement");
            else if (firstTitle == "paymentsReport")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trPayments");
            else if (firstTitle == "posReports")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trPOS");
            else if (firstTitle == "dailySalesStatistic")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trDailySales");
            else if (firstTitle == "accountProfits")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trProfits");
            else if (firstTitle == "accountFund")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trCashBalance");
            else if (firstTitle == "quotations")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trQTReport");
            else if (firstTitle == "transfers")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trTransfers");
            else if (firstTitle == "fund")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trCashBalance");
            else if (firstTitle == "DirectEntry")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trDirectEntry");
            else if (firstTitle == "tax")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trTax");
            else if (firstTitle == "closing")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trDailyClosing");
            else if (firstTitle == "orders")
                firstTitle = MainWindow.resourcemanagerreport.GetString("trOrderreport");

            //trCashBalance trDirectEntry
            //trTransfers administrativePull operations
            //////////////////////////////////////////////////////////////////////////////

            if (secondTitle == "branch")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trBranches");
            else if (secondTitle == "pos")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trPOSs");
            else if (secondTitle == "vendors" || secondTitle == "vendor")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trVendors");
            else if (secondTitle == "customers" || secondTitle == "customer")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trCustomers");
            else if (secondTitle == "users" || secondTitle == "user")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trUsers");
            else if (secondTitle == "items" || secondTitle == "item")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trItems");
            else if (secondTitle == "coupon")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trCoupons");
            else if (secondTitle == "offers")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trOffer");
            else if (secondTitle == "invoice")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trInvoices");
            else if (secondTitle == "order")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trOrders");
            else if (secondTitle == "quotation")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trQTReport");
            else if (secondTitle == "operator")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trOperator");
            else if (secondTitle == "payments")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trPayments");
            else if (secondTitle == "recipient")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trReceived");
            else if (secondTitle == "destroied")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trDestructives");
            else if (secondTitle == "agent")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trCustomers");
            else if (secondTitle == "stock")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trStock");
            else if (secondTitle == "external")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trExternal");
            else if (secondTitle == "internal")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trInternal");
            else if (secondTitle == "stocktaking")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trStocktaking");
            else if (secondTitle == "archives")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trArchive");
            else if (secondTitle == "shortfalls")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trShortages");
            else if (secondTitle == "location")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trLocation");
            else if (secondTitle == "collect")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trCollect");
            else if (secondTitle == "shipping")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trShipping");
            else if (secondTitle == "salary")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trSalary");
            else if (secondTitle == "generalExpenses")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trGeneralExpenses");
            else if (secondTitle == "administrativePull")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trAdministrativePull");
            else if (secondTitle == "AdministrativeDeposit")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trAdministrativeDeposit");
            else if (secondTitle == "BestSeller")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trBestSeller");
            else if (secondTitle == "MostPurchased")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trMostPurchased");
            else if (secondTitle == "cash")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trCash_");
            else if (secondTitle == "operations")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trOperations");
            else if (secondTitle == "pull")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trPull");
            else if (secondTitle == "deposit")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trDeposit");
            else if (secondTitle == "delivered")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trDelivered");
            else if (secondTitle == "indelivery")
                secondTitle = MainWindow.resourcemanagerreport.GetString("trInDelivery");

            //trPull
            //////////////////////////////////////////////////////////////////////////////

            trtext = firstTitle + " / " + secondTitle;
            return trtext;
        }
        public static void PurInvStsReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {


            PurStsReport(tempquery, rep, reppath);
            itemTransferInvTypeConv(paramarr);
            paramarr.Add(new ReportParameter("isTax", MainWindow.invoiceTax_bool.ToString()));


        }

        public static void PurOrderStsReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            PurStsReport(tempquery, rep, reppath);
            itemTransferInvTypeConv(paramarr);

        }

        public static void posReport(IEnumerable<Pos> possQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            paramarr.Add(new ReportParameter("trPosName", MainWindow.resourcemanagerreport.GetString("trPosName")));
            paramarr.Add(new ReportParameter("trPosCode", MainWindow.resourcemanagerreport.GetString("trPosCode")));
            paramarr.Add(new ReportParameter("trBranchName", MainWindow.resourcemanagerreport.GetString("trBranchName")));
            paramarr.Add(new ReportParameter("trNote", MainWindow.resourcemanagerreport.GetString("trNote")));


            rep.DataSources.Add(new ReportDataSource("DataSetPos", possQuery));
        }

        public static void customerReport(IEnumerable<Agent> customersQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trCompany", MainWindow.resourcemanagerreport.GetString("trCompany")));
            paramarr.Add(new ReportParameter("trMobile", MainWindow.resourcemanagerreport.GetString("trMobile")));

            rep.DataSources.Add(new ReportDataSource("AgentDataSet", customersQuery));
        }

        public static void branchReport(IEnumerable<Branch> branchQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trAddress", MainWindow.resourcemanagerreport.GetString("trAddress")));
            paramarr.Add(new ReportParameter("trNote", MainWindow.resourcemanagerreport.GetString("trNote")));

            rep.DataSources.Add(new ReportDataSource("DataSetBranches", branchQuery));
        }

        public static void userReport(IEnumerable<User> usersQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trJob", MainWindow.resourcemanagerreport.GetString("trJob")));
            paramarr.Add(new ReportParameter("trWorkHours", MainWindow.resourcemanagerreport.GetString("trWorkHours")));
            paramarr.Add(new ReportParameter("trNote", MainWindow.resourcemanagerreport.GetString("trNote")));

            rep.DataSources.Add(new ReportDataSource("DataSetUser", usersQuery));
        }

        public static void vendorReport(IEnumerable<Agent> vendorsQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trCompany", MainWindow.resourcemanagerreport.GetString("trCompany")));
            paramarr.Add(new ReportParameter("trMobile", MainWindow.resourcemanagerreport.GetString("trMobile")));
            rep.DataSources.Add(new ReportDataSource("AgentDataSet", vendorsQuery));
        }

        public static void storeReport(IEnumerable<Branch> storesQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetBranches", storesQuery));
        }
        public static void purchaseInvoiceReport(List<ItemTransfer> invoiceItems, LocalReport rep, string reppath)
        {

            foreach (var i in invoiceItems)
            {
                i.price = decimal.Parse(SectionData.DecTostring(i.price));


            }
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", invoiceItems));
            rep.EnableExternalImages = true;

        }
        public static void storage(IEnumerable<Storage> storageQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in storageQuery)
            {
                if (r.startDate != null)
                    r.startDate = DateTime.Parse(SectionData.DateToString(r.startDate));//
                if (r.endDate != null)
                    r.endDate = DateTime.Parse(SectionData.DateToString(r.endDate));
                //r.inventoryDate = DateTime.Parse(SectionData.DateToString(r.inventoryDate));
                //r.IupdateDate = DateTime.Parse(SectionData.DateToString(r.IupdateDate));

                //r.diffPercentage = decimal.Parse(SectionData.DecTostring(r.diffPercentage));
                r.storageCostValue = decimal.Parse(SectionData.DecTostring(r.storageCostValue));
            }
            rep.DataSources.Add(new ReportDataSource("DataSetStorage", storageQuery));
        }

        /* free zone
         =iif((Fields!section.Value="FreeZone")And(Fields!location.Value="0-0-0"),
"-",Fields!section.Value+"-"+Fields!location.Value)
         * */

        public static void storageStock(IEnumerable<Storage> storageQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            storage(storageQuery, rep, reppath);
            DateFormConv(paramarr);


        }
        // stocktaking
        public static void StocktakingArchivesReport(IEnumerable<InventoryClass> Query, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            foreach (var r in Query)
            {

                //r.inventoryDate = DateTime.Parse(SectionData.DateToString(r.inventoryDate));
                //r.IupdateDate = DateTime.Parse(SectionData.DateToString(r.IupdateDate));

                r.diffPercentage = decimal.Parse(SectionData.DecTostring(r.diffPercentage));
                //r.storageCostValue = decimal.Parse(SectionData.DecTostring(r.storageCostValue));
            }


            rep.DataSources.Add(new ReportDataSource("DataSetInventoryClass", Query));
            DateFormConv(paramarr);
            InventoryTypeConv(paramarr);
        }

        public static void StocktakingShortfallsReport(IEnumerable<ItemTransferInvoice> Query, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();

            //foreach (var r in Query)
            //{
            //    //if (r.startDate != null)
            //    //    r.startDate = DateTime.Parse(SectionData.DateToString(r.startDate));//
            //    //if (r.endDate != null)
            //    //    r.endDate = DateTime.Parse(SectionData.DateToString(r.endDate));

            //    //r.inventoryDate = DateTime.Parse(SectionData.DateToString(r.inventoryDate));
            //    //r.IupdateDate = DateTime.Parse(SectionData.DateToString(r.IupdateDate));

            //    //r.diffPercentage = decimal.Parse(SectionData.DecTostring(r.diffPercentage));
            //    //r.storageCostValue = decimal.Parse(SectionData.DecTostring(r.storageCostValue));
            //}


            rep.DataSources.Add(new ReportDataSource("DataSetItemTransferInvoice", Query));
            DateFormConv(paramarr);
            InventoryTypeConv(paramarr);

        }
        /*
        = Switch(Fields!inventoryType.Value="a",Parameters!trArchived.Value
,Fields!inventoryType.Value="n",Parameters!trSaved.Value
,Fields!inventoryType.Value="d",Parameters!trDraft.Value
)

         * */
        //

        public static void cashTransferStsBank(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            cashTransferSts(cashTransfers, rep, reppath);
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("trPull", MainWindow.resourcemanagerreport.GetString("trPull")));
            paramarr.Add(new ReportParameter("trDeposit", MainWindow.resourcemanagerreport.GetString("trDeposit")));
            paramarr.Add(new ReportParameter("trNo", MainWindow.resourcemanagerreport.GetString("trNo")));

        }
        public static string  processTypeAndCardConverter(string processType, string cardName )
        {
            string pType =  processType ;
            string cName = cardName;

            switch (pType)
            {
                case "cash": return MainWindow.resourcemanagerreport.GetString("trCash");
                //break;
                case "doc": return MainWindow.resourcemanagerreport.GetString("trDocument");
                //break;
                case "cheque": return MainWindow.resourcemanagerreport.GetString("trCheque");
                //break;
                case "balance": return MainWindow.resourcemanagerreport.GetString("trCredit");
                //break;
                case "card": return cName;
                //break;
                case "inv": return "-";
                case "multiple": return MainWindow.resourcemanagerreport.GetString("trMultiplePayment");

                //break;
                default: return pType;
                    //break;
            }

        }
        public static string StsStatementPaymentConvert(string value)
        {
            string s = "";
            switch (value)
            {
                case "cash":
                    s = MainWindow.resourcemanagerreport.GetString("trCash");
                    break;
                case "doc":
                    s = MainWindow.resourcemanagerreport.GetString("trDocument");
                    break;
                case "cheque":
                    s = MainWindow.resourcemanagerreport.GetString("trCheque");
                    break;
                case "balance":
                    s = MainWindow.resourcemanagerreport.GetString("trCredit");
                    break;
                case "card":
                    s = MainWindow.resourcemanagerreport.GetString("trAnotherPaymentMethods");
                    break;
                case "inv":
                    s = MainWindow.resourcemanagerreport.GetString("trInv");
                    break;
                default:
                    s = value;
                    break;


            }
            return s;
        }
        public static void cashTransferStsStatement(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            cashTransferStatSts(cashTransfers, rep, reppath);

            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("trNo", MainWindow.resourcemanagerreport.GetString("trNo")));

        }
        public static void cashTransferStsPayment(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            cashTransferSts(cashTransfers, rep, reppath);

            cashTransferProcessTypeConv(paramarr);
            DateFormConv(paramarr);
            paramarr.Add(new ReportParameter("trNo", MainWindow.resourcemanagerreport.GetString("trNo")));

        }
        public static void cashTransferStsPos(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            cashTransferSts(cashTransfers, rep, reppath);
            cashTransTypeConv(paramarr);
            DateFormConv(paramarr);

        }

        public static void cashTransferSts(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in cashTransfers)
            {
                r.updateDate = DateTime.Parse(SectionData.DateToString(r.updateDate));
                r.cash = decimal.Parse(SectionData.DecTostring(r.cash));
                r.agentName = AgentUnKnownConvert(r.agentId,r.side,r.agentName);
                r.agentCompany = AgentCompanyUnKnownConvert(r.agentId, r.side, r.agentCompany);

            }
            rep.DataSources.Add(new ReportDataSource("DataSetCashTransferSts", cashTransfers));
        }
        public static string AgentUnKnownConvert(int? agentId, string side, string agentName)
        {
            
            if (agentId == null)
            {
                if (side == "v")
                {
                    agentName = MainWindow.resourcemanagerreport.GetString("trUnKnown");
                }
                else if (side == "c")
                {
                    agentName = MainWindow.resourcemanagerreport.GetString("trCashCustomer");
                }
            }
            return agentName;

        }
        public static string AgentCompanyUnKnownConvert(int? agentId, string side, string agentCompany)
        {
            if (agentId == null)
            {
                agentCompany = MainWindow.resourcemanagerreport.GetString("trUnKnown");
                 
            }
            return agentCompany;
        }
        public static void cashTransferStatSts(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (CashTransferSts r in cashTransfers)
            {
                r.updateDate = DateTime.Parse(SectionData.DateToString(r.updateDate));
                r.cash = decimal.Parse(SectionData.DecTostring(r.cash));
             
                r.paymentreport = processTypeAndCardConverter(r.Description3, r.cardName);
             

            }
            rep.DataSources.Add(new ReportDataSource("DataSetCashTransferSts", cashTransfers));
        }

        public static void FundStsReport(IEnumerable<BalanceSTS> query, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in query)
            {

                r.balance = decimal.Parse(SectionData.DecTostring(r.balance));
            }
            rep.DataSources.Add(new ReportDataSource("DataSetBalanceSTS", query));
            paramarr.Add(new ReportParameter("title", MainWindow.resourcemanagerreport.GetString("trBalance")));
            paramarr.Add(new ReportParameter("Currency", MainWindow.Currency));


        }
        public static void ClosingStsReport(IEnumerable<POSOpenCloseModel> query, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in query)
            {
                r.cash = decimal.Parse(SectionData.DecTostring(r.cash));
                r.openCash = decimal.Parse(SectionData.DecTostring(r.openCash));

            }
            rep.DataSources.Add(new ReportDataSource("DataSetBalanceSTS", query));
            paramarr.Add(new ReportParameter("trNum", MainWindow.resourcemanagerreport.GetString("trNo.")));
            paramarr.Add(new ReportParameter("trPOS", MainWindow.resourcemanagerreport.GetString("trPOS")));
            paramarr.Add(new ReportParameter("trOpenDate", MainWindow.resourcemanagerreport.GetString("trOpenDate")));
            paramarr.Add(new ReportParameter("trOpenCash", MainWindow.resourcemanagerreport.GetString("trOpenCash")));
            paramarr.Add(new ReportParameter("trCloseDate", MainWindow.resourcemanagerreport.GetString("trCloseDate")));
            paramarr.Add(new ReportParameter("trCloseCash", MainWindow.resourcemanagerreport.GetString("trCloseCash")));

            paramarr.Add(new ReportParameter("Currency", MainWindow.Currency));


        }
        public static void ClosingOpStsReport(IEnumerable<OpenClosOperatinModel> query, LocalReport rep, string reppath, List<ReportParameter> paramarr, POSOpenCloseModel openclosrow)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in query)
            {
                r.cash = decimal.Parse(SectionData.DecTostring(r.cash));
                //  r.openCash = decimal.Parse(SectionData.DecTostring(r.openCash));
                r.notes = closingDescriptonConverter(r);


            }
            rep.DataSources.Add(new ReportDataSource("DataSetBalanceSTS", query));
            paramarr.Add(new ReportParameter("trNum", MainWindow.resourcemanagerreport.GetString("trNo")));
            paramarr.Add(new ReportParameter("trPOS", MainWindow.resourcemanagerreport.GetString("trPOS")));
            paramarr.Add(new ReportParameter("trOpenDate", MainWindow.resourcemanagerreport.GetString("trOpenDate")));
            paramarr.Add(new ReportParameter("trOpenCash", MainWindow.resourcemanagerreport.GetString("trOpenCash")));
            paramarr.Add(new ReportParameter("trCloseDate", MainWindow.resourcemanagerreport.GetString("trCloseDate")));
            paramarr.Add(new ReportParameter("trCloseCash", MainWindow.resourcemanagerreport.GetString("trCloseCash")));

            paramarr.Add(new ReportParameter("Currency", MainWindow.Currency));

            paramarr.Add(new ReportParameter("OpenDate", openclosrow.openDate.ToString()));
            paramarr.Add(new ReportParameter("OpenCash", SectionData.DecTostring(openclosrow.openCash)));
            paramarr.Add(new ReportParameter("CloseDate", openclosrow.updateDate.ToString()));
            paramarr.Add(new ReportParameter("CloseCash", SectionData.DecTostring(openclosrow.cash)));
            paramarr.Add(new ReportParameter("pos", openclosrow.branchName + " / " + openclosrow.posName));

            paramarr.Add(new ReportParameter("trNo", MainWindow.resourcemanagerreport.GetString("trNo.")));
            paramarr.Add(new ReportParameter("trDate", MainWindow.resourcemanagerreport.GetString("trDate")));
            paramarr.Add(new ReportParameter("trDescription", MainWindow.resourcemanagerreport.GetString("trDescription")));
            paramarr.Add(new ReportParameter("trCashTooltip", MainWindow.resourcemanagerreport.GetString("trCashTooltip")));



        }
        public static string closingDescriptonConverter(OpenClosOperatinModel s)
        {

            string name = "";
            switch (s.side)
            {
                case "bnd": break;
                case "v": name = MainWindow.resourcemanager.GetString("trVendor"); break;
                case "c": name = MainWindow.resourcemanager.GetString("trCustomer"); break;
                case "u": name = MainWindow.resourcemanager.GetString("trUser"); break;
                case "s": name = MainWindow.resourcemanager.GetString("trSalary"); break;
                case "e": name = MainWindow.resourcemanager.GetString("trGeneralExpenses"); break;
                case "m":
                    if (s.transType == "d")
                        name = MainWindow.resourcemanager.GetString("trAdministrativeDeposit");
                    if (s.transType == "p")
                        name = MainWindow.resourcemanager.GetString("trAdministrativePull");
                    break;
                case "sh": name = MainWindow.resourcemanager.GetString("trShippingCompany"); break;
                default: break;
            }

            if (!string.IsNullOrEmpty(s.agentName))
                name = name + " " + s.agentName;
            else if (!string.IsNullOrEmpty(s.usersName) && !string.IsNullOrEmpty(s.usersLName))
                name = name + " " + s.usersName + " " + s.usersLName;
            else if (!string.IsNullOrEmpty(s.shippingCompanyName))
                name = name + " " + s.shippingCompanyName;
            else if ((s.side != "e") && (s.side != "m"))
                name = name + " " + MainWindow.resourcemanager.GetString("trUnKnown");

            if (s.transType.Equals("p"))
            {
                if ((s.side.Equals("bn")) || (s.side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trPull") + " " +
                           MainWindow.resourcemanager.GetString("trFrom") + " " +
                           name;//receive
                }
                else if ((!s.side.Equals("bn")) || (!s.side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trPayment") + " " +
                           MainWindow.resourcemanager.GetString("trTo") + " " +
                           name;//دفع
                }
                else return "";
            }
            else if (s.transType.Equals("d"))
            {
                if ((s.side.Equals("bn")) || (s.side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trDeposit") + " " +
                           MainWindow.resourcemanager.GetString("trTo") + " " +
                           name;
                }
                else if ((!s.side.Equals("bn")) || (!s.side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trReceiptOperation") + " " +
                           MainWindow.resourcemanager.GetString("trFrom") + " " +
                           name;//قبض
                }
                else return "";
            }
            else return "";

        }
        public static void cashTransferStsRecipient(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            cashTransferSts(cashTransfers, rep, reppath);

            cashTransferProcessTypeConv(paramarr);
            DateFormConv(paramarr);
            paramarr.Add(new ReportParameter("trNo", MainWindow.resourcemanagerreport.GetString("trNo")));

        }
        public static void itemTransferInvoice(IEnumerable<ItemTransferInvoice> itemTransferInvoices, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemTransferInvoice", itemTransferInvoices));

        }
        public static void DateFormConv(List<ReportParameter> paramarr)
        {

            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
        }

        public static void InventoryTypeConv(List<ReportParameter> paramarr)
        {

            paramarr.Add(new ReportParameter("trArchived", MainWindow.resourcemanagerreport.GetString("trArchived")));
            paramarr.Add(new ReportParameter("trSaved", MainWindow.resourcemanagerreport.GetString("trSaved")));
            paramarr.Add(new ReportParameter("trDraft", MainWindow.resourcemanagerreport.GetString("trDraft")));
        }
        public static void cashTransTypeConv(List<ReportParameter> paramarr)
        {

            paramarr.Add(new ReportParameter("trPull", MainWindow.resourcemanagerreport.GetString("trPull")));
            paramarr.Add(new ReportParameter("trDeposit", MainWindow.resourcemanagerreport.GetString("trDeposit")));

        }

        public static void cashTransferProcessTypeConv(List<ReportParameter> paramarr)
        {
            paramarr.Add(new ReportParameter("trCash", MainWindow.resourcemanagerreport.GetString("trCash")));
            paramarr.Add(new ReportParameter("trDocument", MainWindow.resourcemanagerreport.GetString("trDocument")));
            paramarr.Add(new ReportParameter("trCheque", MainWindow.resourcemanagerreport.GetString("trCheque")));
            paramarr.Add(new ReportParameter("trCredit", MainWindow.resourcemanagerreport.GetString("trCredit")));
            paramarr.Add(new ReportParameter("trInv", MainWindow.resourcemanagerreport.GetString("trInv")));
            paramarr.Add(new ReportParameter("trCard", MainWindow.resourcemanagerreport.GetString("trCreditCard")));

        }
        public static void itemTransferInvTypeConv(List<ReportParameter> paramarr)
        {
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("trPurchaseInvoice", MainWindow.resourcemanagerreport.GetString("trPurchaseInvoice")));
            paramarr.Add(new ReportParameter("trPurchaseInvoiceWaiting", MainWindow.resourcemanagerreport.GetString("trPurchaseInvoiceWaiting")));
            paramarr.Add(new ReportParameter("trSalesInvoice", MainWindow.resourcemanagerreport.GetString("trSalesInvoice")));
            paramarr.Add(new ReportParameter("trSalesReturnInvoice", MainWindow.resourcemanagerreport.GetString("trSalesReturnInvoice")));
            paramarr.Add(new ReportParameter("trPurchaseReturnInvoice", MainWindow.resourcemanagerreport.GetString("trPurchaseReturnInvoice")));
            paramarr.Add(new ReportParameter("trPurchaseReturnInvoiceWaiting", MainWindow.resourcemanagerreport.GetString("trPurchaseReturnInvoiceWaiting")));
            paramarr.Add(new ReportParameter("trDraftPurchaseBill", MainWindow.resourcemanagerreport.GetString("trDraftPurchaseBill")));
            paramarr.Add(new ReportParameter("trSalesDraft", MainWindow.resourcemanagerreport.GetString("trSalesDraft")));
            paramarr.Add(new ReportParameter("trSalesReturnDraft", MainWindow.resourcemanagerreport.GetString("trSalesReturnDraft")));

            paramarr.Add(new ReportParameter("trSaleOrderDraft", MainWindow.resourcemanagerreport.GetString("trSaleOrderDraft")));
            paramarr.Add(new ReportParameter("trSaleOrder", MainWindow.resourcemanagerreport.GetString("trSaleOrder")));
            paramarr.Add(new ReportParameter("trPurchaceOrderDraft", MainWindow.resourcemanagerreport.GetString("trPurchaceOrderDraft")));
            paramarr.Add(new ReportParameter("trPurchaceOrder", MainWindow.resourcemanagerreport.GetString("trPurchaceOrder")));
            paramarr.Add(new ReportParameter("trQuotationsDraft", MainWindow.resourcemanagerreport.GetString("trQuotationsDraft")));
            paramarr.Add(new ReportParameter("trQuotations", MainWindow.resourcemanagerreport.GetString("trQuotations")));
            paramarr.Add(new ReportParameter("trDestructive", MainWindow.resourcemanagerreport.GetString("trDestructive")));
            paramarr.Add(new ReportParameter("trShortage", MainWindow.resourcemanagerreport.GetString("trShortage")));
            paramarr.Add(new ReportParameter("trImportDraft", MainWindow.resourcemanagerreport.GetString("trImportDraft")));
            paramarr.Add(new ReportParameter("trImport", MainWindow.resourcemanagerreport.GetString("trImport")));
            paramarr.Add(new ReportParameter("trImportOrder", MainWindow.resourcemanagerreport.GetString("trImportOrder")));
            paramarr.Add(new ReportParameter("trExportDraft", MainWindow.resourcemanagerreport.GetString("trExportDraft")));

            paramarr.Add(new ReportParameter("trExport", MainWindow.resourcemanagerreport.GetString("trExport")));

            paramarr.Add(new ReportParameter("trExportOrder", MainWindow.resourcemanagerreport.GetString("trExportOrder")));

        }
        public static void invoiceSideConv(List<ReportParameter> paramarr)
        {


            paramarr.Add(new ReportParameter("trVendor", MainWindow.resourcemanagerreport.GetString("trVendor")));
            paramarr.Add(new ReportParameter("trCustomer", MainWindow.resourcemanagerreport.GetString("trCustomer")));


        }
        public static void AccountSideConv(List<ReportParameter> paramarr)
        {

            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));

            paramarr.Add(new ReportParameter("trVendor", MainWindow.resourcemanagerreport.GetString("trVendor")));
            paramarr.Add(new ReportParameter("trCustomer", MainWindow.resourcemanagerreport.GetString("trCustomer")));
            paramarr.Add(new ReportParameter("trUser", MainWindow.resourcemanagerreport.GetString("trUser")));
            paramarr.Add(new ReportParameter("trSalary", MainWindow.resourcemanagerreport.GetString("trSalary")));
            paramarr.Add(new ReportParameter("trGeneralExpenses", MainWindow.resourcemanagerreport.GetString("trGeneralExpenses")));

            paramarr.Add(new ReportParameter("trAdministrativeDeposit", MainWindow.resourcemanagerreport.GetString("trAdministrativeDeposit")));

            paramarr.Add(new ReportParameter("trAdministrativePull", MainWindow.resourcemanagerreport.GetString("trAdministrativePull")));
            paramarr.Add(new ReportParameter("trShippingCompany", MainWindow.resourcemanagerreport.GetString("trShippingCompany")));


        }
        public static void itemTransferInvoiceExternal(IEnumerable<ItemTransferInvoice> itemTransferInvoices, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {



            itemTransferInvTypeConv(paramarr);
            invoiceSideConv(paramarr);

            itemTransferInvoice(itemTransferInvoices, rep, reppath);


        }
        public static void itemTransferInvoiceInternal(IEnumerable<ItemTransferInvoice> itemTransferInvoices, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            itemTransferInvTypeConv(paramarr);
            itemTransferInvoice(itemTransferInvoices, rep, reppath);

        }
        public static void itemTransferInvoiceDestroied(IEnumerable<ItemTransferInvoice> itemTransferInvoices, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            itemTransferInvoice(itemTransferInvoices, rep, reppath);
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));

        }
        public static void categoryReport(IEnumerable<Category> categoryQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in categoryQuery)
            {
                r.taxes = decimal.Parse(SectionData.DecTostring(r.taxes));
            }
            rep.DataSources.Add(new ReportDataSource("DataSetCategory", categoryQuery));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trCategories")));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trDetails", MainWindow.resourcemanagerreport.GetString("trDetails")));
        }
        //public static void itemReport(IEnumerable<Item> itemQuery, LocalReport rep, string reppath)
        //{
        //    rep.ReportPath = reppath;
        //    rep.EnableExternalImages = true;
        //    rep.DataSources.Clear();
        //    rep.DataSources.Add(new ReportDataSource("DataSetItem", itemQuery));

        //}
        public static void itemReport(IEnumerable<Item> _items, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (Item r in _items)
            {
                r.taxes = decimal.Parse(SectionData.DecTostring(r.taxes));
            }
            rep.DataSources.Add(new ReportDataSource("DataSetItem", _items));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trItems")));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("trCode")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trDetails", MainWindow.resourcemanagerreport.GetString("trDetails")));
            paramarr.Add(new ReportParameter("trCategory", MainWindow.resourcemanagerreport.GetString("trCategorie")));
        }
        public static void properyReport(IEnumerable<Property> propertyQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetProperty", propertyQuery));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trProperties")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trProperty")));
            paramarr.Add(new ReportParameter("trValues", MainWindow.resourcemanagerreport.GetString("trValues")));
        }
        public static void storageCostReport(IEnumerable<StorageCost> storageCostQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var s in storageCostQuery)
            {
                s.cost = decimal.Parse(SectionData.DecTostring(s.cost));
            }
            rep.DataSources.Add(new ReportDataSource("DataSetStorageCost", storageCostQuery));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trStorageCost")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trName")));
            paramarr.Add(new ReportParameter("trCost", MainWindow.resourcemanagerreport.GetString("trStorageCost")));

        }
        public static void unitReport(IEnumerable<Unit> unitQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetUnit", unitQuery));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trUnit")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("trUnitName")));
            paramarr.Add(new ReportParameter("trNotes", MainWindow.resourcemanagerreport.GetString("trNote")));

        }
        public static void inventoryReport(IEnumerable<InventoryItemLocation> invItemsLocations, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetInventory", invItemsLocations));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trStocktakingItems")));// tt
            paramarr.Add(new ReportParameter("trNum", MainWindow.resourcemanagerreport.GetString("trNo.")));
            paramarr.Add(new ReportParameter("trSec_Loc", MainWindow.resourcemanagerreport.GetString("trSectionLocation")));//
            //paramarr.Add(new ReportParameter("trItem_UnitName", MainWindow.resourcemanagerreport.GetString("trUnitName")+"-" + MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trItem_UnitName", MainWindow.resourcemanagerreport.GetString("trItemUnit")));
            paramarr.Add(new ReportParameter("trRealAmount", MainWindow.resourcemanagerreport.GetString("trRealAmount")));
            paramarr.Add(new ReportParameter("trInventoryAmount", MainWindow.resourcemanagerreport.GetString("trInventoryAmount")));
            paramarr.Add(new ReportParameter("trDestroyCount", MainWindow.resourcemanagerreport.GetString("trDestoryCount")));
        }


        public static void ItemsExportReport(IEnumerable<ItemTransfer> invoiceItems, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemsExport", invoiceItems));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trItemsImport/Export")));// tt
            paramarr.Add(new ReportParameter("trNum", MainWindow.resourcemanagerreport.GetString("trNum")));
            paramarr.Add(new ReportParameter("trItem", MainWindow.resourcemanagerreport.GetString("trItem")));
            paramarr.Add(new ReportParameter("trUnit", MainWindow.resourcemanagerreport.GetString("trUnit")));
            paramarr.Add(new ReportParameter("trAmount", MainWindow.resourcemanagerreport.GetString("trQuantity")));
        }
        public static void ReceiptPurchaseReport(IEnumerable<ItemTransfer> invoiceItems, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemsExport", invoiceItems));
            paramarr.Add(new ReportParameter("Title", MainWindow.resourcemanagerreport.GetString("trReceiptOfPurchasesBill")));// tt
            paramarr.Add(new ReportParameter("trNum", MainWindow.resourcemanagerreport.GetString("trNum")));
            paramarr.Add(new ReportParameter("trItem", MainWindow.resourcemanagerreport.GetString("trItem")));
            paramarr.Add(new ReportParameter("trUnit", MainWindow.resourcemanagerreport.GetString("trUnit")));
            paramarr.Add(new ReportParameter("trAmount", MainWindow.resourcemanagerreport.GetString("trQuantity")));
        }
        public static void itemLocation(IEnumerable<ItemLocation> itemLocations, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemLocation", itemLocations));
        }



    }
}
