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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_taxSetting.xaml
    /// </summary>
    public partial class wd_taxSetting : Window
    {
        public wd_taxSetting()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }
        BrushConverter bc = new BrushConverter();
        SetValues setValuesModel = new SetValues();
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        SetValues setVInvoice = new SetValues();    SetValues setVInvoiceBool = new SetValues();
        SetValues setVItem    = new SetValues();    SetValues setVItemBool    = new SetValues();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region translate

                if (winLogIn.lang.Equals("en"))
                {
                    winLogIn.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    winLogIn.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                #endregion

                List<SetValues> valuesLst =  await setValuesModel.GetBySetvalNote("tax");

                setVInvoice = valuesLst.Where(v => v.name == "invoiceTax_decimal").FirstOrDefault();
                setVInvoiceBool = valuesLst.Where(v => v.name == "invoiceTax_bool").FirstOrDefault();
                setVItem = valuesLst.Where(v => v.name == "itemsTax_decimal").FirstOrDefault();
                setVItemBool = valuesLst.Where(v => v.name == "itemsTax_bool").FirstOrDefault();

                //tgl_invoiceTax.IsChecked = (bool)setVInvoiceBool.value;
                tb_invoiceTax.Text = setVInvoice.value;
                //tgl_itemsTax.IsChecked = (bool)setVItemBool.value;
                tb_itemsTax.Text = setVItem.value;

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


        private void translate()
        {
            txt_title.Text = winLogIn.resourcemanager.GetString("trTax");
            btn_save.Content = winLogIn.resourcemanager.GetString("trSave");
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    Btn_save_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Tb_validateEmptyTextChange(object sender, TextChangedEventArgs e)
        {
            try
            {

                string name = sender.GetType().Name;
                validateEmpty(name, sender);
                var txb = sender as TextBox;
                if ((sender as TextBox).Name == "tb_taxes" || (sender as TextBox).Name == "tb_price")
                    SectionData.InputJustNumber(ref txb);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
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
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void validateEmpty(string name, object sender)
        {
            try
            {
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_invoiceTax")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorInvoiceTax, tt_errorInvoiceTax, "trIsRequired");
                    else if ((sender as TextBox).Name == "tb_itemsTax")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorItemsTax, tt_errorItemsTax, "trIsRequired");
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }


        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                //SectionData.ExceptionMessage(ex, this);
            }
        }
        static SetValues tax = new SetValues();
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (tgl_invoiceTax.IsChecked == true)
                    SectionData.validateEmptyTextBox(tb_invoiceTax, p_errorInvoiceTax, tt_errorInvoiceTax, "trEmptyTax");
                else
                    SectionData.clearValidate(tb_invoiceTax, p_errorInvoiceTax);
                if(tgl_itemsTax.IsChecked == true)
                    SectionData.validateEmptyTextBox(tb_itemsTax, p_errorItemsTax, tt_errorItemsTax, "trEmptyTax");
                else
                    SectionData.clearValidate(tb_itemsTax, p_errorItemsTax);

                if ((!tb_invoiceTax.Text.Equals("")) && (!tb_itemsTax.Text.Equals("")))
                {
                    SetValues valueModel = new SetValues();
                    int taxId = setVInvoiceBool.settingId.Value;

                    if (setVInvoiceBool == null)
                        setVInvoiceBool = new SetValues();
                    //save bool invoice tax
                    setVInvoiceBool.value = tgl_invoiceTax.IsChecked.ToString();
                    setVInvoiceBool.isSystem = 1;
                    setVInvoiceBool.settingId = taxId;
                    int invoiceBoolRes = await valueModel.Save(setVInvoiceBool);

                    if (setVInvoice == null)
                        setVInvoice = new SetValues();
                    //save invoice tax
                    string invTax = "0.0";
                    if (tgl_invoiceTax.IsChecked == true) invTax = tb_invoiceTax.Text;
                    else invTax = "0.0";
                    setVInvoice.value = invTax;
                    setVInvoice.isSystem = 1;
                    setVInvoice.settingId = taxId;
                    int invoiceRes = await valueModel.Save(setVInvoice);

                    if (setVItemBool == null)
                        setVItemBool = new SetValues();
                    //save bool item tax
                    setVItemBool.value = tgl_itemsTax.IsChecked.ToString();
                    setVItemBool.isSystem = 1;
                    setVItemBool.settingId = taxId;
                    int itemBoolRes = await valueModel.Save(setVItemBool);

                    if (setVItem == null)
                        setVItem = new SetValues();
                    //save item tax
                    string itemTax = "0.0";
                    if (tgl_itemsTax.IsChecked == true) itemTax = tb_itemsTax.Text;
                    else itemTax = "0.0";
                    setVItem.value = itemTax;
                    setVItem.isSystem = 1;
                    setVItem.settingId = taxId;
                    int itemRes = await valueModel.Save(setVItem);

                    if ((invoiceBoolRes > 0) && (invoiceRes > 0) && (itemBoolRes > 0) && (itemRes > 0) )
                    {
                        //update tax in main window
                        //MainWindow.tax = decimal.Parse(tax.value);

                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopSave"), animation: ToasterAnimation.FadeIn);
                    }
                    else
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
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

        private void Tb_PreventSpaces(object sender, KeyEventArgs e)
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
        private void Tb_decimal_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                //decimal
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
                if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                    e.Handled = false;

                else
                    e.Handled = true;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

    }
}
