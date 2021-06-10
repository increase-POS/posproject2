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

namespace POS.View.accounts
{
    /// <summary>
    /// Interaction logic for uc_receivedAccounts.xaml
    /// </summary>
    public partial class uc_receivedAccounts : UserControl
    {
        private static uc_receivedAccounts _instance;
        public static uc_receivedAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_receivedAccounts();
                return _instance;
            }
        }
        public uc_receivedAccounts()
        {
            InitializeComponent();
        }
        private void Btn_confirm_Click(object sender, RoutedEventArgs e)
        {//confirm

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load

            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucReceivedAccounts.FlowDirection = FlowDirection.LeftToRight;

            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucReceivedAccounts.FlowDirection = FlowDirection.RightToLeft;

            }

            #region Style Date
            /////////////////////////////////////////////////////////////
            SectionData.defaultDatePickerStyle(dp_startSearchDate);
            SectionData.defaultDatePickerStyle(dp_endSearchDate);
            /////////////////////////////////////////////////////////////
            #endregion

            translate();
        }


        private void translate()
        {
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trTransaferDetails");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));

            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositFrom, MainWindow.resourcemanager.GetString("trDepositFromHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_depositor, MainWindow.resourcemanager.GetString("trDepositorHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_paymentProcessType, MainWindow.resourcemanager.GetString("trPaymentTypeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_docNum, MainWindow.resourcemanager.GetString("trDocNumHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_cash, MainWindow.resourcemanager.GetString("trCashHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_note, MainWindow.resourcemanager.GetString("trNoteHint"));

            dg_receivedAccounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_receivedAccounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositTo");
            dg_receivedAccounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trRecepient");
            dg_receivedAccounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            //dg_receivedAccounts.Columns[4].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

            //tt_depositTo.Content = MainWindow.resourcemanager.GetString("trDepositTo");
            //tt_recepient.Content = MainWindow.resourcemanager.GetString("trRecipientTooltip");
            //tt_paymentType.Content = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            //tt_docNum.Content = MainWindow.resourcemanager.GetString("trDocNumTooltip");
            //tt_card.Content = MainWindow.resourcemanager.GetString("trCardTooltip");
            //tt_cash.Content = MainWindow.resourcemanager.GetString("trCashTooltip");
            //tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            //tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_refresh.Content = MainWindow.resourcemanager.GetString("trRefresh");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_print.Content = MainWindow.resourcemanager.GetString("trPrint");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_pieChart.Content = MainWindow.resourcemanager.GetString("trPieChart");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
            tt_startDate.Content = MainWindow.resourcemanager.GetString("trStartDate");
            tt_endDate.Content = MainWindow.resourcemanager.GetString("trEndDate");

            btn_add.Content = MainWindow.resourcemanager.GetString("trSave");
            //btn_update.Content = MainWindow.resourcemanager.GetString("trUpdate");
            //btn_delete.Content = MainWindow.resourcemanager.GetString("trDelete");
            btn_image.Content = MainWindow.resourcemanager.GetString("trImage");
            btn_preview.Content = MainWindow.resourcemanager.GetString("trPreview");
            btn_printInvoice.Content = MainWindow.resourcemanager.GetString("trPrint");
            btn_pdf.Content = MainWindow.resourcemanager.GetString("trPdf");

        }

        private void Dg_receivedAccounts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection

        }

        private void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search

        }

        private void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add

        }

        private void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update

        }

        private void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//export

        }

        private void Btn_image_Click(object sender, RoutedEventArgs e)
        {//image

        }

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh

        }
    }
}
