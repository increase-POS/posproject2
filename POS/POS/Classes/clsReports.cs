﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            rep.DataSources.Add(new ReportDataSource("DataSetBond", bondsQuery));
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
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
            }
            paramarr.Add(new ReportParameter("trDelivered", MainWindow.resourcemanagerreport.GetString("trDelivered")));
            paramarr.Add(new ReportParameter("trInDelivery", MainWindow.resourcemanagerreport.GetString("trInDelivery")));
            rep.DataSources.Add(new ReportDataSource("DataSetInvoice", invoiceQuery));
        }
        public static void bankAccReport(IEnumerable<CashTransfer> cash, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
           
            foreach (var c in cash)
            {
                ///////////////////
                c.cash = decimal.Parse(SectionData.DecTostring(c.cash));
                string s ;
                switch (c.processType)
                {
                    case "cash": s = MainWindow.resourcemanager.GetString("trCash");
                    break;
                    case "doc": s = MainWindow.resourcemanager.GetString("trDocument");
                    break;
                    case "cheque": s = MainWindow.resourcemanager.GetString("trCheque");
                    break;
                    case "balance": s = MainWindow.resourcemanager.GetString("trCredit");
                    break;
                    default: s = c.processType;
                        break;
                }
                ///////////////////
                c.processType = s;
                string name = "";
                switch (c.side)
                {
                    case "bnd": break;
                    case "v": name = MainWindow.resourcemanager.GetString("trVendor"); break;
                    case "c": name = MainWindow.resourcemanager.GetString("trCustomer"); break;
                    case "u": name = MainWindow.resourcemanager.GetString("trUser"); break;
                    case "s": name = MainWindow.resourcemanager.GetString("trSalary"); break;
                    case "e": name = MainWindow.resourcemanager.GetString("trGeneralExpenses"); break;
                    case "m":
                        if (c.transType == "d")
                            name = MainWindow.resourcemanager.GetString("trAdministrativeDeposit");
                        if (c.transType == "p")
                            name = MainWindow.resourcemanager.GetString("trAdministrativePull");
                        break;
                    case "sh": name = MainWindow.resourcemanager.GetString("trShippingCompany"); break;
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
                if (c.transType.Equals("p")) type = MainWindow.resourcemanager.GetString("trPull");
                else type = MainWindow.resourcemanager.GetString("trDeposit");
                ////////////////////
                c.transType = type;
            }
            rep.DataSources.Add(new ReportDataSource("DataSetBankAcc", cash));
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
        public static void bankReport(IEnumerable<Bank> banksQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetBank", banksQuery));
        }

        public static void couponReport(IEnumerable<Coupon> CouponQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var c in CouponQuery)
            {
                c.discountValue = decimal.Parse(SectionData.DecTostring(c.discountValue));
                c.invMin = decimal.Parse(SectionData.DecTostring(c.invMin));
                c.invMax = decimal.Parse(SectionData.DecTostring(c.invMax));

            }

            rep.DataSources.Add(new ReportDataSource("DataSetCoupon", CouponQuery));
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trDiscount", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trQuantity", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trRemainQ", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trEndDate", MainWindow.resourcemanagerreport.GetString("")));




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
        public static void offerReport(IEnumerable<Offer> OfferQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var o in OfferQuery)
            {

                o.discountValue = decimal.Parse(SectionData.DecTostring(o.discountValue));
            }

            rep.DataSources.Add(new ReportDataSource("DataSetOffer", OfferQuery));
            paramarr.Add(new ReportParameter("dateForm", MainWindow.dateFormat));
            paramarr.Add(new ReportParameter("trCode", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trName", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trDiscount", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trStartDate", MainWindow.resourcemanagerreport.GetString("")));
            paramarr.Add(new ReportParameter("trEndDate", MainWindow.resourcemanagerreport.GetString("")));



        }
        public static void cardReport(IEnumerable<Card> cardsQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetCard", cardsQuery));
        }
        public static void shippingReport(IEnumerable<ShippingCompanies> shippingCompanies, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetShipping", shippingCompanies));
        }
        public static void PurStsReport(IEnumerable<ItemTransferInvoice> tempquery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetITinvoice", tempquery));
        }

        public static void posReport(IEnumerable<Pos> possQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetPos", possQuery));
        }

        public static void customerReport(IEnumerable<Agent> customersQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("AgentDataSet", customersQuery));
        }

        public static void branchReport(IEnumerable<Branch> branchQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetBranches", branchQuery));
        }

        public static void userReport(IEnumerable<User> usersQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetUser", usersQuery));
        }

        public static void vendorReport(IEnumerable<Agent> vendorsQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
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
            rep.DataSources.Add(new ReportDataSource("DataSetStorage", storageQuery));
        }
        public static void cashTransferSts(IEnumerable<CashTransferSts> cashTransfers, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetCashTransferSts", cashTransfers));
        }
        public static void itemTransferInvoice(IEnumerable<ItemTransferInvoice> itemTransferInvoices, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemTransferInvoice", itemTransferInvoices));
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
        public static void itemReport(IEnumerable<Item> itemQuery, LocalReport rep, string reppath, List<ReportParameter> paramarr)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            foreach (var r in itemQuery)
            {
                r.taxes = decimal.Parse(SectionData.DecTostring(r.taxes));
            }
            rep.DataSources.Add(new ReportDataSource("DataSetItem", itemQuery));
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

        public static void itemLocation(IEnumerable<ItemLocation> itemLocations, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemLocation", itemLocations));
        }
    }
}
