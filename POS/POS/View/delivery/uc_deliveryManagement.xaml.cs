﻿using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.Win32;
using System.IO;
using POS.View.windows;
using Microsoft.Reporting.WinForms;
using POS.View.sales;

namespace POS.View.delivery
{
    /// <summary>
    /// Interaction logic for uc_deliveryManagement.xaml
    /// </summary>
    public partial class uc_deliveryManagement : UserControl
    {
        public uc_deliveryManagement()
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
        private static uc_deliveryManagement _instance;
        public static uc_deliveryManagement Instance
        {
            get
            {
                //if (_instance == null)
                if(_instance is null)
                _instance = new uc_deliveryManagement();
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        string updatePermission = "deliveryManagement_update";
        IEnumerable<Invoice> orders;
        /*
        OrderPreparing orderModel = new OrderPreparing();
        */
        Invoice invoiceModel = new Invoice();
        Invoice order = new Invoice();

        IEnumerable<User> drivers;
        User userModel = new User();

        IEnumerable<ShippingCompanies> companies;
        ShippingCompanies companyModel = new ShippingCompanies();

        string searchText = "";
        public static List<string> requiredControlList;

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            //try
            //{
            //    SectionData.StartAwait(grid_main);
                requiredControlList = new List<string> { "userId" , "companyId"};

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }
                translate();
                #endregion

                #region fill drivers
                drivers = await userModel.getBranchSalesMan(MainWindow.branchID.Value, "deliveryPermission");
                cb_userId.ItemsSource = drivers;
                cb_userId.DisplayMemberPath = "fullName";
                cb_userId.SelectedValuePath = "userId";
                cb_userId.SelectedIndex = -1;

                List<User> _driversList = drivers.ToList();
                var dr = new User();
                dr.userId = 0;
                dr.name = "-";
                _driversList.Insert(0, dr);

                cb_searchUser.ItemsSource = _driversList;
                cb_searchUser.DisplayMemberPath = "fullName";
                cb_searchUser.SelectedValuePath = "userId";
                cb_searchUser.SelectedIndex = -1;
                #endregion

                #region fill companies
                companies = await companyModel.Get();
                companies = companies.Where(c => c.deliveryType != "local");
                cb_companyId.ItemsSource = companies;
                cb_companyId.DisplayMemberPath = "name";
                cb_companyId.SelectedValuePath = "shippingCompanyId";
                cb_companyId.SelectedIndex = -1;

                List<ShippingCompanies> _companiesList = companies.ToList();
                var sh = new ShippingCompanies();
                sh.shippingCompanyId = 0;
                sh.name = "-";
                _companiesList.Insert(0, sh);

                cb_searchCompany.ItemsSource = _companiesList;
                cb_searchCompany.DisplayMemberPath = "name";
                cb_searchCompany.SelectedValuePath = "shippingCompanyId";
                cb_searchCompany.SelectedIndex = -1;
                #endregion

                grid_deliveryCompany.Visibility = Visibility.Collapsed;
                col_cbCompany.Width = new GridLength(0, GridUnitType.Star);
                bdr_searchCompany.Visibility = Visibility.Hidden;
                chk_allForDelivery.IsChecked = true;

            //    SectionData.EndAwait(grid_main);
            //}
            //catch (Exception ex)
            //{
            //    SectionData.EndAwait(grid_main);
            //    SectionData.ExceptionMessage(ex, this);
            //}
        }
      

        #region methods
        async Task Search()
        {
            /*
            try
            {
                searchText = tb_search.Text.ToLower();
                if (chk_allForDelivery.IsChecked == true)
                {
                    await RefreshOrdersList("");
                }
                else if (chk_readyForDelivery.IsChecked == true)
                {
                    await RefreshOrdersList("Ready");
                }
                else if (chk_withDeliveryMan.IsChecked == true)
                {
                    await RefreshOrdersList("Collected");
                }
                else if (chk_inTheWay.IsChecked == true)
                {
                    await RefreshOrdersList("InTheWay");
                }
                if (chk_drivers.IsChecked == true)
                    orders = orders.Where(o => o.shipUserId != null);
                else if (chk_shippingCompanies.IsChecked == true)
                    orders = orders.Where(o => o.shipUserId == null);

                orders = orders.Where(s => (s.invNumber.Contains(searchText)
                      || s.shipUserName.ToString().Contains(searchText)
                      //|| s.orderTime.ToString().Contains(searchText)
                      )
                      && ((cb_searchUser.SelectedIndex != -1 && cb_searchUser.SelectedValue.ToString() != "0")   ?  s.shipUserId        == (int)cb_searchUser.SelectedValue : true)
                      && ( (cb_searchCompany.SelectedIndex != -1 && cb_searchCompany.SelectedValue.ToString() != "0") ?  s.shippingCompanyId == (int)cb_searchCompany.SelectedValue : true)
                  );

                RefreshOrdersView();
            }
            catch { }
            */
        }

