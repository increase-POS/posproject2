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

namespace POS.View.sectionData
{
    /// <summary>
    /// Interaction logic for uc_shippingCompany.xaml
    /// </summary>
    public partial class uc_shippingCompany : UserControl
    {
        ShippingCompanies shCompany = new ShippingCompanies();
        ShippingCompanies shCompaniesModel = new ShippingCompanies();
        BrushConverter bc = new BrushConverter();
        IEnumerable<ShippingCompanies> shComQuery;
        IEnumerable<ShippingCompanies> shComs;
        byte tgl_shComState;
        string searchText = "";
        string basicsPermission = "shippingCompany_basics";
        private static uc_shippingCompany _instance;
        public static uc_shippingCompany Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_shippingCompany();
                return _instance;
            }
        }
        public uc_shippingCompany()
        {
            InitializeComponent();
        }
        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show"))
            {
                if (shComs is null)
                    await RefreshShComList();
                searchText = tb_search.Text.ToLower();
                shComQuery = shComs.Where(s => (s.name.ToLower().Contains(searchText) ||
                s.deliveryType.Contains(searchText) ||
                s.deliveryCost.ToString().ToLower().Contains(searchText) ||
                s.RealDeliveryCost.ToString().ToLower().Contains(searchText)
                ) && s.isActive == tgl_shComState);
                RefreshshComView();
            }
        }

        async Task<IEnumerable<ShippingCompanies>> RefreshShComList()
        {
            MainWindow.mainWindow.StartAwait();

            shComs = await shCompaniesModel.Get();
            MainWindow.mainWindow.EndAwait();
            return shComs;
        }
        void RefreshshComView()
        {
            dg_shippingCompany.ItemsSource = shComQuery;
            txt_count.Text = shComQuery.Count().ToString();
        }
        private async void Tgl_isActive_Checked(object sender, RoutedEventArgs e)
        {//active
            if (shComs is null)
                await RefreshShComList();
            tgl_shComState = 1;
            Tb_search_TextChanged(null, null);
        }

        private async void Tgl_isActive_Unchecked(object sender, RoutedEventArgs e)
        {//inactive
            if (shComs is null)
                await RefreshShComList();
            tgl_shComState = 0;
            Tb_search_TextChanged(null, null);
        }

        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show"))
            {
                await RefreshShComList();
                Tb_search_TextChanged(null, null);
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
            
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report"))
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

        void FN_ExportToExcel()
        {
            var QueryExcel = shComQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                RealDeliverCost = x.RealDeliveryCost,
                DeliveryCost = x.deliveryCost,
                DeliverType = x.deliveryType,
                Notes = x.notes
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trRealDeliveryCost");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trDeliveryCost");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trDeliveryType");
            DTForExcel.Columns[4].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);
        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_name.Clear();
            tb_realDeliveryCost.Clear();
            tb_deliveryCost.Clear();
            cb_deliveryType.SelectedIndex = -1;
            tb_notes.Clear();

            SectionData.clearValidate(tb_name , p_errorName);
            SectionData.clearValidate(tb_deliveryCost, p_errorDeliveryCost);
            SectionData.clearValidate(tb_realDeliveryCost, p_errorRealDeliveryCost);
            SectionData.clearComboBoxValidate(cb_deliveryType , p_errorDeliveryType);
        }

        private void validationControl_LostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void validationTextbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }

        private void Tb_validateEmptyLostFocus(object sender, RoutedEventArgs e)
        {
            string name = sender.GetType().Name;
            validateEmpty(name, sender);
        }
        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add"))
            {
                //chk empty name
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty delivery cost
            SectionData.validateEmptyTextBox(tb_deliveryCost, p_errorDeliveryCost, tt_errorDeliveryCost, "trEmptyDeliveryCostToolTip");
            //chk empty real delivery cost
            SectionData.validateEmptyTextBox(tb_realDeliveryCost, p_errorRealDeliveryCost, tt_errorRealDeliveryCost, "trEmptyRealDeliveryCostToolTip");
            //chk empty real delivery type
            SectionData.validateEmptyComboBox(cb_deliveryType, p_errorDeliveryType, tt_errorDeliveryType, "trEmptyDeliveryTypeToolTip");

            if ((!tb_name.Text.Equals("")) && (!tb_realDeliveryCost.Text.Equals("")) && (!tb_deliveryCost.Text.Equals("")) && (!cb_deliveryType.Text.Equals("")))
            {
                ShippingCompanies shCom = new ShippingCompanies();

                shCom.name = tb_name.Text;
                shCom.RealDeliveryCost = decimal.Parse(tb_realDeliveryCost.Text);
                shCom.deliveryCost = decimal.Parse(tb_deliveryCost.Text);
                shCom.deliveryType = cb_deliveryType.SelectedValue.ToString();
                shCom.notes = tb_notes.Text;
                shCom.createUserId = MainWindow.userID;
                shCom.isActive = 1;

                string s = await shCompaniesModel.Save(shCom);
                //MessageBox.Show(s);
                if (!s.Equals("0"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                    Btn_clear_Click(null, null);

                    await RefreshShComList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update"))
            {
                //chk empty name
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            //chk empty delivery cost
            SectionData.validateEmptyTextBox(tb_deliveryCost, p_errorDeliveryCost, tt_errorDeliveryCost, "trEmptyDeliveryCostToolTip");
            //chk empty real delivery cost
            SectionData.validateEmptyTextBox(tb_realDeliveryCost, p_errorRealDeliveryCost, tt_errorRealDeliveryCost, "trEmptyRealDeliveryCostToolTip");
            //chk empty real delivery type
            SectionData.validateEmptyComboBox(cb_deliveryType, p_errorDeliveryType, tt_errorDeliveryType, "trEmptyDeliveryTypeToolTip");

            if ((!tb_name.Text.Equals("")) && (!tb_realDeliveryCost.Text.Equals("")) && (!tb_deliveryCost.Text.Equals("")) && (!cb_deliveryType.Text.Equals("")))
            {
                shCompany.name = tb_name.Text;
                shCompany.RealDeliveryCost = decimal.Parse(tb_realDeliveryCost.Text);
                shCompany.deliveryCost = decimal.Parse(tb_deliveryCost.Text);
                shCompany.deliveryType = cb_deliveryType.SelectedValue.ToString();
                shCompany.notes = tb_notes.Text;
                shCompany.createUserId = MainWindow.userID;
                shCompany.isActive = 1;

                string s = await shCompaniesModel.Save(shCompany);
                //MessageBox.Show(s);
                if (!s.Equals("0"))
                {
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                    
                    await RefreshShComList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete"))
            {
                if (shCompany.shippingCompanyId != 0)
            {
                if ((!shCompany.canDelete) && (shCompany.isActive == 0))
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
                    if (shCompany.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    if (!shCompany.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion

                    if (w.isOk)
                    {
                        string popupContent = "";
                        if (shCompany.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                        if ((!shCompany.canDelete) && (shCompany.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                        string b = await shCompaniesModel.Delete(shCompany.shippingCompanyId, MainWindow.userID.Value, shCompany.canDelete);

                        if (!b.Equals("0"))
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopDelete"), animation: ToasterAnimation.FadeIn);

                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                    }
                }

                await RefreshShComList();
                Tb_search_TextChanged(null, null);

                //clear textBoxs
                Btn_clear_Click(sender, e);
            }
            }
            else
                Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
        }

        private async void activate()
        {//activate
            shCompany.isActive = 1;

            string s = await shCompaniesModel.Save(shCompany);

            if (!s.Equals("0"))
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshShComList();
            Tb_search_TextChanged(null, null);

        }

        private void Dg_shippingCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            SectionData.clearValidate(tb_name, p_errorName);
            SectionData.clearValidate(tb_realDeliveryCost, p_errorRealDeliveryCost);
            SectionData.clearValidate(tb_deliveryCost, p_errorDeliveryCost);
            SectionData.clearComboBoxValidate(cb_deliveryType, p_errorDeliveryType);


            if (dg_shippingCompany.SelectedIndex != -1)
            {
                shCompany = dg_shippingCompany.SelectedItem as ShippingCompanies;
                this.DataContext = shCompany;

                if (shCompany != null)
                {
                    //MessageBox.Show(shCompany.shippingCompanyId.ToString());
                    cb_deliveryType.SelectedValue = shCompany.deliveryType;
                    
                    #region delete
                    if (shCompany.canDelete)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                        txt_delete_Icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.Delete;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
                    }

                    else
                    {
                        if (shCompany.isActive == 0)
                        {
                            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                            txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Check;
                            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");
                        }
                        else
                        {
                            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                            txt_delete_Icon.Kind  = MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");
                        }
                    }
                    #endregion

                }
            }
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_shipping.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_shipping.FlowDirection = FlowDirection.RightToLeft; }

            translat();

            #region fill delivery type
            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trLocaly")     , Value = "local" },
            new { Text = MainWindow.resourcemanager.GetString("trShippingCompany")   , Value = "com" },
             };
            cb_deliveryType.DisplayMemberPath = "Text";
            cb_deliveryType.SelectedValuePath = "Value";
            cb_deliveryType.ItemsSource = typelist;
            #endregion

            await RefreshShComList();
            Tb_search_TextChanged(null, null);
        }

        private void translat()
        {
            txt_active.Text = MainWindow.resourcemanager.GetString("trActive");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_shippingCompany.Text = MainWindow.resourcemanager.GetString("trShippingCompanies");
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_realDeliveryCost , MainWindow.resourcemanager.GetString("trRealDeliveryCostHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_deliveryCost, MainWindow.resourcemanager.GetString("trDeliveryCostHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_deliveryType, MainWindow.resourcemanager.GetString("trDeliveryTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_shippingCompany.Columns[0].Header = MainWindow.resourcemanager.GetString("trName");
            dg_shippingCompany.Columns[1].Header = MainWindow.resourcemanager.GetString("trRealDeliveryCost");
            dg_shippingCompany.Columns[2].Header = MainWindow.resourcemanager.GetString("trDeliveryCost");
            dg_shippingCompany.Columns[3].Header = MainWindow.resourcemanager.GetString("trDeliveryType");

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
            tt_realDeliveryCost.Content = MainWindow.resourcemanager.GetString("trRealDeliveryCost");
            tt_deliveryCost.Content = MainWindow.resourcemanager.GetString("trDeliveryCost");
            tt_deliveryType.Content = MainWindow.resourcemanager.GetString("trDeliveryType");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
        }

        private void Tb_PreventSpaces(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;

        }

        private void Tb_Numbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void validateEmpty(string name, object sender)
        {
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_name")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorName, tt_errorName, "trEmptyNameToolTip");
                else if ((sender as TextBox).Name == "tb_realDeliveryCost")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorRealDeliveryCost, tt_errorRealDeliveryCost, "trEmptyRealDeliveryCostToolTip");
                else if ((sender as TextBox).Name == "tb_deliveryCost")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorDeliveryCost, tt_errorDeliveryCost, "trEmptyDeliveryCostToolTip");
            }
            else if (name == "ComboBox")
            {
                if ((sender as ComboBox).Name == "cb_deliveryType")
                    SectionData.validateEmptyComboBox((ComboBox)sender, p_errorDeliveryType, tt_errorDeliveryType, "trErrorEmptyDeliveryTypeToolTip");
            }
           
        }

    }
}
