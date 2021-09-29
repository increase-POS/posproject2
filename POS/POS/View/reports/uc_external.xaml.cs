using LiveCharts;
using LiveCharts.Wpf;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using LiveCharts.Helpers;
using POS.View.windows;
using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using static POS.Classes.Statistics;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using System.IO;
using System.Threading;

namespace POS.View.reports
{
    public partial class uc_external
    {
        private int selectedFatherTab = 0;
        List<Storage> storages;

        List<ItemTransferInvoice> itemsTransfer;
        List<ItemTransferInvoice> itemsInternalTransfer;

        IEnumerable<ItemTransferInvoice> agentsCount;
        IEnumerable<ItemTransferInvoice> invTypeCount;
        IEnumerable<ItemTransferInvoice> invCount;

        IEnumerable<InventoryClass> archiveCount;

        List<InventoryClass> inventory;
        List<InventoryClass> falls;
        List<ItemTransferInvoice> Destroied;

        private static uc_storageReports _instance;
        public static uc_storageReports Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_storageReports();
                return _instance;
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                inventory = await statisticModel.GetInventory();
                falls = await statisticModel.GetInventoryItems();
                Destroied = await statisticModel.GetDesItems();
                storages = await statisticModel.GetStorage();
                itemsTransfer = await statisticModel.GetExternalMov();
                itemsInternalTransfer = await statisticModel.GetInternalMov();
                comboBranches = await branchModel.GetAllWithoutMain("all");

                comboItems = statisticModel.getItemCombo(storages);
                comboUnits = statisticModel.getUnitCombo(storages);
                comboSection = statisticModel.getSectionCombo(storages);
                comboLocation = statisticModel.getLocationCombo(storages);

                comboExternalItemsItems = statisticModel.getExternalItemCombo(itemsTransfer);
                comboExternalItemsUnits = statisticModel.getExternalUnitCombo(itemsTransfer);
                comboInternalItemsItems = statisticModel.getExternalItemCombo(itemsInternalTransfer);
                comboInternalItemsUnits = statisticModel.getExternalUnitCombo(itemsInternalTransfer);
                comboInternalOperatorType = statisticModel.getTypeCompo(itemsInternalTransfer);
                comboInternalOperatorOperator = statisticModel.getOperatroCompo(itemsInternalTransfer);

                comboExternalAgentsAgentsType = statisticModel.GetExternalAgentTypeCombos(itemsTransfer);
                comboExternalAgentsAgents = statisticModel.GetExternalAgentCombos(itemsTransfer);
                comboExternalInvType = statisticModel.GetExternalInvoiceTypeCombos(itemsTransfer);
                comboExternalInvoiceInvoice = statisticModel.GetExternalInvoiceCombos(itemsTransfer);


                fillComboExternalAgentsAgentsType();
                fillComboExternalInvType();
                fillComboExternalAgentsAgents();
                fillComboExternalInvoiceInvoice();
                fillComboExternalAgentsAgents();
                fillComboExternalAgentsAgentsType();

                chk_externalAgentsIn.IsChecked = true;
                chk_externalItemsIn.IsChecked = true;
                chk_externalAgentsOut.IsChecked = true;
                chk_externalItemsOut.IsChecked = true;

                paint();
                fillComboBranches(cb_externalItemsBranches);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                showSelectedTabColumn();
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();


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
        public uc_external()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }



        public void paintExternlaChilds()
        {
            bdrMain.RenderTransform = Animations.borderAnimation(50, bdrMain, true);

            grid_externalItems.Visibility = Visibility.Hidden;
            grid_externalAgents.Visibility = Visibility.Hidden;
            grid_externalInvoices.Visibility = Visibility.Hidden;


            path_item.Fill = Brushes.White;
            path_agent.Fill = Brushes.White;
            path_invoice.Fill = Brushes.White;

            bdr_agent.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_item.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
            bdr_invoice.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
        }


        public void paint()
        {
        }




        private void isEnabledButtonsExternal()
        {
            btn_item.IsEnabled = true;
            btn_invoice.IsEnabled = true;
            btn_agent.IsEnabled = true;
        }

        private void isEnabledButtons()
        {
        }


