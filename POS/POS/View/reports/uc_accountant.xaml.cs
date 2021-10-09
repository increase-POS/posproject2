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
    public partial class uc_accountant : UserControl
    {
        public uc_accountant()
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
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_ucAccountant.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_ucAccountant.FlowDirection = FlowDirection.RightToLeft;
                }
                translate();
                #endregion

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void translate()
        {
            txt_paymentsInfo.Text = MainWindow.resourcemanager.GetString("trPayments");
            txt_paymentsHint.Text = MainWindow.resourcemanager.GetString("trVendorCustomerUserHint");
            txt_recipientInfo.Text = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            txt_recipientHint.Text = MainWindow.resourcemanager.GetString("trVendorCustomerUserHint");
            txt_bankInfo.Text = MainWindow.resourcemanager.GetString("trBank");
            txt_bankHint.Text = MainWindow.resourcemanager.GetString("trPaymentsRecipientHint");
            txt_posInfo.Text = MainWindow.resourcemanager.GetString("trPOS");
            txt_posHint.Text = MainWindow.resourcemanager.GetString("trFromToPosHint");
            txt_statementInfo.Text = MainWindow.resourcemanager.GetString("trAccountStatement");
            txt_statementHint.Text = MainWindow.resourcemanager.GetString("trVendorCustomerUserHint");
        }

        private void Btn_payments_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_paymentsReport uc = new uc_paymentsReport();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_recipient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_recipientReport uc = new uc_recipientReport();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_bank_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_banksReport uc = new uc_banksReport();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_pos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_posReports uc = new uc_posReports();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_statement_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_accountStatement uc = new uc_accountStatement();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_fund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_accountFund uc = new uc_accountFund();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }

        private void Btn_profit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                uc_accountProfits uc = new uc_accountProfits();
                sc_main.Visibility = Visibility.Collapsed;
                main.Children.Add(uc);
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
    }
}
