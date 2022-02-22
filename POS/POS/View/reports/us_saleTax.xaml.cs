using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View.reports
{
    /// <summary>
    /// Interaction logic for us_saleTax.xaml
    /// </summary>
    public partial class us_saleTax : UserControl
    {
        string searchText = "";
        IEnumerable<ItemTransferInvoiceTax> taxes;
        IEnumerable<ItemTransferInvoiceTax> taxTemp = null;
        IEnumerable<ItemTransferInvoiceTax> taxQuery;
        IEnumerable<ItemTransferInvoiceTax> taxQueryExcel;
        Statistics statisticsModel = new Statistics();
        public us_saleTax()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            //try
            //{
                //if (sender != null)
                //    SectionData.StartAwait(grid_main);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }
                translate();
                #endregion

                //Btn_invoice_Click(btn_invoice, null);
                SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_invoice.Tag.ToString());

                txt_search.Text = "";

                chk_allBranches.IsChecked = true;

                await Search();

                //if (sender != null)
                //    SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    //if (sender != null)
            //    //    SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }
        async Task Search()
        {
            if (taxes is null)
                await RefreshTaxList();

            searchText = txt_search.Text.ToLower();

            taxTemp = taxes;
           //     .Where(p =>
           // (dp_startDate.SelectedDate != null ? p.updateDate >= dp_startDate.SelectedDate : true)
           // &&
           // //end date
           // (dp_endDate.SelectedDate != null ? p.updateDate <= dp_endDate.SelectedDate : true)
           // );

           // taxTemp = taxTemp.GroupBy(s => s.invoiceId).SelectMany(inv => inv.Take(1)).ToList();

           // taxQuery = taxTemp
           // .Where(s =>
           // (
           // s.invNumber.ToLower().Contains(searchText)
           // ||
           // s.totalNet.ToString().ToLower().Contains(searchText)
           // ||
           // s.invType.ToLower().Contains(searchText)
           // ||
           // s.ITitemName.ToLower().Contains(searchText)
           // ||
           // s.ITunitName.ToLower().Contains(searchText)
           // ||
           // s.ITquantity.ToString().ToLower().Contains(searchText)
           // ||
           // s.ITprice.ToString().ToLower().Contains(searchText)
           // )
           // &&
           // //branchID/itemID
           // (
           //     cb_branches.SelectedIndex != -1 ? s.branchId == Convert.ToInt32(cb_branches.SelectedValue) : true
           // )
           //);

            //var profitsSum = profitsQuery.GroupBy(s => s.invoiceId).Select(g => new
            //{
            //    invoiceProfit = g.Sum(p => p.itemunitProfit),
            //    shippingProfit = g.FirstOrDefault().shippingProfit
            //}).ToList();

            //int i = 0;
            //foreach (var x in profitsQuery)
            //{
            //    x.invoiceProfit = profitsSum[i].invoiceProfit + profitsSum[i].shippingProfit;
            //    i++;
            //}

            taxQueryExcel = taxQuery.ToList();
            RefreshTaxView();
            fillColumnChart();
            fillRowChart();
        }

        private void fillRowChart()
        {
            throw new NotImplementedException();
        }

        private void fillColumnChart()
        {
            throw new NotImplementedException();
        }

        private void RefreshTaxView()
        {
            throw new NotImplementedException();
        }

      
        async Task<IEnumerable<ItemTransferInvoiceTax>> RefreshTaxList()
        {
            taxes = await statisticsModel.GetInvItemTax(MainWindow.branchID.Value, MainWindow.userID.Value);
            return taxes;
        }
        private void translate()
        {
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_startDate, MainWindow.resourcemanager.GetString("trStartDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(dp_endDate, MainWindow.resourcemanager.GetString("trEndDateHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txt_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            chk_allBranches.Content = MainWindow.resourcemanager.GetString("trAll");

            tt_invoice.Content = MainWindow.resourcemanager.GetString("trInvoices");

            col_invNum.Header = MainWindow.resourcemanager.GetString("trNum");
            col_invTotal.Header = MainWindow.resourcemanager.GetString("trTotal");
            col_taxOnItems.Header = MainWindow.resourcemanager.GetString("trOnItem");
            col_taxOnInvoice.Header = MainWindow.resourcemanager.GetString("trOnInvoice");
            col_taxNet.Header = MainWindow.resourcemanager.GetString("trTaxNet");

            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            txt_total.Text = MainWindow.resourcemanager.GetString("trTotal");
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {//unload
            GC.Collect();

        }

        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Chk_allBranches_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Chk_allBranches_Unchecked(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh

        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf

        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel

        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview

        }
    }
}