        private void btn_external_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btn_externalItems_Click(object sender, RoutedEventArgs e)
        {//items
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                selectedExternalTab = 0;
                txt_search.Text = "";
                paintExternlaChilds();
                isEnabledButtonsExternal();
                grid_externalItems.Visibility = Visibility.Visible;
                bdr_item.Background = Brushes.White;
                path_item.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                isEnabledButtons();
                btn_item.IsEnabled = false;
                btn_item.Opacity = 1;
                fillComboBranches(cb_externalItemsBranches);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                showSelectedTabColumn();
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void btn_externalAgents_Click(object sender, RoutedEventArgs e)
        {//agents
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                selectedExternalTab = 1;
                txt_search.Text = "";
                paintExternlaChilds();
                isEnabledButtonsExternal();
                grid_externalAgents.Visibility = Visibility.Visible;
                bdr_agent.Background = Brushes.White;
                path_agent.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                isEnabledButtons();
                btn_agent.IsEnabled = false;
                btn_agent.Opacity = 1;
                fillComboBranches(cb_externalAgentsBranches);

                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                showSelectedTabColumn();
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void btn_externalInvoices_Click(object sender, RoutedEventArgs e)
        {//invoices
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                selectedExternalTab = 2;
                txt_search.Text = "";
                paintExternlaChilds();
                isEnabledButtonsExternal();
                btn_invoice.IsEnabled = false;
                btn_invoice.Opacity = 1;
                grid_externalInvoices.Visibility = Visibility.Visible;
                path_invoice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#4E4E4E"));
                bdr_invoice.Background = Brushes.White;
                fillComboBranches(cb_externalInvoicesBranches);
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null)
                 .GroupBy(x => new { x.branchId, x.invoiceId })
                               .Select(s => new ItemTransferInvoice
                               {
                                   branchId = s.FirstOrDefault().branchId,
                                   branchName = s.FirstOrDefault().branchName,
                                   agentName = s.FirstOrDefault().agentName,
                                   AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                                   ItemUnits = s.FirstOrDefault().ItemUnits,
                                   invNumber = s.FirstOrDefault().invNumber,
                                   invType = s.FirstOrDefault().invType,
                                   quantity = s.FirstOrDefault().quantity
                               }); ;
                showSelectedTabColumn();
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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




        private int selectedStockTab = 0;
        IEnumerable<itemCombo> comboItems;
        IEnumerable<unitCombo> comboUnits;
        IEnumerable<sectionCombo> comboSection;
        IEnumerable<locationCombo> comboLocation;

        private void fillComboItems(ComboBox cbBranches, ComboBox cbItems)
        {
            var temp = cbBranches.SelectedItem as Branch;
            cbItems.SelectedValuePath = "ItemId";
            cbItems.DisplayMemberPath = "ItemName";
            if (temp == null)
            {
                cbItems.ItemsSource = comboItems
                    .GroupBy(x => x.ItemId)
                    .Select(g => new itemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
            else
            {
                cbItems.ItemsSource = comboItems
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.ItemId)
                    .Select(g => new itemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboUnits(ComboBox cbItems, ComboBox cbUnits)
        {
            var temp = cbItems.SelectedItem as itemCombo;
            cbUnits.SelectedValuePath = "UnitId";
            cbUnits.DisplayMemberPath = "UnitName";
            if (temp == null)
            {
                cbUnits.ItemsSource = comboUnits
                    .GroupBy(x => x.UnitId)
                    .Select(g => new unitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else
            {
                cbUnits.ItemsSource = comboUnits
                    .Where(x => x.ItemId == temp.ItemId && x.BranchId == temp.BranchId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new unitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    }); ;
            }
        }










        /*2222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222222*/
        private int selectedExternalTab = 0;
        List<ExternalitemCombo> comboExternalItemsItems;
        List<ExternalUnitCombo> comboExternalItemsUnits;
        List<AgentTypeCombo> comboExternalAgentsAgentsType;
        List<AgentCombo> comboExternalAgentsAgents;
        List<InvTypeCombo> comboExternalInvType;
        List<InvCombo> comboExternalInvoiceInvoice;


        private void fillComboExternalItemsItems()
        {
            var temp = cb_externalItemsBranches.SelectedItem as Branch;
            cb_externalItemsItems.SelectedValuePath = "ItemId";
            cb_externalItemsItems.DisplayMemberPath = "ItemName";
            if (temp == null)
            {
                cb_externalItemsItems.ItemsSource = comboExternalItemsItems
                    .GroupBy(x => x.ItemId)
                    .Select(g => new ExternalitemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
            else
            {
                cb_externalItemsItems.ItemsSource = comboExternalItemsItems
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.ItemId)
                    .Select(g => new ExternalitemCombo
                    {
                        ItemId = g.FirstOrDefault().ItemId,
                        ItemName = g.FirstOrDefault().ItemName,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboExternalItemsUnits()
        {
            var temp = cb_externalItemsItems.SelectedItem as ExternalitemCombo;
            var temp1 = cb_externalItemsBranches.SelectedItem as Branch;

            cb_externalItemsUnits.SelectedValuePath = "UnitId";
            cb_externalItemsUnits.DisplayMemberPath = "UnitName";
            if (temp == null && temp1 == null)
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else if (temp != null && temp1 == null)
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                     .Where(x => x.ItemId == temp.ItemId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else if (temp == null && temp1 != null)
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                     .Where(x => x.BranchId == temp1.branchId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
            else
            {
                cb_externalItemsUnits.ItemsSource = comboExternalItemsUnits
                    .Where(x => x.ItemId == temp.ItemId && x.BranchId == temp1.branchId)
                    .GroupBy(x => x.UnitId)
                    .Select(g => new ExternalUnitCombo
                    {
                        UnitId = g.FirstOrDefault().UnitId,
                        UnitName = g.FirstOrDefault().UnitName,
                        ItemId = g.FirstOrDefault().ItemId
                    });
            }
        }

        private void fillComboExternalAgentsAgentsType()
        {
            var temp = cb_externalAgentsBranches.SelectedItem as Branch;
            cb_externalAgentsAgentsType.SelectedValuePath = "AgentId";
            cb_externalAgentsAgentsType.DisplayMemberPath = "AgentType";
            if (temp == null)
            {
                //cb_externalAgentsAgentsType.ItemsSource = comboExternalAgentsAgentsType
                //    .GroupBy(x => x.AgentType)
                //    .Select(g => new AgentTypeCombo
                //    {
                //        AgentType = g.FirstOrDefault().AgentType,
                //        BranchId = g.FirstOrDefault().BranchId
                //    }).ToList();
                var lst = comboExternalAgentsAgentsType
                    .GroupBy(x => x.AgentType)
                    .Select(g => new AgentTypeCombo
                    {
                        AgentType = g.FirstOrDefault().AgentType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
                foreach(var l in lst)
                {
                    if (l.AgentType.Equals("c")) l.AgentType = MainWindow.resourcemanager.GetString("trCustomer");
                    else if (l.AgentType.Equals("v")) l.AgentType = MainWindow.resourcemanager.GetString("trVendor");

                }

                cb_externalAgentsAgentsType.ItemsSource = lst;
            }
            else
            {
                cb_externalAgentsAgentsType.ItemsSource = comboExternalAgentsAgentsType
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.AgentType)
                    .Select(g => new AgentTypeCombo
                    {
                        AgentType = g.FirstOrDefault().AgentType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

        private void fillComboExternalAgentsAgents()
        {
            var temp = cb_externalAgentsAgentsType.SelectedItem as AgentTypeCombo;
            var temp1 = cb_externalAgentsBranches.SelectedItem as Branch;
            cb_externalAgentsCustomer.SelectedValuePath = "AgentId";
            cb_externalAgentsCustomer.DisplayMemberPath = "AgentName";
            if (temp == null)
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }
            else if (temp != null && temp1 == null)
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                        .Where(x => x.AgentType == temp.AgentType)
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }
            else if (temp == null && temp1 != null)
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                        .Where(x => x.BranchId == temp1.branchId)
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }
            else
            {
                cb_externalAgentsCustomer.ItemsSource = comboExternalAgentsAgents
                         .Where(x => x.AgentType == temp.AgentType && x.BranchId == temp1.branchId)
                    .GroupBy(x => x.AgentId)
                    .Select(g => new AgentCombo
                    {
                        AgentId = g.FirstOrDefault().AgentId,
                        AgentName = g.FirstOrDefault().AgentName,
                        BranchId = g.FirstOrDefault().BranchId,
                        AgentType = g.FirstOrDefault().AgentType
                    }).ToList();
            }

        }

        private void fillComboExternalInvType()
        {
            var temp = cb_externalInvoicesBranches.SelectedItem as Branch;
            cb_externalInvoicesInvoiceType.SelectedValuePath = "InvoiceId";
            cb_externalInvoicesInvoiceType.DisplayMemberPath = "InvoiceType";
            if (temp == null)
            {
                cb_externalInvoicesInvoiceType.ItemsSource = comboExternalInvType
                    .GroupBy(x => x.InvoiceType)
                    .Select(g => new InvTypeCombo
                    {
                        InvoiceType = g.FirstOrDefault().InvoiceType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
                //var lst = comboExternalInvType
                //    .GroupBy(x => x.InvoiceType)
                //    .Select(g => new InvTypeCombo
                //    {
                //        InvoiceType = g.FirstOrDefault().InvoiceType,
                //        BranchId = g.FirstOrDefault().BranchId
                //    }).ToList();

                //foreach (var l in lst)
                //{
                //    string value = "";
                //}
            }
            else
            {
                cb_externalInvoicesInvoiceType.ItemsSource = comboExternalInvType
                    .Where(x => x.BranchId == temp.branchId)
                    .GroupBy(x => x.InvoiceType)
                    .Select(g => new InvTypeCombo
                    {
                        InvoiceType = g.FirstOrDefault().InvoiceType,
                        BranchId = g.FirstOrDefault().BranchId
                    }).ToList();
            }
        }

    //    private string getInvoiceType(string s)
    //    {
    //        switch (l.InvoiceType)
    //        {
    //            //مشتريات 
    //            case "p":
    //                value = MainWindow.resourcemanager.GetString("trPurchaseInvoice");
    //                break;
    //            //فاتورة مشتريات بانتظار الادخال
    //            case "pw":
    //                value = MainWindow.resourcemanager.GetString("trPurchaseInvoiceWaiting");
    //                break;
    //            //مبيعات
    //            case "s":
    //                value = MainWindow.resourcemanager.GetString("trSalesInvoice");
    //                break;
    //            //مرتجع مبيعات
    //            case "sb":
    //                value = MainWindow.resourcemanager.GetString("trSalesReturnInvoice");
    //                break;
    //            //مرتجع مشتريات
    //            case "pb":
    //                value = MainWindow.resourcemanager.GetString("trPurchaseReturnInvoice");
    //                break;
    //            //فاتورة مرتجع مشتريات بانتظار الاخراج
    //            case "pbw":
    //                value = MainWindow.resourcemanager.GetString("trPurchaseReturnInvoiceWaiting");
    //                break;
    //            //مسودة مشتريات 
    //            case "pd":
    //                value = MainWindow.resourcemanager.GetString("trDraftPurchaseBill");
    //                break;
    //            //مسودة مبيعات
    //            case "sd":
    //                value = MainWindow.resourcemanager.GetString("trSalesDraft");
    //                break;
    //            //مسودة مرتجع مبيعات
    //            case "sbd":
    //                value = MainWindow.resourcemanager.GetString("trSalesReturnDraft");
    //                break;
    //            //مسودة مرتجع مشتريات
    //            case "pbd":
    //                value = MainWindow.resourcemanager.GetString("trPurchaseReturnDraft");
    //                break;
    //            // مسودة طلبية مبيعات 
    //            case "ord":
    //                value = MainWindow.resourcemanager.GetString("trSaleOrderDraft");
    //                break;
    //            //   طلبية مبيعات 
    //            case "or":
    //                value = MainWindow.resourcemanager.GetString("trSaleOrder");
    //                break;
    //            // مسودة طلبية شراء 
    //            case "pod":
    //                value = MainWindow.resourcemanager.GetString("trPurchaceOrderDraft");
    //                break;
    //            // طلبية شراء 
    //            case "po":
    //                value = MainWindow.resourcemanager.GetString("trPurchaceOrder");
    //                break;
    //            //مسودة عرض 
    //            case "qd":
    //                value = MainWindow.resourcemanager.GetString("trQuotationsDraft");
    //                break;
    //            //فاتورة عرض اسعار
    //            case "q":
    //                value = MainWindow.resourcemanager.GetString("trQuotations");
    //                break;
    //            //الإتلاف
    //            case "d":
    //                value = MainWindow.resourcemanager.GetString("trDestructive");
    //                break;
    //            //النواقص
    //            case "sh":
    //                value = MainWindow.resourcemanager.GetString("trShortage");
    //                break;
    //            //مسودة  استراد
    //            case "imd":
    //                value = MainWindow.resourcemanager.GetString("trImportDraft");
    //                break;
    //            // استراد
    //            case "im":
    //                value = MainWindow.resourcemanager.GetString("trImport");
    //                break;
    //            // طلب استيراد
    //            case "imw":
    //                value = MainWindow.resourcemanager.GetString("trImportOrder");
    //                break;
    //            //مسودة تصدير
    //            case "exd":
    //                value = MainWindow.resourcemanager.GetString("trExportDraft");
    //                break;
    //            // تصدير
    //            case "ex":
    //                value = MainWindow.resourcemanager.GetString("trExport");
    //                break;
    //            // طلب تصدير
    //            case "exw":
    //                value = MainWindow.resourcemanager.GetString("trExportOrder");
    //                break;
    //            default: break;
    //        }

    //        l.InvoiceType = value;
    //    }

    //}

    private void fillComboExternalInvoiceInvoice()
        {
            var temp = cb_externalInvoicesInvoiceType.SelectedItem as InvTypeCombo;
            var temp1 = cb_externalInvoicesBranches.SelectedItem as Branch;
            cb_externalInvoicesInvoice.SelectedValuePath = "InvoiceId";
            cb_externalInvoicesInvoice.DisplayMemberPath = "InvoiceNumber";
            if (temp == null && temp1 == null)
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                    .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
            else if (temp != null && temp1 == null)
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                      .Where(x => x.InvoiceType == temp.InvoiceType)
                    .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
            else if (temp == null && temp1 != null)
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                      .Where(x => x.BranchId == temp1.branchId)
                    .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
            else
            {
                cb_externalInvoicesInvoice.ItemsSource = comboExternalInvoiceInvoice
                    .Where(x => x.InvoiceType == temp.InvoiceType && x.BranchId == temp1.branchId)
                     .GroupBy(x => x.InvoiceId)
                    .Select(g => new InvCombo
                    {
                        InvoiceId = g.FirstOrDefault().InvoiceId,
                        InvoiceNumber = g.FirstOrDefault().InvoiceNumber,
                        BranchId = g.FirstOrDefault().BranchId,
                        InvoiceType = g.FirstOrDefault().InvoiceType
                    }).ToList();
            }
        }

        private IEnumerable<ItemTransferInvoice> fillList(IEnumerable<ItemTransferInvoice> itemsTransfer, ComboBox comboBranch, ComboBox comboItem, ComboBox comboUnit, DatePicker startDate, DatePicker endDate, CheckBox chkAllBranches, CheckBox chkAllItems, CheckBox chkAllUnits, CheckBox chkIn, CheckBox chkOut)
        {
            var selectedBranch = comboBranch.SelectedItem as Branch;
            var selectedItem = comboItem.SelectedItem as ExternalitemCombo;
            var selectedUnit = comboUnit.SelectedItem as ExternalUnitCombo;
            var selectedAgentType = comboItem.SelectedItem as AgentTypeCombo;
            var selectedAgent = comboUnit.SelectedItem as AgentCombo;
            var selectedInvoiceType = comboItem.SelectedItem as InvTypeCombo;
            var selectedInvoice = comboUnit.SelectedItem as InvCombo;

            var result = itemsTransfer.Where(x => (
                  (selectedExternalTab == 0 ? (
                            ((chkIn.IsChecked == true ? (x.invType == "p") || (x.invType == "sb") : false)
                            || (chkOut.IsChecked == true ? (x.invType == "s") || (x.invType == "pb") : false))
                          && (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                          && (comboItem.SelectedItem != null ? (x.itemId == selectedItem.ItemId) : true)
                          && (comboUnit.SelectedItem != null ? (x.unitId == selectedUnit.UnitId) : true)
                          && (dp_externalItemsStartDate.SelectedDate != null ? (x.OstartDate >= startDate.SelectedDate) : true)
                          && (dp_externalItemsEndDate.SelectedDate != null ? (x.OendDate <= endDate.SelectedDate) : true)
                          )
                          : true
                          )
                          && (selectedExternalTab == 1 ? (
                           ((chkIn.IsChecked == true ? (x.invType == "p") || (x.invType == "sb") : false)
                            || (chkOut.IsChecked == true ? (x.invType == "s") || (x.invType == "pb") : false))
                          && (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                          && (comboItem.SelectedItem != null ? (x.agentType == selectedAgentType.AgentType) : true)
                          && (comboUnit.SelectedItem != null ? (x.agentId == selectedAgent.AgentId) : true)

                          )
                          : true
                          )
                          && (selectedExternalTab == 2 ? (
                            (comboBranch.SelectedItem != null ? (x.branchId == selectedBranch.branchId) : true)
                          && (comboItem.SelectedItem != null ? (x.invType == selectedInvoiceType.InvoiceType) : true)
                          && (comboUnit.SelectedItem != null ? (x.invoiceId == selectedInvoice.InvoiceId) : true)

                          )
                          : true
                          )
            ));

            return result;
        }


        private void cb_externalItemsBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsItems.IsEnabled = true;
                chk_externalItemsAllItems.IsEnabled = true;
                fillComboExternalItemsItems();
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsBranches.IsEnabled = false;
                cb_externalItemsBranches.SelectedItem = null;
                cb_externalItemsItems.IsEnabled = true;
                chk_externalItemsAllItems.IsEnabled = true;
                fillComboExternalItemsItems();
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsBranches.IsEnabled = true;
                cb_externalItemsItems.IsEnabled = false;
                cb_externalItemsItems.SelectedItem = null;
                chk_externalItemsAllItems.IsEnabled = false;
                chk_externalItemsAllItems.IsChecked = false;
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsIn_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsIn_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsOut_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsOut_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void dp_externalItemsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void dp_externalItemsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void cb_externalItemsItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsUnits.IsEnabled = true;
                chk_externalItemsAllUnits.IsEnabled = true;
                fillComboExternalItemsUnits();
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsAllItems_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsItems.IsEnabled = false;
                cb_externalItemsItems.SelectedItem = null;
                cb_externalItemsUnits.IsEnabled = true;
                chk_externalItemsAllUnits.IsEnabled = true;
                fillComboExternalItemsUnits();

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

        private void chk_externalItemsAllItems_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsItems.IsEnabled = true;
                cb_externalItemsUnits.IsEnabled = false;
                cb_externalItemsUnits.SelectedItem = null;
                chk_externalItemsAllUnits.IsEnabled = false;
                chk_externalItemsAllUnits.IsChecked = false;

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

        private void cb_externalItemsUnits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalItemsAllUnits_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsUnits.IsEnabled = false;
                cb_externalItemsUnits.SelectedItem = null;

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

        private void chk_externalItemsAllUnits_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalItemsUnits.IsEnabled = true;

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

        private void cb_externalAgentsBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsAgentsType.IsEnabled = true;
                chk_externalAgentsAllAgentsType.IsEnabled = true;
                fillComboExternalAgentsAgentsType();
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void cb_externalAgentsAgentsType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsCustomer.IsEnabled = true;
                chk_externalAgentsAllCustomers.IsEnabled = true;
                fillComboExternalAgentsAgents();
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void cb_externalAgentsCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalAgentsAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsBranches.IsEnabled = false;
                cb_externalAgentsBranches.SelectedItem = null;
                cb_externalAgentsAgentsType.IsEnabled = true;
                chk_externalAgentsAllAgentsType.IsEnabled = true;
                fillComboExternalAgentsAgentsType();

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

        private void chk_externalAgentsAllAgentsType_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsAgentsType.IsEnabled = false;
                cb_externalAgentsAgentsType.SelectedItem = null;
                cb_externalAgentsCustomer.IsEnabled = true;
                chk_externalAgentsAllCustomers.IsEnabled = true;
                fillComboExternalAgentsAgents();

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

        private void chk_externalAgentsAllCustomers_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsCustomer.IsEnabled = false;
                cb_externalAgentsCustomer.SelectedItem = null;

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

        private void chk_externalAgentsAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsBranches.IsEnabled = true;
                cb_externalAgentsAgentsType.IsEnabled = false;
                cb_externalAgentsAgentsType.SelectedItem = null;
                chk_externalAgentsAllAgentsType.IsEnabled = false;
                chk_externalAgentsAllAgentsType.IsChecked = false;

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

        private void chk_externalAgentsAllAgentsType_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsAgentsType.IsEnabled = true;
                cb_externalAgentsCustomer.IsEnabled = false;
                cb_externalAgentsCustomer.SelectedItem = null;
                chk_externalAgentsAllCustomers.IsEnabled = false;
                chk_externalAgentsAllCustomers.IsChecked = false;

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

        private void chk_externalAgentsAllCustomers_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalAgentsCustomer.IsEnabled = true;

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

        private void chk_externalAgentsIn_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalAgentsIn_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalAgentsOut_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalAgentsOut_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void dp_externalAgentsEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void dp_externalAgentsStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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


        private void cb_externalInvoicesBranches_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalInvoicesInvoiceType.IsEnabled = true;
                chk_externalInvoicesAllInvoicesType.IsEnabled = true;
                fillComboExternalInvType();
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                                  .Select(s => new ItemTransferInvoice
                                  {
                                      branchId = s.FirstOrDefault().branchId,
                                      branchName = s.FirstOrDefault().branchName,
                                      AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                                      ItemUnits = s.FirstOrDefault().ItemUnits
                                    ,
                                      invNumber = s.FirstOrDefault().invNumber,
                                      invType = s.FirstOrDefault().invType,
                                      quantity = s.FirstOrDefault().quantity
                                  }); ;
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalInvoicesAllBranches_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalInvoicesBranches.IsEnabled = false;
                cb_externalInvoicesBranches.SelectedItem = null;
                cb_externalInvoicesInvoiceType.IsEnabled = true;
                chk_externalInvoicesAllInvoicesType.IsEnabled = true;
                fillComboExternalInvType();


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

        private void chk_externalInvoicesAllBranches_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalInvoicesBranches.IsEnabled = true;
                cb_externalInvoicesInvoiceType.IsEnabled = false;
                cb_externalInvoicesInvoiceType.SelectedItem = null;
                chk_externalInvoicesAllInvoicesType.IsEnabled = false;
                chk_externalInvoicesAllInvoicesType.IsChecked = false;

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

        private void dp_externalInvoicesEndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp
         = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                   .Select(s => new ItemTransferInvoice
                   {
                       branchId = s.FirstOrDefault().branchId,
                       branchName = s.FirstOrDefault().branchName,
                       AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                       ItemUnits = s.FirstOrDefault().ItemUnits
                     ,
                       invNumber = s.FirstOrDefault().invNumber,
                       invType = s.FirstOrDefault().invType,
                       quantity = s.FirstOrDefault().quantity
                   }); ;
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void dp_externalInvoicesStartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                  .Select(s => new ItemTransferInvoice
                  {
                      branchId = s.FirstOrDefault().branchId,
                      branchName = s.FirstOrDefault().branchName,
                      AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                      ItemUnits = s.FirstOrDefault().ItemUnits
                    ,
                      invNumber = s.FirstOrDefault().invNumber,
                      invType = s.FirstOrDefault().invType,
                      quantity = s.FirstOrDefault().quantity
                  }); ;
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void cb_externalInvoicesInvoiceType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalInvoicesInvoice.IsEnabled = true;
                chk_externalInvoicesALlInvoice.IsEnabled = true;
                fillComboExternalInvoiceInvoice();
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                               .Select(s => new ItemTransferInvoice
                               {
                                   branchId = s.FirstOrDefault().branchId,
                                   branchName = s.FirstOrDefault().branchName,
                                   AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                                   ItemUnits = s.FirstOrDefault().ItemUnits
                                 ,
                                   invNumber = s.FirstOrDefault().invNumber,
                                   invType = s.FirstOrDefault().invType,
                                   quantity = s.FirstOrDefault().quantity
                               }); ;
                dgStock.ItemsSource = temp;
                txt_count.Text = temp.Count().ToString();
                fillExternalPieChart();

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

        private void chk_externalInvoicesAllInvoicesType_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalInvoicesInvoiceType.IsEnabled = false;
                cb_externalInvoicesInvoiceType.SelectedItem = null;
                cb_externalInvoicesInvoice.IsEnabled = true;
                chk_externalInvoicesALlInvoice.IsEnabled = true;
                fillComboExternalInvoiceInvoice();

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

        private void chk_externalInvoicesAllInvoicesType_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalInvoicesInvoiceType.IsEnabled = true;
                cb_externalInvoicesInvoice.IsEnabled = false;
                cb_externalInvoicesInvoice.SelectedItem = null;
                chk_externalInvoicesALlInvoice.IsEnabled = false;
                chk_externalInvoicesALlInvoice.IsChecked = false;

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

        private void cb_externalInvoicesInvoice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                //dgStock.ItemsSource = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                //   .Select(s => new ItemTransferInvoice
                //   {
                //       branchId = s.FirstOrDefault().branchId,
                //       branchName = s.FirstOrDefault().branchName,
                //       AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                //       ItemUnits = s.FirstOrDefault().ItemUnits
                //     ,
                //       invNumber = s.FirstOrDefault().invNumber,
                //       invType = s.FirstOrDefault().invType,
                //       quantity = s.FirstOrDefault().quantity
                //   });
                var lst = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null).GroupBy(x => new { x.branchId, x.invoiceId })
                   .Select(s => new ItemTransferInvoice
                   {
                       branchId = s.FirstOrDefault().branchId,
                       branchName = s.FirstOrDefault().branchName,
                       AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                       ItemUnits = s.FirstOrDefault().ItemUnits
                     ,
                       invNumber = s.FirstOrDefault().invNumber,
                       invType = s.FirstOrDefault().invType,
                       quantity = s.FirstOrDefault().quantity
                   });

                dgStock.ItemsSource = lst;
                txt_count.Text = lst.Count().ToString();
                fillExternalPieChart();


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

        private void chk_externalInvoicesALlInvoice_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                cb_externalInvoicesInvoice.IsEnabled = false;
                cb_externalInvoicesInvoice.SelectedItem = null;

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

        private void chk_externalInvoicesALlInvoice_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                cb_externalInvoicesInvoice.IsEnabled = true;

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




        private void fillExternalRowChart()
        {
            MyAxis.Labels = new List<string>();
            List<string> names = new List<string>();
            List<int> pTemp = new List<int>();
            List<int> sTemp = new List<int>();
            List<int> pbTemp = new List<int>();
            List<int> sbTemp = new List<int>();


            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            if (selectedExternalTab == 1)
            {
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            }
            else if (selectedExternalTab == 2)
            {
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
            }

            var result = temp.GroupBy(x => new { x.branchId, x.invoiceId }).Select(x => new ItemTransferInvoice
            {
                invType = x.FirstOrDefault().invType,
                branchId = x.FirstOrDefault().branchId
            });

            invCount = result.GroupBy(x => x.branchId).Select(x => new ItemTransferInvoice
            {
                PCount = x.Where(g => g.invType == "p").Count(),
                SCount = x.Where(g => g.invType == "s").Count(),
                PbCount = x.Where(g => g.invType == "pb").Count(),
                SbCount = x.Where(g => g.invType == "sb").Count()
            });




            for (int i = 0; i < agentsCount.Count(); i++)
            {
                pTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().PCount);
                pbTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().PbCount);
                sTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().SCount);
                sbTemp.Add(invCount.ToList().Skip(i).FirstOrDefault().SbCount);
            }
            var tempName = temp.GroupBy(s => new { s.branchId, s.invType }).Select(s => new
            {
                locationName = s.FirstOrDefault().branchName
            });
            names.AddRange(tempName.Select(nn => nn.locationName));

            SeriesCollection rowChartData = new SeriesCollection();
            for (int i = 0; i < pTemp.Count(); i++)
            {
                MyAxis.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            rowChartData.Add(
          new LineSeries
          {
              Values = pTemp.AsChartValues(),
              Title = "Purchase"

          });
            rowChartData.Add(
      new LineSeries
      {
          Values = pbTemp.AsChartValues(),
          Title = "Purchase Returns"

      });
            rowChartData.Add(
      new LineSeries
      {
          Values = sTemp.AsChartValues(),
          Title = "Sale"

      });
            rowChartData.Add(
      new LineSeries
      {
          Values = sbTemp.AsChartValues(),
          Title = "Sale Returns"

      });
            rowChart.Series = rowChartData;
            DataContext = this;
        }

        private void fillExternalColumnChart()
        {
            axcolumn.Labels = new List<string>();
            List<string> names = new List<string>();

            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);

            if (selectedExternalTab == 1)
            {
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            }
            else if (selectedExternalTab == 2)
            {
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
            }

            var res = temp.GroupBy(x => new { x.branchId, x.agentId }).Select(x => new ItemTransferInvoice
            {
                agentId = x.FirstOrDefault().agentId,
                branchId = x.FirstOrDefault().branchId,
                agentType = x.FirstOrDefault().agentType,
                branchName = x.FirstOrDefault().branchName
            });
            agentsCount = res.GroupBy(x => x.branchId).Select(x => new ItemTransferInvoice
            {
                VenCount = x.Where(g => g.agentType == "v").Count(),
                CusCount = x.Where(g => g.agentType == "c").Count()
            }
            );

            var tempName = res.GroupBy(s => new { s.branchId }).Select(s => new
            {
                itemName = s.FirstOrDefault().branchName,
            });
            names.AddRange(tempName.Select(nn => nn.itemName));

            List<string> lable = new List<string>();
            SeriesCollection columnChartData = new SeriesCollection();
            List<int> cP = new List<int>();
            List<int> cPb = new List<int>();


            for (int i = 0; i < agentsCount.Count(); i++)
            {
                cP.Add(agentsCount.ToList().Skip(i).FirstOrDefault().VenCount);
                cPb.Add(agentsCount.ToList().Skip(i).FirstOrDefault().CusCount);
                axcolumn.Labels.Add(names.ToList().Skip(i).FirstOrDefault());
            }

            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cP.AsChartValues(),
                DataLabels = true,
                Title = "Vendor"
            });
            columnChartData.Add(
            new StackedColumnSeries
            {
                Values = cPb.AsChartValues(),
                DataLabels = true,
                Title = "Customer"
            });

            DataContext = this;
            cartesianChart.Series = columnChartData;
            fillExternalRowChart();
        }

        private void fillExternalPieChart()
        {
            List<string> titles = new List<string>();
            List<string> titles1 = new List<string>();
            List<decimal> x = new List<decimal>();
            titles.Clear();
            titles1.Clear();
            var temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut);
            if (selectedExternalTab == 1)
            {
                temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut);
            }
            else if (selectedExternalTab == 2)
            {
                temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null);
            }

            var result = temp
                .GroupBy(s => new { s.itemId, s.unitId })
                .Select(s => new ItemTransferInvoice
                {
                    itemId = s.FirstOrDefault().itemId,
                    unitId = s.FirstOrDefault().unitId,
                    quantity = s.Sum(g => g.quantity),
                    itemName = s.FirstOrDefault().itemName,
                    unitName = s.FirstOrDefault().unitName,
                }).OrderByDescending(s => s.quantity);
            x = result.Select(m => (decimal)m.quantity).ToList();
            titles = result.Select(m => m.itemName).ToList();
            titles1 = result.Select(m => m.unitName).ToList();
            int count = x.Count();
            SeriesCollection piechartData = new SeriesCollection();
            for (int i = 0; i < count; i++)
            {
                List<decimal> final = new List<decimal>();
                List<string> lable = new List<string>();
                if (i < 5)
                {
                    final.Add(x.Max());
                    lable.Add(titles.Skip(i).FirstOrDefault() + titles1.Skip(i).FirstOrDefault());
                    piechartData.Add(
                      new PieSeries
                      {
                          Values = final.AsChartValues(),
                          Title = lable.FirstOrDefault(),
                          DataLabels = true,
                      }
                  );
                    x.Remove(x.Max());
                }
                else
                {
                    final.Add(x.Sum());
                    piechartData.Add(
                      new PieSeries
                      {
                          Values = final.AsChartValues(),
                          Title = "Others",
                          DataLabels = true,
                      }
                  );
                    break;
                }

            }
            chart1.Series = piechartData;
            fillExternalColumnChart();
        }




        Statistics statisticModel = new Statistics();

        List<Branch> comboBranches;
        Branch branchModel = new Branch();
        private void fillComboBranches(ComboBox cb)
        {
            cb.SelectedValuePath = "branchId";
            cb.DisplayMemberPath = "name";
            cb.ItemsSource = comboBranches;
        }

        private void hideAllColumn()
        {
            col_branch.Visibility = Visibility.Hidden;
            col_item.Visibility = Visibility.Hidden;
            col_unit.Visibility = Visibility.Hidden;
            col_locationSection.Visibility = Visibility.Hidden;
            col_quantity.Visibility = Visibility.Hidden;
            col_startDate.Visibility = Visibility.Hidden;
            col_endDate.Visibility = Visibility.Hidden;
            col_Min.Visibility = Visibility.Hidden;
            col_Max.Visibility = Visibility.Hidden;
            col_stockCost.Visibility = Visibility.Hidden;

            col_location.Visibility = Visibility.Hidden;
            col_section.Visibility = Visibility.Hidden;
            col_itemUnits.Visibility = Visibility.Hidden;

            col_invNumber.Visibility = Visibility.Hidden;
            col_invType.Visibility = Visibility.Hidden;
            col_invTypeNumber.Visibility = Visibility.Hidden;
            col_agentType.Visibility = Visibility.Hidden;
            col_agent.Visibility = Visibility.Hidden;
            col_agentTypeAgent.Visibility = Visibility.Hidden;
            col_MaxCollect.Visibility = Visibility.Hidden;
            col_MinCollect.Visibility = Visibility.Hidden;
            col_branchFrom.Visibility = Visibility.Hidden;
            col_branchTo.Visibility = Visibility.Hidden;

            col_stockTakeNum.Visibility = Visibility.Hidden;
            col_stockTakingCoastType.Visibility = Visibility.Hidden;
            col_stockTakingDate.Visibility = Visibility.Hidden;
            col_diffPercentage.Visibility = Visibility.Hidden;
            col_itemCountAr.Visibility = Visibility.Hidden;
            col_DestroyedCount.Visibility = Visibility.Hidden;

            col_destroiedNumber.Visibility = Visibility.Hidden;
            col_destroiedDate.Visibility = Visibility.Hidden;
            col_destroiedItemsUnits.Visibility = Visibility.Hidden;
            col_destroiedReason.Visibility = Visibility.Hidden;
            col_destroiedAmount.Visibility = Visibility.Hidden;
        }
        private void showSelectedTabColumn()
        {
            hideAllColumn();

            if (selectedExternalTab == 0)
            {
                hideAllColumn();
                col_branch.Visibility = Visibility.Visible;
                col_item.Visibility = Visibility.Visible;
                col_unit.Visibility = Visibility.Visible;
                col_quantity.Visibility = Visibility.Visible;
                col_agentTypeAgent.Visibility = Visibility.Visible;
                col_invTypeNumber.Visibility = Visibility.Visible;
            }
            else if (selectedExternalTab == 1)
            {
                hideAllColumn();
                col_branch.Visibility = Visibility.Visible;
                col_itemUnits.Visibility = Visibility.Visible;
                col_agent.Visibility = Visibility.Visible;
                col_quantity.Visibility = Visibility.Visible;
                col_agentType.Visibility = Visibility.Visible;
                col_invTypeNumber.Visibility = Visibility.Visible;
            }
            else if (selectedExternalTab == 2)
            {
                hideAllColumn();
                col_branch.Visibility = Visibility.Visible;
                col_invType.Visibility = Visibility.Visible;
                col_invNumber.Visibility = Visibility.Visible;
                col_quantity.Visibility = Visibility.Visible;
                col_agentTypeAgent.Visibility = Visibility.Visible;
                col_itemUnits.Visibility = Visibility.Visible;
            }


        }
        /************************************************************************************************************************************/

        List<ExternalitemCombo> comboInternalItemsItems;
        List<ExternalUnitCombo> comboInternalItemsUnits;
        List<internalTypeCombo> comboInternalOperatorType;
        List<internalOperatorCombo> comboInternalOperatorOperator;
        IEnumerable<ItemTransferInvoice> temp = null;
        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (selectedExternalTab == 0)
                {
                    temp = fillList(itemsTransfer, cb_externalItemsBranches, cb_externalItemsItems, cb_externalItemsUnits, dp_externalItemsStartDate, dp_externalItemsEndDate, chk_externalItemsAllBranches, chk_externalItemsAllItems, chk_externalItemsAllUnits, chk_externalItemsIn, chk_externalItemsOut)
                .Where(s => (s.branchName.Contains(txt_search.Text) ||
           s.itemName.Contains(txt_search.Text) ||
           s.unitName.Contains(txt_search.Text) ||
           s.agentName.Contains(txt_search.Text) ||
           s.agentType.Contains(txt_search.Text) ||
           s.invNumber.Contains(txt_search.Text) ||
           s.invType.Contains(txt_search.Text)
           ));
                    dgStock.ItemsSource = temp;
                    txt_count.Text = temp.Count().ToString();
                    fillExternalPieChart();
                }
                else if (selectedExternalTab == 1)
                {

                    temp = fillList(itemsTransfer, cb_externalAgentsBranches, cb_externalAgentsAgentsType, cb_externalAgentsCustomer, dp_externalAgentsStartDate, dp_externalAgentsEndDate, chk_externalAgentsAllBranches, chk_externalAgentsAllAgentsType, chk_externalAgentsAllCustomers, chk_externalAgentsIn, chk_externalAgentsOut)


                  .Where(s => (s.branchName.Contains(txt_search.Text) ||
           s.itemName.Contains(txt_search.Text) ||
           s.unitName.Contains(txt_search.Text) ||
           s.agentName.Contains(txt_search.Text) ||
           s.agentType.Contains(txt_search.Text) ||
           s.invNumber.Contains(txt_search.Text) ||
           s.invType.Contains(txt_search.Text)
           ));
                    dgStock.ItemsSource = temp;
                    txt_count.Text = temp.Count().ToString();
                    fillExternalPieChart();
                }


                else
                {
                    temp = fillList(itemsTransfer, cb_externalInvoicesBranches, cb_externalInvoicesInvoiceType, cb_externalInvoicesInvoice, dp_externalInvoicesStartDate, dp_externalInvoicesEndDate, chk_externalInvoicesAllBranches, chk_externalInvoicesAllInvoicesType, chk_externalInvoicesALlInvoice, null, null)
               .GroupBy(x => new { x.branchId, x.invoiceId })
                             .Select(s => new ItemTransferInvoice
                             {
                                 branchId = s.FirstOrDefault().branchId,
                                 branchName = s.FirstOrDefault().branchName,
                                 AgentTypeAgent = s.FirstOrDefault().AgentTypeAgent,
                                 ItemUnits = s.FirstOrDefault().ItemUnits
                               ,
                                 invNumber = s.FirstOrDefault().invNumber,
                                 invType = s.FirstOrDefault().invType,
                                 quantity = s.FirstOrDefault().quantity
                             })
                .Where(s => (s.branchName.Contains(txt_search.Text) ||
           s.ItemUnits.Contains(txt_search.Text) ||
           s.AgentTypeAgent.Contains(txt_search.Text) ||
           s.invNumber.Contains(txt_search.Text) ||
           s.invType.Contains(txt_search.Text)
           ));
                    dgStock.ItemsSource = temp;
                    txt_count.Text = temp.Count().ToString();
                    fillExternalPieChart();
                }



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

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                txt_search.Text = "";
                if (selectedExternalTab == 0)
                {
                    cb_externalItemsBranches.SelectedItem = null;
                    cb_externalItemsItems.SelectedItem = null;
                    cb_externalItemsUnits.SelectedItem = null;
                    chk_externalItemsAllBranches.IsChecked = false;
                    chk_externalItemsAllItems.IsChecked = false;
                    chk_externalItemsAllUnits.IsChecked = false;
                    chk_externalItemsIn.IsChecked = true;
                    chk_externalItemsOut.IsChecked = true;
                    dp_externalItemsEndDate.SelectedDate = null;
                    dp_externalItemsStartDate.SelectedDate = null;
                }
                else if (selectedExternalTab == 1)
                {
                    cb_externalAgentsBranches.SelectedItem = null;
                    cb_externalAgentsAgentsType.SelectedItem = null;
                    cb_externalAgentsCustomer.SelectedItem = null;
                    chk_externalAgentsAllBranches.IsChecked = false;
                    chk_externalAgentsAllAgentsType.IsChecked = false;
                    chk_externalAgentsAllCustomers.IsChecked = false;
                    chk_externalAgentsIn.IsChecked = true;
                    chk_externalAgentsOut.IsChecked = true;
                    dp_externalAgentsEndDate.SelectedDate = null;
                    dp_externalAgentsStartDate.SelectedDate = null;
                }

                else if (selectedExternalTab == 2)
                {
                    cb_externalInvoicesBranches.SelectedItem = null;
                    cb_externalInvoicesInvoice.SelectedItem = null;
                    cb_externalInvoicesInvoiceType.SelectedItem = null;
                    chk_externalInvoicesAllBranches.IsChecked = false;
                    chk_externalInvoicesALlInvoice.IsChecked = false;
                    chk_externalInvoicesAllInvoicesType.IsChecked = false;

                    dp_externalInvoicesEndDate.SelectedDate = null;
                    dp_externalInvoicesStartDate.SelectedDate = null;
                }

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
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    if (selectedExternalTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArItem.rdlc";
                    }
                    else if (selectedExternalTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArAgent.rdlc";
                    }
                    else if (selectedExternalTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArInvoice.rdlc";
                    }
                }
                else
                {
                    if (selectedExternalTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Item.rdlc";
                    }
                    else if (selectedExternalTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Agent.rdlc";
                    }
                    else if (selectedExternalTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Invoice.rdlc";
                    }
                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();
                //itemTransferInvoiceExternal
                clsReports.itemTransferInvoiceExternal(temp, rep, reppath, paramarr);
               
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);

                rep.Refresh();

                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
                #endregion

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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                List<ReportParameter> paramarr = new List<ReportParameter>();

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    if (selectedExternalTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArItem.rdlc";
                    }
                    else if (selectedExternalTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArAgent.rdlc";
                    }
                    else if (selectedExternalTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArInvoice.rdlc";
                    }
                }
                else
                {
                    if (selectedExternalTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Item.rdlc";
                    }
                    else if (selectedExternalTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Agent.rdlc";
                    }
                    else if (selectedExternalTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Invoice.rdlc";
                    }

                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();
                //foreach (var r in temp)
                //{
                //    //r.startDate = DateTime.Parse(SectionData.DateToString(r.startDate));
                //    //r.endDate = DateTime.Parse(SectionData.DateToString(r.endDate)); 
                //    r.inventoryDate = DateTime.Parse(SectionData.DateToString(r.inventoryDate));
                //    r.IupdateDate = DateTime.Parse(SectionData.DateToString(r.IupdateDate));
                //    r.updateDate = DateTime.Parse(SectionData.DateToString(r.updateDate));

                //    //r.storageCostValue = decimal.Parse(SectionData.DecTostring(r.storageCostValue));
                //    //r.diffPercentage = decimal.Parse(SectionData.DecTostring(r.diffPercentage));
                //}
                 clsReports.itemTransferInvoiceExternal(temp, rep, reppath, paramarr);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);
                rep.Refresh();
                LocalReportExtensions.PrintToPrinter(rep);
                #endregion

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

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                Thread t1 = new Thread(() =>
                  {
                      List<ReportParameter> paramarr = new List<ReportParameter>();

                      string addpath = "";
                      bool isArabic = ReportCls.checkLang();
                      if (isArabic)
                      {
                          if (selectedExternalTab == 0)
                          {
                              addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArItem.rdlc";
                          }
                          else if (selectedExternalTab == 1)
                          {
                              addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArAgent.rdlc";
                          }
                          else if (selectedExternalTab == 2)
                          {
                              addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArInvoice.rdlc";
                          }

                      }
                      else
                      {
                          if (selectedExternalTab == 0)
                          {
                              addpath = @"\Reports\StatisticReport\Storage\External\En\Item.rdlc";
                          }
                          else if (selectedExternalTab == 1)
                          {
                              addpath = @"\Reports\StatisticReport\Storage\External\En\Agent.rdlc";
                          }
                          else if (selectedExternalTab == 2)
                          {
                              addpath = @"\Reports\StatisticReport\Storage\External\En\Invoice.rdlc";
                          }

                  }
                  string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                  ReportCls.checkLang();
        
                   clsReports.itemTransferInvoiceExternal(temp, rep, reppath, paramarr);
                  clsReports.setReportLanguage(paramarr);
                  clsReports.Header(paramarr);

                  rep.SetParameters(paramarr);

                  rep.Refresh();
                  this.Dispatcher.Invoke(() =>
                  {
                      saveFileDialog.Filter = "EXCEL|*.xls;";
                      if (saveFileDialog.ShowDialog() == true)
                      {
                          string filepath = saveFileDialog.FileName;
                          LocalReportExtensions.ExportToExcel(rep, filepath);
                      }
                  });


              });
                t1.Start();

                #endregion

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

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region
                Window.GetWindow(this).Opacity = 0.2;
                string pdfpath = "";

                List<ReportParameter> paramarr = new List<ReportParameter>();

                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                string addpath = "";
                bool isArabic = ReportCls.checkLang();
                if (isArabic)
                {
                    if (selectedExternalTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArItem.rdlc";
                    }
                    else if (selectedExternalTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArAgent.rdlc";
                    }
                    else if (selectedExternalTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\Ar\ArInvoice.rdlc";
                    }

                }
                else
                {
                    if (selectedExternalTab == 0)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Item.rdlc";
                    }
                    else if (selectedExternalTab == 1)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Agent.rdlc";
                    }
                    else if (selectedExternalTab == 2)
                    {
                        addpath = @"\Reports\StatisticReport\Storage\External\En\Invoice.rdlc";
                    }

                }
                string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                ReportCls.checkLang();

                 clsReports.itemTransferInvoiceExternal(temp, rep, reppath, paramarr);
                clsReports.setReportLanguage(paramarr);
                clsReports.Header(paramarr);

                rep.SetParameters(paramarr);

                rep.Refresh();

                LocalReportExtensions.ExportToPDF(rep, pdfpath);
                wd_previewPdf w = new wd_previewPdf();
                w.pdfPath = pdfpath;
                if (!string.IsNullOrEmpty(w.pdfPath))
                {
                    w.ShowDialog();
                    w.wb_pdfWebViewer.Dispose();
                }
                Window.GetWindow(this).Opacity = 1;
                #endregion

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
    }
}




