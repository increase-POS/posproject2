using netoaster;
using POS.Classes;
using POS.View.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

namespace POS.View.catalog
{
    /// <summary>
    /// Interaction logic for uc_storageCost.xaml
    /// </summary>
    public partial class uc_storageCost : UserControl
    {


        private static uc_storageCost _instance;
        public static uc_storageCost Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_storageCost();
                return _instance;
            }
        }
        public uc_storageCost()
        {
            try
            {
                InitializeComponent();
                if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1440)
                {
                    txt_deleteButton.Visibility = Visibility.Visible;
                    txt_addButton.Visibility = Visibility.Visible;
                    txt_updateButton.Visibility = Visibility.Visible;
                    txt_add_Icon.Visibility = Visibility.Visible;
                    txt_update_Icon.Visibility = Visibility.Visible;
                    txt_delete_Icon.Visibility = Visibility.Visible;
                }
                else if (System.Windows.SystemParameters.PrimaryScreenWidth >= 1360)
                {
                    txt_add_Icon.Visibility = Visibility.Collapsed;
                    txt_update_Icon.Visibility = Visibility.Collapsed;
                    txt_delete_Icon.Visibility = Visibility.Collapsed;
                    txt_deleteButton.Visibility = Visibility.Visible;
                    txt_addButton.Visibility = Visibility.Visible;
                    txt_updateButton.Visibility = Visibility.Visible;

                }
                else
                {
                    txt_deleteButton.Visibility = Visibility.Collapsed;
                    txt_addButton.Visibility = Visibility.Collapsed;
                    txt_updateButton.Visibility = Visibility.Collapsed;
                    txt_add_Icon.Visibility = Visibility.Visible;
                    txt_update_Icon.Visibility = Visibility.Visible;
                    txt_delete_Icon.Visibility = Visibility.Visible;

                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }
        StorageCost storageCost = new StorageCost();
        StorageCost storageCostModel = new StorageCost();
        BrushConverter bc = new BrushConverter();
        IEnumerable<StorageCost> storageCostQuery;
        IEnumerable<StorageCost> storageCosts;
        byte tgl_storageCostState;
        string searchText = "";
        string basicsPermission = "storageCost_basics";

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                SectionData.StartAwait(grid_ucStorageCost);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    if (storageCosts is null)
                        await RefreshStorageCostList();
                    searchText = tb_search.Text.ToLower();
                    storageCostQuery = storageCosts.Where(s => (s.name.ToLower().Contains(searchText) ||
                    s.cost.ToString().Contains(searchText)
                    ) && s.isActive == tgl_storageCostState);
                    RefreshstorageCostView();
                }
                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        async Task<IEnumerable<StorageCost>> RefreshStorageCostList()
        {
            storageCosts = await storageCostModel.Get();
            return storageCosts;
        }
        void RefreshstorageCostView()
        {
            dg_storageCost.ItemsSource = storageCostQuery;
            txt_count.Text = storageCostQuery.Count().ToString();
        }
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {//active
            try
            {
            SectionData.StartAwait(grid_ucStorageCost);
                if (storageCosts is null)
                    await RefreshStorageCostList();
                tgl_storageCostState = 1;
                Tb_search_TextChanged(null, null);
                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {//inactive
            try
            {
                SectionData.StartAwait(grid_ucStorageCost);
                if (storageCosts is null)
                    await RefreshStorageCostList();
                tgl_storageCostState = 0;
                Tb_search_TextChanged(null, null);
                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                SectionData.StartAwait(grid_ucStorageCost);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    await RefreshStorageCostList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            try
            {
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    this.Dispatcher.Invoke(() =>
                    {
                        Thread t1 = new Thread(FN_ExportToExcel);
                        t1.SetApartmentState(ApartmentState.STA);
                        t1.Start();
                    });
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        void FN_ExportToExcel()
        {
            var QueryExcel = storageCostQuery.AsEnumerable().Select(x => new
            {
                name = x.name,
                cost = x.cost,
                note = x.note
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trStorageCost");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            try
            {
                tb_name.Clear();
                tb_cost.Clear();
                tb_notes.Clear();

                SectionData.clearValidate(tb_name, p_errorName);
                SectionData.clearValidate(tb_cost, p_errorCost);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_cost")
                    SectionData.InputJustNumber(ref txb);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                validateEmpty(name, sender);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            try
            {
                SectionData.StartAwait(grid_ucStorageCost);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty delivery cost
                    SectionData.validateEmptyTextBox(tb_cost, p_errorCost, tt_errorCost, "trEmptyStoreCost");

                    if ((!tb_name.Text.Equals("")) && (!tb_cost.Text.Equals("")))
                    {
                        StorageCost storageCost = new StorageCost();

                        storageCost.name = tb_name.Text;
                        storageCost.cost = decimal.Parse(tb_cost.Text);
                        storageCost.note = tb_notes.Text;
                        storageCost.createUserId = MainWindow.userID;
                        storageCost.isActive = 1;

                        string s = await storageCostModel.Save(storageCost);
                        if (!s.Equals("-1"))
                        {
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                            Btn_clear_Click(null, null);

                            await RefreshStorageCostList();
                            Tb_search_TextChanged(null, null);
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            try
            {
                SectionData.StartAwait(grid_ucStorageCost);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty delivery cost
                    SectionData.validateEmptyTextBox(tb_cost, p_errorCost, tt_errorCost, "trEmptyStoreCost");

                    if ((!tb_name.Text.Equals("")) && (!tb_cost.Text.Equals("")))
                    {
                        storageCost.name = tb_name.Text;
                        storageCost.cost = decimal.Parse(tb_cost.Text);
                        storageCost.note = tb_notes.Text;
                        storageCost.createUserId = MainWindow.userID;
                        //storageCost.isActive = 1;

                        string s = await storageCostModel.Save(storageCost);
                        if (!s.Equals("-1"))
                        {
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);

                            await RefreshStorageCostList();
                            Tb_search_TextChanged(null, null);
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            try
            {
                SectionData.StartAwait(grid_ucStorageCost);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
                    if (storageCost.storageCostId != 0)
                    {
                        if ((!storageCost.canDelete) && (storageCost.isActive == 0))
                        {
                            #region
                            Window.GetWindow(this).Opacity = 0.2;
                            wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                            w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxActivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion
                            if (w.isOk)
                                activate();
                        }
                        else
                        {
                            #region
                            Window.GetWindow(this).Opacity = 0.2;
                            wd_acceptCancelPopup w = new wd_acceptCancelPopup();
                            if (storageCost.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                            if (!storageCost.canDelete)
                                w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                            w.ShowDialog();
                            Window.GetWindow(this).Opacity = 1;
                            #endregion

                            if (w.isOk)
                            {
                                string popupContent = "";
                                if (storageCost.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                                if ((!storageCost.canDelete) && (storageCost.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                                string b = await storageCostModel.Delete(storageCost.storageCostId, MainWindow.userID.Value, storageCost.canDelete);

                                if (!b.Equals("-1"))
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);

                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                            }
                        }

                        await RefreshStorageCostList();
                        Tb_search_TextChanged(null, null);

                        //clear textBoxs
                        Btn_clear_Click(null, null);
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void activate()
        {//activate
            storageCost.isActive = 1;

            string s = await storageCostModel.Save(storageCost);

            if (!s.Equals("0"))
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshStorageCostList();
            Tb_search_TextChanged(null, null);

        }

        private void Dg_storageCost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                SectionData.clearValidate(tb_name, p_errorName);
                SectionData.clearValidate(tb_cost, p_errorCost);
                if (dg_storageCost.SelectedIndex != -1)
                {
                    storageCost = dg_storageCost.SelectedItem as StorageCost;
                    this.DataContext = storageCost;

                    if (storageCost != null)
                    {
                        #region delete
                        if (storageCost.canDelete)
                        {
                            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                            txt_delete_Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete;
                            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
                        }

                        else
                        {
                            if (storageCost.isActive == 0)
                            {
                                txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                                txt_delete_Icon.Kind =
                                 MaterialDesignThemes.Wpf.PackIconKind.Check;
                                tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");
                            }
                            else
                            {
                                txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                                txt_delete_Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                                tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");
                            }
                        }
                        #endregion

                    }
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                SectionData.StartAwait(grid_ucStorageCost);

                if (MainWindow.lang.Equals("en"))
                { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_shipping.FlowDirection = FlowDirection.LeftToRight; }
                else
                { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_shipping.FlowDirection = FlowDirection.RightToLeft; }

                translat();


                await RefreshStorageCostList();
                Tb_search_TextChanged(null, null);
                SectionData.EndAwait(grid_ucStorageCost, this);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void translat()
        {
            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_storageCost.Text = MainWindow.resourcemanager.GetString("trStorageCost");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cost, MainWindow.resourcemanager.GetString("trStorageCostHent"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_storageCost.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_storageCost.Columns[1].Header = MainWindow.resourcemanager.GetString("trStorageCost");

            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");

            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_cost.Content = MainWindow.resourcemanager.GetString("trStorageCost");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
        }

        private void Tb_PreventSpaces(object sender, KeyEventArgs e)
        {
            try
            {
                e.Handled = e.Key == Key.Space;

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void Tb_Numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private void validateEmpty(string name, object sender)
        {
            try
            {
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_name")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    else if ((sender as TextBox).Name == "tb_cost")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorCost, tt_errorCost, "trEmptyStoreCost");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }
    }
}