        async Task<IEnumerable<Invoice>> RefreshOrdersList(string status)
        {
            //GetOrdersWithDelivery
            orders = await order.GetOrdersWithDelivery(MainWindow.loginBranch.branchId, status);
            orders = orders.Where(o => o.status == "Ready" || o.status == "Collected" || o.status == "InTheWay");


            return orders;
        }
        void RefreshOrdersView()
        {
            dg_orders.ItemsSource = orders;
            txt_count.Text = orders.Count().ToString();
        }

        void Clear()
        {
            order = new Invoice();
            btn_save.IsEnabled = true;
            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
            selectedOrders.Clear();
            this.DataContext = order;
            /*
            SectionData.clearValidate(requiredControlList, this);
            */
        }
        private void translate()
        {
            // Title
            txt_title.Text = MainWindow.resourcemanager.GetString("management");

            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trUserInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_searchUser, MainWindow.resourcemanager.GetString("trDeliveryMan") +"...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_searchCompany, MainWindow.resourcemanager.GetString("trCompany") + "...");


            chk_drivers.Content = MainWindow.resourcemanager.GetString("drivers");
            chk_shippingCompanies.Content = MainWindow.resourcemanager.GetString("trShippingCompanies");

            chk_allForDelivery.Content = MainWindow.resourcemanager.GetString("trAll");
            chk_readyForDelivery.Content = MainWindow.resourcemanager.GetString("trReady");
            chk_withDeliveryMan.Content = MainWindow.resourcemanager.GetString("withDelivery");
            chk_inTheWay.Content = MainWindow.resourcemanager.GetString("onTheWay");

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_userId, MainWindow.resourcemanager.GetString("trDeliveryMan") + "...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_user, MainWindow.resourcemanager.GetString("trDeliveryMan") + "...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_companyId, MainWindow.resourcemanager.GetString("trCompany") + "...");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_deliveryTime, MainWindow.resourcemanager.GetString("deliveryTime") + "...");
            //txt_minutes.Text = MainWindow.resourcemanager.GetString("minute");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNote") + "..."); 

            dg_orders.Columns[1].Header = MainWindow.resourcemanager.GetString("trInvoiceCharp");
            dg_orders.Columns[2].Header = MainWindow.resourcemanager.GetString("trCompany");
            dg_orders.Columns[3].Header = MainWindow.resourcemanager.GetString("trDeliveryMan");
            dg_orders.Columns[4].Header = MainWindow.resourcemanager.GetString("deliveryTime");
            dg_orders.Columns[5].Header = MainWindow.resourcemanager.GetString("trStatus");

