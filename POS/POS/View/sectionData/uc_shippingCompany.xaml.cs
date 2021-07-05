using netoaster;
using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
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

namespace POS.View.sectionData
{
    /// <summary>
    /// Interaction logic for uc_shippingCompany.xaml
    /// </summary>
    public partial class uc_shippingCompany : UserControl
    {
        ShippingCompanies offer = new ShippingCompanies();
        ShippingCompanies shCompaniesModel = new ShippingCompanies();

        BrushConverter bc = new BrushConverter();
        IEnumerable<ShippingCompanies> shComQuery;
        IEnumerable<ShippingCompanies> shComs;
      
        byte tgl_shComState;
        string searchText = "";

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
            if (shComs is null)
                await RefreshShComList();
            searchText = tb_search.Text.ToLower();
            shComQuery = shComs.Where(s => (s.name.ToLower().Contains(searchText) ||
            s.deliveryType.Contains(searchText) ||
            s.deliveryCost.ToString().ToLower().Contains(searchText)||
            s.RealDeliveryCost.ToString().ToLower().Contains(searchText)
            ) && s.isActive == tgl_shComState);
            RefreshshComView();

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
            await RefreshShComList();
            Tb_search_TextChanged(null, null);
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {

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
                MessageBox.Show(s);
                if (s.Equals("Offer Is Added Successfully"))
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

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Dg_shippingCompany_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_shipping.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_shipping.FlowDirection = FlowDirection.RightToLeft; }

            translat();

            #region fill delivery type
            var typelist = new[] {
            new { Text = MainWindow.resourcemanager.GetString("trLocaly")     , Value = "local" },
            new { Text = MainWindow.resourcemanager.GetString("trCompany")   , Value = "com" },
             };
            cb_deliveryType.DisplayMemberPath = "Text";
            cb_deliveryType.SelectedValuePath = "Value";
            cb_deliveryType.ItemsSource = typelist;
            #endregion
        }

        private void translat()
        {
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
