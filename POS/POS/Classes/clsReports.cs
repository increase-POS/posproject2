using Microsoft.Reporting.WinForms;
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
        public static void orderReport(IEnumerable<Invoice> invoiceQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetInvoice", invoiceQuery));
        }
        public static void bankAccReport(IEnumerable<CashTransfer> cash, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
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
        public static void categoryReport(IEnumerable<Category> categoryQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetCategory", categoryQuery));
        }
        public static void itemReport(IEnumerable<Item> itemQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItem", itemQuery));
        }
        public static void properyReport(IEnumerable<Property> propertyQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetProperty", propertyQuery));
        }
        public static void storageCostReport(IEnumerable<StorageCost> storageCostQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetStorageCost", storageCostQuery));
        }
        public static void unitReport(IEnumerable<Unit> unitQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetUnit", unitQuery));
        }

        internal static void itemLocation(IEnumerable<ItemLocation> itemLocationListQuery, LocalReport rep, string reppath)
        {
            throw new NotImplementedException();
        }
    }
}