            btn_updateDeliveryMan.ToolTip = MainWindow.resourcemanager.GetString("trSave");
            btn_updateDeliveryCompany.ToolTip = MainWindow.resourcemanager.GetString("trSave");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");
        }
        #endregion

        #region Refresh - Clear - Search - Select - Save

        private async void Cb_searchUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                await Search();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Cb_searchCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                await Search();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                await Search();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.StartAwait(grid_main);
                Clear();
                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {

                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Dg_orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                SectionData.StartAwait(grid_main);

                if (dg_orders.SelectedIndex != -1)
                {
                    order = dg_orders.SelectedItem as Invoice;
                   
                    this.DataContext = order;

                    if (order != null)
                    {
                        if (chk_allForDelivery.IsChecked.Value)
                        {
                            selectedOrders.Clear();
                            //selectedOrders.Add(order);

                            if (dg_orders.Items.Count > 1)
                            {
                                var firstCol = dg_orders.Columns.OfType<DataGridCheckBoxColumn>().FirstOrDefault(c => c.DisplayIndex == 0);
                                if(firstCol != null || dg_orders?.Items != null )
                                foreach (var item in dg_orders.Items)
                                {
                                    var chBx = firstCol.GetCellContent(item) as CheckBox;
                                    if (chBx == null)
                                    {
                                        continue;
                                    }
                                    chBx.IsChecked = false;
                                }
                            }
                        }
                        CheckBox checkboxColumn = (dg_orders.Columns[0].GetCellContent(dg_orders.SelectedItem) as CheckBox);

                        //different status
                        if (selectedOrders.Count != 0 && order.status != selectedOrders[0].status)
                        {
                            checkboxColumn.IsChecked = checkboxColumn.IsChecked;
                            //checkboxColumn.IsEnabled = false;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("notHaveSameStatus"), animation: ToasterAnimation.FadeIn);
                        }
                        //driver
                        else if (selectedOrders.Count != 0 && order.shipUserId != null && selectedOrders[0].shipUserId == null)
                        {
                            checkboxColumn.IsChecked = checkboxColumn.IsChecked;
                            //checkboxColumn.IsEnabled = false;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("notHaveSameType"), animation: ToasterAnimation.FadeIn);
                        }
                        //company
                        else if (selectedOrders.Count != 0 && order.shipUserId == null && selectedOrders[0].shipUserId != null)
                        {
                            checkboxColumn.IsChecked = checkboxColumn.IsChecked;
                            //checkboxColumn.IsEnabled = false;
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("notHaveSameType"), animation: ToasterAnimation.FadeIn);
                        }

                        else
                        {
                            if (!chk_allForDelivery.IsChecked.Value)
                                checkboxColumn.IsChecked = !checkboxColumn.IsChecked;
                                //checkboxColumn.IsEnabled = true;
                        }


                        if (selectedOrders.Count > 0)
                        {
                            if (selectedOrders[0].shipUserId == null)
                                requiredControlList = new List<string> { "companyId" };
                            else
                                requiredControlList = new List<string> { "userId" };
                        }
                        #region refreshSaveBtnText
                        if (order.shipUserId != null)
                        {
                            //bdr_cbDeliveryCompany.Visibility = Visibility.Collapsed;
                            grid_deliveryCompany.Visibility = Visibility.Collapsed;

                            if (order.status.Equals("Ready"))
                            {
                                btn_save.Content = MainWindow.resourcemanager.GetString("trCollect");
                                btn_save.IsEnabled = true;
                                //bdr_cbDeliveryMan.Visibility = Visibility.Visible;
                                grid_deliveryMan.Visibility = Visibility.Visible;
                                bdr_tbDeliveryMan.Visibility = Visibility.Collapsed;
                            }
                            else if (order.status.Equals("Collected"))
                            {
                                btn_save.Content = MainWindow.resourcemanager.GetString("onTheWay");
                                btn_save.IsEnabled = true;
                                //bdr_cbDeliveryMan.Visibility = Visibility.Visible;
                                grid_deliveryMan.Visibility = Visibility.Visible;
                                bdr_tbDeliveryMan.Visibility = Visibility.Collapsed;
                            }
                            else if (order.status.Equals("InTheWay"))
                            {
                                btn_save.Content = MainWindow.resourcemanager.GetString("trDone");
                                btn_save.IsEnabled = true;
                                //bdr_cbDeliveryMan.Visibility = Visibility.Collapsed;
                                grid_deliveryMan.Visibility = Visibility.Collapsed;
                                bdr_tbDeliveryMan.Visibility = Visibility.Visible;
                            }
                        }
                        else
                        {
                            //bdr_cbDeliveryCompany.Visibility = Visibility.Visible;
                            //bdr_cbDeliveryMan.Visibility = Visibility.Collapsed;
                            grid_deliveryMan.Visibility = Visibility.Collapsed;
                            grid_deliveryCompany.Visibility = Visibility.Visible;
                            bdr_tbDeliveryMan.Visibility = Visibility.Collapsed;

                            if (order.status.Equals("Ready"))
                            {
                                btn_save.Content = MainWindow.resourcemanager.GetString("trDone");
                                btn_save.IsEnabled = true;
                            }
                        }

                        #endregion
                    }
                }

                /*
                SectionData.clearValidate(requiredControlList, this);
                */
                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                SectionData.StartAwait(grid_main);

                searchText = "";
                tb_search.Text = "";
                chk_allForDelivery.IsChecked = true;
                cb_searchUser.SelectedIndex = -1;
                cb_searchCompany.SelectedIndex = -1;
                selectedOrders.Clear();
                await Search();
                
                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                /*
                if (FillCombo.groupObject.HasPermissionAction(updatePermission, FillCombo.groupObjects, "one"))
                {
                    SectionData.StartAwait(grid_main);

                    if (selectedOrders.Count > 1)
                        requiredControlList = new List<string>();
                    else if (selectedOrders.Count == 1 )
                    {

                        if (selectedOrders[0] != null && selectedOrders[0].invoiceId == 0)
                        {
                            SectionData.EndAwait(grid_main);
                            return;
                        }
                        if (chk_drivers.IsChecked == true)
                            requiredControlList = new List<string>() { "userId" };
                        if (chk_shippingCompanies.IsChecked == true)
                            requiredControlList = new List<string>() { "companyId" };
                    }
                    else if(selectedOrders.Count == 0 && order != null)
                    {
                        if(order.invoiceId == 0)
                        {
                            SectionData.EndAwait(grid_main);
                            return;
                        }
                        selectedOrders.Add(order);
                        if (chk_drivers.IsChecked == true)
                            requiredControlList = new List<string>() { "userId" };
                        if (chk_shippingCompanies.IsChecked == true)
                            requiredControlList = new List<string>() { "companyId" };
                    }
                    

                    #region add
                    if (SectionData.validate(requiredControlList, this))
                    {
                        foreach(Invoice i in selectedOrders)
                        { 
                            int? driverID = i.shipUserId;
                            int comID = i.shippingCompanyId.Value;

                            orderPreparingStatus ops = new orderPreparingStatus();

                            if (i.shipUserId != null)
                            {
                                if (i.status.Equals("Ready"))
                                {
                                    ops.status = "Collected";
                                    if(selectedOrders.Count == 1)
                                        driverID = (int)cb_userId.SelectedValue;
                                    else
                                        driverID = i.shipUserId;
                                }
                                else if (i.status.Equals("Collected"))
                                {
                                    ops.status = "InTheWay";
                                    if (selectedOrders.Count == 1)
                                        driverID = (int)cb_userId.SelectedValue;
                                    else
                                        driverID = i.shipUserId;
                                }
                                else if (i.status.Equals("InTheWay"))
                                {
                                    ops.status = "Done";
                                    driverID = i.shipUserId;

                                    await savePayments(i);
                                }
                            }
                            else
                            {
                                if (i.status.Equals("Ready"))
                                {
                                    ops.status = "Done";
                                    if (selectedOrders.Count == 1)
                                        comID = (int)cb_companyId.SelectedValue;
                                    else
                                        comID = i.shippingCompanyId.Value;

                                    await savePayments(i);
                                }
                            }
                            ops.createUserId = MainWindow.userLogin.userId;
                            ops.updateUserId = MainWindow.userLogin.userId;
                            ops.notes = tb_notes.Text;
                            ops.isActive = 1;

                            int res = await orderModel.EditInvoiceOrdersStatus(i.invoiceId, driverID, comID, ops);

                            if (!res.Equals(0))
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }

                        
                        if (chk_shippingCompanies.IsChecked == true)
                            await RefreshOrdersList("");
                        await Search();
                        Clear();
                    }
                    
                    #endregion
                    
                    SectionData.EndAwait(grid_main);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                */
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private async void Btn_updateDeliveryMan_Click(object sender, RoutedEventArgs e)
        {//update driver
            try
            {
                /*
                if (FillCombo.groupObject.HasPermissionAction(updatePermission, FillCombo.groupObjects, "one"))
                {
                    SectionData.StartAwait(grid_main);

                    if (selectedOrders.Count >= 1)
                    {
                        if (chk_drivers.IsChecked == true)
                            requiredControlList = new List<string>() { "userId" };
                        if (chk_shippingCompanies.IsChecked == true)
                            requiredControlList = new List<string>() { "companyId" };
                    }
                    else if (selectedOrders.Count == 0 && order != null)
                    {
                        selectedOrders.Add(order);
                        if (chk_drivers.IsChecked == true)
                            requiredControlList = new List<string>() { "userId" };
                        if (chk_shippingCompanies.IsChecked == true)
                            requiredControlList = new List<string>() { "companyId" };
                    }
                    #region update
                    if (SectionData.validate(requiredControlList, this))
                    {
                        foreach (Invoice i in selectedOrders)
                        {
                            int? driverID = i.shipUserId;
                            int comID = i.shippingCompanyId.Value;

                            if (i.shipUserName != null)
                            {
                                if (i.status.Equals("Ready"))
                                {
                                    driverID = (int)cb_userId.SelectedValue;
                                }
                                else if (i.status.Equals("Collected"))
                                {
                                    driverID = (int)cb_userId.SelectedValue;
                                }
                                else if (i.status.Equals("InTheWay"))
                                {
                                    driverID = i.shipUserId;
                                }
                            }
                            else
                            {
                                if (i.status.Equals("Ready"))
                                {
                                    comID = (int)cb_companyId.SelectedValue;
                                }
                            }

                            int res = await orderModel.EditInvoiceDelivery(i.invoiceId, driverID, comID);

                            if (!res.Equals(0))
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        }
                        if (chk_shippingCompanies.IsChecked == true)
                            await RefreshOrdersList("");

                        await Search();
                        Clear();
                    }

                    #endregion

                    SectionData.EndAwait(grid_main);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                */
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }


        #endregion

        #region payments
        private async Task savePayments(Invoice invoice)
        {
            /*
            invoice.updateUserId = MainWindow.userLog.userId;
            if (invoice.shippingCompanyId != null && invoice.shipUserId == null)
                await invoice.recordCompanyCashTransfer(invoice, "si");
            else
                await invoice.recordCashTransfer(invoice, "si");
            */
        }
        #endregion

        #region events
        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.IsKeyDown(Key.LeftCtrl) || e.KeyboardDevice.IsKeyDown(Key.RightCtrl))
            {
                switch (e.Key)
                {
                    case Key.S:
                        //handle S key
                        Btn_save_Click(btn_save, null);
                        break;

                }
            }
        }
        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            Instance = null;
            GC.Collect();
        }
        private void FieldDataGridCheckedHeader(object sender, RoutedEventArgs e)
        {
            try
            {
             

                selectedOrders.Clear();
                var chkSelectAll = sender as CheckBox;
                if (chk_allForDelivery.IsChecked == true)
                {
                    chkSelectAll.IsChecked = false;
                }
                else
                {
                    var firstCol = dg_orders.Columns.OfType<DataGridCheckBoxColumn>().FirstOrDefault(c => c.DisplayIndex == 0);
                    var statusCol = dg_orders.Columns[1] as DataGridTextColumn;
                    if (chkSelectAll == null || firstCol == null || dg_orders?.Items == null || dg_orders.Items.Count == 0)
                    {
                        return;
                    }

                    var item0 = dg_orders.Items[0] as Invoice;

                    #region refreshSaveBtnText
                    if (item0.shipUserId != null)
                    {
                        //bdr_cbDeliveryCompany.Visibility = Visibility.Collapsed;
                        grid_deliveryCompany.Visibility = Visibility.Collapsed;

                        if (item0.status.Equals("Ready"))
                        {
                            btn_save.Content = MainWindow.resourcemanager.GetString("trCollect");
                            btn_save.IsEnabled = true;
                            //bdr_cbDeliveryMan.Visibility = Visibility.Visible;
                            grid_deliveryMan.Visibility = Visibility.Visible;
                            bdr_tbDeliveryMan.Visibility = Visibility.Collapsed;
                        }
                        else if (item0.status.Equals("Collected"))
                        {
                            btn_save.Content = MainWindow.resourcemanager.GetString("onTheWay");
                            btn_save.IsEnabled = true;
                            //bdr_cbDeliveryMan.Visibility = Visibility.Visible;
                            grid_deliveryMan.Visibility = Visibility.Visible;
                            bdr_tbDeliveryMan.Visibility = Visibility.Collapsed;
                        }
                        else if (item0.status.Equals("InTheWay"))
                        {
                            btn_save.Content = MainWindow.resourcemanager.GetString("trDone");
                            btn_save.IsEnabled = true;
                            //bdr_cbDeliveryMan.Visibility = Visibility.Collapsed;
                            grid_deliveryMan.Visibility = Visibility.Collapsed;
                            bdr_tbDeliveryMan.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        grid_deliveryCompany.Visibility = Visibility.Visible;
                        //bdr_cbDeliveryCompany.Visibility = Visibility.Visible;
                        //bdr_cbDeliveryMan.Visibility = Visibility.Collapsed;
                        grid_deliveryMan.Visibility = Visibility.Collapsed;
                        bdr_tbDeliveryMan.Visibility = Visibility.Collapsed;

                        if (item0.status.Equals("Ready"))
                        {
                            btn_save.Content = MainWindow.resourcemanager.GetString("trDone");
                            btn_save.IsEnabled = true;
                        }
                    }

                    #endregion

                    foreach (var item in dg_orders.Items)
                    {
                        var chBx = firstCol.GetCellContent(item) as CheckBox;
                        if (chBx == null)
                        {
                            continue;
                        }

                        var txt = item as Invoice;
                        if (txt == null)
                        {
                            continue;
                        }
                        if (txt.status.Equals(item0.status) &&
                            ((txt.shipUserId == null && item0.shipUserId == null) || (txt.shipUserId != null && item0.shipUserId != null)))
                        {
                            chBx.IsChecked = chkSelectAll.IsChecked;

                            if (item0.status == "InTheWay")
                                requiredControlList = new List<string>();
                            else
                            {
                                if (item0.shipUserId == null)
                                    requiredControlList = new List<string> { "companyId" };
                                else
                                    requiredControlList = new List<string> { "userId" };
                            }
                            selectedOrders.Add(txt);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void FieldDataGridUncheckedHeader(object sender, RoutedEventArgs e)
        {
            var chkSelectAll = sender as CheckBox;
            if (chk_allForDelivery.IsChecked == true)
            {
                chkSelectAll.IsChecked = false;
            }
            else
            {
                var firstCol = dg_orders.Columns.OfType<DataGridCheckBoxColumn>().FirstOrDefault(c => c.DisplayIndex == 0);
                if (chkSelectAll == null || firstCol == null || dg_orders?.Items == null || dg_orders.Items.Count == 0)
                {
                    return;
                }
                foreach (var item in dg_orders.Items)
                {
                    var chBx = firstCol.GetCellContent(item) as CheckBox;
                    if (chBx == null)
                    {
                        continue;
                    }
                    chBx.IsChecked = chkSelectAll.IsChecked;
                }
            }
        }
        List<Invoice> selectedOrders = new List<Invoice>();
        private void FieldDataGridChecked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (chk_allForDelivery.IsChecked == true)
                {
                    selectedOrders.Clear();
                }
                //else
                //{
                    Invoice selectedOrder = dg_orders.SelectedItem as Invoice;
                    if (selectedOrder != null)
                        selectedOrders.Add(selectedOrder);
                //}
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void FieldDataGridUnchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (chk_allForDelivery.IsChecked == true)
                {
                    selectedOrders.Clear();
                }
                //else
                //{
                var index = dg_orders.SelectedIndex;
                    Invoice selectedOrder = dg_orders.SelectedItem as Invoice;
                    selectedOrders.Remove(selectedOrder);
                //}
            
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void search_Checking(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedOrders.Clear();

                CheckBox cb = sender as CheckBox;
                if (cb.IsChecked == true)
                {
                    if (cb.Name == "chk_allForDelivery")
                    {
                        chk_readyForDelivery.IsChecked = false;
                        chk_withDeliveryMan.IsChecked = false;
                        chk_inTheWay.IsChecked = false;
                        col_chk.Visibility = Visibility.Collapsed;
                        //btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

                    }
                    else if (cb.Name == "chk_readyForDelivery")
                    {
                        chk_allForDelivery.IsChecked = false;
                        chk_withDeliveryMan.IsChecked = false;
                        chk_inTheWay.IsChecked = false;
                        col_chk.Visibility = Visibility.Visible;
                        //btn_save.Content = MainWindow.resourcemanager.GetString("trCollect");
                    }
                    else if (cb.Name == "chk_withDeliveryMan")
                    {
                        chk_allForDelivery.IsChecked = false;
                        chk_readyForDelivery.IsChecked = false;
                        chk_inTheWay.IsChecked = false;
                        col_chk.Visibility = Visibility.Visible;
                        //btn_save.Content = MainWindow.resourcemanager.GetString("onTheWay");

                    }
                    else if (cb.Name == "chk_inTheWay")
                    {
                        chk_allForDelivery.IsChecked = false;
                        chk_readyForDelivery.IsChecked = false;
                        chk_withDeliveryMan.IsChecked = false;
                        col_chk.Visibility = Visibility.Visible;
                        //btn_save.Content = MainWindow.resourcemanager.GetString("trDone");
                    }
                }
                SectionData.StartAwait(grid_main);

                Clear();
                await Search();

                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void chk_uncheck(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (cb.IsFocused)
                {
                    if (cb.Name == "chk_allForDelivery")
                        chk_allForDelivery.IsChecked = true;
                    else if (cb.Name == "chk_readyForDelivery")
                        chk_readyForDelivery.IsChecked = true;
                    else if (cb.Name == "chk_withDeliveryMan")
                        chk_withDeliveryMan.IsChecked = true;
                    else if (cb.Name == "chk_inTheWay")
                        chk_inTheWay.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        string input;
        decimal _decimal = 0;
        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only  digits
            try
            {
                TextBox textBox = sender as TextBox;
                SectionData.InputJustNumber(ref textBox);
                if (textBox.Tag.ToString() == "int")
                {
                    Regex regex = new Regex("[^0-9]");
                    e.Handled = regex.IsMatch(e.Text);
                }
                else if (textBox.Tag.ToString() == "decimal")
                {
                    input = e.Text;
                    e.Handled = !decimal.TryParse(textBox.Text + input, out _decimal);

                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only english and digits
            try
            {
                Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
                if (!regex.IsMatch(e.Text))
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }

        }
        private void Spaces_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void ValidateEmpty_TextChange(object sender, TextChangedEventArgs e)
        {
            try
            {
                /*
                SectionData.validate(requiredControlList, this);
                */
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void validateEmpty_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
/*
                SectionData.validate(requiredControlList, this);
                */
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void deliveryType_check(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (cb.IsFocused)
                {
                    SectionData.StartAwait(grid_main);
                    if (cb.IsChecked == true)
                    {
                        selectedOrders.Clear();
                        if (cb.Name == "chk_drivers")
                        {
                            chk_shippingCompanies.IsChecked = false;
                            col_driver.Visibility = Visibility.Visible;
                            col_company.Visibility = Visibility.Hidden;
                            bdr_searchCompany.Visibility = Visibility.Collapsed;
                            cb_companyId.SelectedIndex = -1;
                            bdr_searchUser.Visibility = Visibility.Visible;
                            col_cbDriver.Width = new GridLength(1, GridUnitType.Star);
                            col_cbCompany.Width = new GridLength(0, GridUnitType.Star);
                            //col_cbDriver.Width = col_cbCompany.Width;
                            chk_allForDelivery.Visibility = Visibility.Visible;
                            chk_readyForDelivery.Visibility = Visibility.Visible;
                            chk_withDeliveryMan.Visibility = Visibility.Visible;
                            chk_inTheWay.Visibility = Visibility.Visible;
                            chk_allForDelivery.IsChecked = true;

                            //bdr_cbDeliveryCompany.Visibility = Visibility.Collapsed;
                            //bdr_cbDeliveryMan.Visibility = Visibility.Visible;
                            grid_deliveryMan.Visibility = Visibility.Visible;
                            grid_deliveryCompany.Visibility = Visibility.Collapsed;


                        }
                        else if (cb.Name == "chk_shippingCompanies")
                        {
                            col_chk.Visibility = Visibility.Visible;
                            chk_drivers.IsChecked = false;
                            col_driver.Visibility = Visibility.Hidden;
                            col_company.Visibility = Visibility.Visible;
                            bdr_searchCompany.Visibility = Visibility.Visible;
                            bdr_searchUser.Visibility = Visibility.Hidden;
                            cb_searchUser.SelectedIndex = -1;
                            col_cbDriver.Width = new GridLength(0, GridUnitType.Star);
                            col_cbCompany.Width = new GridLength(1, GridUnitType.Star);
                            chk_allForDelivery.Visibility = Visibility.Hidden;
                            chk_readyForDelivery.Visibility = Visibility.Hidden;
                            chk_withDeliveryMan.Visibility = Visibility.Hidden;
                            chk_inTheWay.Visibility = Visibility.Hidden;
                            chk_allForDelivery.IsChecked = false;

                            //bdr_cbDeliveryCompany.Visibility = Visibility.Visible;
                            //bdr_cbDeliveryMan.Visibility = Visibility.Collapsed;
                            grid_deliveryMan.Visibility = Visibility.Collapsed;
                            grid_deliveryCompany.Visibility = Visibility.Visible;
                        }
                        await RefreshOrdersList("");
                        await Search();
                    }
                    SectionData.EndAwait(grid_main);

                }
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void deliveryType_uncheck(object sender, RoutedEventArgs e)
        {
            try
            {
                CheckBox cb = sender as CheckBox;
                if (cb.IsFocused)
                {
                    if (cb.Name == "chk_drivers")
                        chk_drivers.IsChecked = true;
                    else if (cb.Name == "chk_shippingCompanies")
                        chk_shippingCompanies.IsChecked = true;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void selectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
           
        }

        #endregion

        #region report
        //report  parameters
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        // end report parameters
        public void BuildReport()
        {

            List<ReportParameter> paramarr = new List<ReportParameter>();

            string addpath;
            bool isArabic = ReportCls.checkLang();
            if (isArabic)
            {
                addpath = @"\Reports\Delivery\Ar\ArDeliveryManag.rdlc";
            }
            else
            {
                addpath = @"\Reports\Delivery\En\EnDeliveryManag.rdlc";
            }
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            int isdriver = 0;
            if (chk_drivers.IsChecked == true)
            {
                isdriver = 1;
            }
            else
            {
              
                isdriver = 0;

            }
            /*
            clsReports.deliveryManagement(orders.ToList(), rep, reppath, paramarr,isdriver);
            */
            clsReports.setReportLanguage(paramarr);
            clsReports.Header(paramarr);

            rep.SetParameters(paramarr);

            rep.Refresh();

        }
        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            //pdf
            try
            {

                SectionData.StartAwait(grid_main);

                //if (FillCombo.groupObject.HasPermissionAction(basicsPermission, FillCombo.groupObjects, "report"))
                //{
                #region
                BuildReport();

                saveFileDialog.Filter = "PDF|*.pdf;";

                if (saveFileDialog.ShowDialog() == true)
                {
                    string filepath = saveFileDialog.FileName;
                    LocalReportExtensions.ExportToPDF(rep, filepath);
                }
                #endregion
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {

                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SectionData.StartAwait(grid_main);
                //if (FillCombo.groupObject.HasPermissionAction(basicsPermission, FillCombo.groupObjects, "report"))
                //{

                #region
                BuildReport();
                LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, MainWindow.rep_print_count == null ? short.Parse("1") : short.Parse(MainWindow.rep_print_count));
                #endregion
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);


                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {

                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SectionData.StartAwait(grid_main);

                //if (FillCombo.groupObject.HasPermissionAction(basicsPermission, FillCombo.groupObjects, "report"))
                //{
                #region
                //Thread t1 = new Thread(() =>
                //{
                BuildReport();
                this.Dispatcher.Invoke(() =>
                {
                    saveFileDialog.Filter = "EXCEL|*.xls;";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filepath = saveFileDialog.FileName;
                        LocalReportExtensions.ExportToExcel(rep, filepath);
                    }
                });


                //});
                //t1.Start();
                #endregion
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);


                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {

                SectionData.EndAwait(grid_main);

                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                SectionData.StartAwait(grid_main);
                //if (FillCombo.groupObject.HasPermissionAction(basicsPermission, FillCombo.groupObjects, "report"))
                //{
                #region
                Window.GetWindow(this).Opacity = 0.2;

                string pdfpath = "";
                //
                pdfpath = @"\Thumb\report\temp.pdf";
                pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                BuildReport();

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
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);


                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }

        private void Btn_pieChart_Click(object sender, RoutedEventArgs e)
        {//pie
            try
            {
                SectionData.StartAwait(grid_main);

                //if (FillCombo.groupObject.HasPermissionAction(basicsPermission, FillCombo.groupObjects, "report"))
                //{
                #region
                Window.GetWindow(this).Opacity = 0.2;
                /*
                win_lvcSales win = new win_lvcSales(orders, 7);
                win.ShowDialog();
                */
                Window.GetWindow(this).Opacity = 1;
                #endregion
                //}
                //else
                //    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }

        }
        #endregion


    }
}
