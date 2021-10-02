using LiveCharts;
using LiveCharts.Helpers;
using LiveCharts.Wpf;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.Threading;
using POS.View.windows;
using System.Resources;
using System.Reflection;

namespace POS.View.reports
{

    public partial class us_dailySalesStatistic : UserControl
    {

        IEnumerable<ItemTransferInvoice> itemTrasferInvoices;
        Statistics statisticsModel = new Statistics();
        IEnumerable<ItemTransferInvoice> itemTrasferInvoicesQuery;
        IEnumerable<ItemTransferInvoice> itemTrasferInvoicesQueryExcel;
        string searchText = "";

        private static us_dailySalesStatistic _instance;
       
        public static us_dailySalesStatistic Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new us_dailySalesStatistic();
                return _instance;
            }
        }

        public us_dailySalesStatistic()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            //try
            //{
            //    if (sender != null)
            //        SectionData.StartAwait(grid_main);

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

                dp_invoiceDate.SelectedDate = DateTime.Now;

            await RefreshItemTransferInvoiceList();
                await Search();

            SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), btn_invoice.Tag.ToString());

            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    if (sender != null)
            //        SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }

        private void translate()
        {
            
        }

        async Task<IEnumerable<ItemTransferInvoice>> RefreshItemTransferInvoiceList()
        {
            itemTrasferInvoices = await statisticsModel.Getdailyinvoice(MainWindow.branchID.Value , MainWindow.userID.Value, dp_invoiceDate.SelectedDate.Value.Date);
            return itemTrasferInvoices;

        }

        async Task Search()
        {

            if (itemTrasferInvoices is null)
                await RefreshItemTransferInvoiceList();


            searchText = txt_search.Text.ToLower();
            itemTrasferInvoicesQuery = itemTrasferInvoices;
            //itemTrasferInvoicesQuery = itemTrasferInvoices
            //    .Where(s => (s.transNum.ToLower().Contains(searchText)
            //|| s.cash.ToString().ToLower().Contains(searchText)
            //)
            //&& (s.side == "v" || s.side == "c" || s.side == "u" || s.side == "s" || s.side == "e" || s.side == "m" || s.side == "sh")
            //&& s.transType == "p"
            //&& s.processType != "inv"
            //&& s.updateDate.Value.Date >= dp_startSearchDate.SelectedDate.Value.Date
            //&& s.updateDate.Value.Date <= dp_endSearchDate.SelectedDate.Value.Date
            //);


            itemTrasferInvoicesQueryExcel = itemTrasferInvoicesQuery.ToList();
            RefreshIemTrasferInvoicesView();
            fillBranches();
        }

        void RefreshIemTrasferInvoicesView()
        {
            dgInvoice.ItemsSource = itemTrasferInvoicesQuery;
            txt_count.Text = itemTrasferInvoicesQuery.Count().ToString();
        }

        private void fillBranches()
        {
            cb_branches.SelectedValuePath = "branchCreatorId";
            cb_branches.DisplayMemberPath = "branchCreatorName";
            cb_branches.ItemsSource = itemTrasferInvoices.Select(i => new { i.branchCreatorName, i.branchCreatorId }).Distinct();
        }
        private void Btn_Invoice_Click(object sender, RoutedEventArgs e)
        {

            SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

        }
        private void Btn_order_Click(object sender, RoutedEventArgs e)
        {

            SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

        }
        private void Btn_quotation_Click(object sender, RoutedEventArgs e)
        {

            SectionData.ReportTabTitle(txt_tabTitle, this.Tag.ToString(), (sender as Button).Tag.ToString());

        }
        private async void RefreshView_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                await RefreshItemTransferInvoiceList();
                await Search();

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void RefreshViewCheckbox(object sender, RoutedEventArgs e)
        {
        }
        private void fillPieChart()
        {
           
        }

        private void fillColumnChart()
        {
            
        }

        private void fillRowChart()
        {
           
        }

        private void chk_allBranches_Click(object sender, RoutedEventArgs e)
        {
           
        }
      
        private void cb_branches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //fillPos(Convert.ToInt32(cb_branches.SelectedValue));
        }

        private void fillPos(int branchID)
        {
            cb_branches.SelectedValuePath = "posId";
            cb_branches.DisplayMemberPath = "posName";
            cb_branches.ItemsSource = itemTrasferInvoices.Where(t => t.branchCreatorId == branchID)
                                                         .Select(i => i.posName).Distinct();
        }

        private void BuildReport()
        {
           
        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
