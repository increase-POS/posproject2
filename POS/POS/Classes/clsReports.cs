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
        public static void bankReport(IEnumerable<Bank> banksQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetBank", banksQuery));
        }

        public static void couponReport(IEnumerable<Coupon> CouponQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetCoupon", CouponQuery));
        }
        public static void couponReport(IEnumerable<Offer> OfferQuery, LocalReport rep, string reppath)
        {
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetOffer", OfferQuery));
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
            rep.ReportPath = reppath;
            rep.EnableExternalImages = true;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetItemTransfer", invoiceItems));
            rep.EnableExternalImages = true;
        }

    }
}
