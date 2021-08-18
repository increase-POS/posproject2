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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_cashTransfer.xaml
    /// </summary>
    public partial class wd_cashTransfer : Window
    {
        public wd_cashTransfer()
        {
            try
            {
                InitializeComponent();
            }
            catch(Exception ex)
            {
                SectionData.ExceptionMessage(ex,this);
            }
        }

        public int invId;
        CashTransfer cashModel = new CashTransfer();
        IEnumerable<CashTransfer> cashes;
        IEnumerable<CashTransfer> cashesQuery; 
        string searchText = "";
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                SectionData.StartAwait(grid_ucCashTransfer);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_ucCashTransfer.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_ucCashTransfer.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                #endregion

                Txb_search_TextChanged(null, null);

                SectionData.EndAwait(grid_ucCashTransfer, this);
            }
            catch(Exception ex)
            {
                SectionData.EndAwait(grid_ucCashTransfer , this);
            }
        }

        private void translate()
        {
            txt_accounts.Text = MainWindow.resourcemanager.GetString("trPayments/Received");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            dg_accounts.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_accounts.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositor/Recipient");
            dg_accounts.Columns[2].Header = MainWindow.resourcemanager.GetString("trPaymentTypeTooltip");
            dg_accounts.Columns[3].Header = MainWindow.resourcemanager.GetString("trCashTooltip");
            btn_select.Content = MainWindow.resourcemanager.GetString("trSelect");
            btn_colse.ToolTip = MainWindow.resourcemanager.GetString("trClose");
        }

        async Task<IEnumerable<CashTransfer>> RefreshCashesList()
        {
            cashes = await cashModel.GetListByInvId(invId);
            //cashes = cashes.Where(x => x.processType != "balance");
            return cashes;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        private async void Txb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                SectionData.StartAwait(grid_ucCashTransfer);
                if (cashes is null)
                    await RefreshCashesList();
                this.Dispatcher.Invoke(() =>
                {
                    searchText = txb_search.Text.ToLower();
                    cashesQuery = cashes.Where(s => (s.transNum.ToLower().Contains(searchText)
                    || s.cash.ToString().ToLower().Contains(searchText)
                    )
                    && (s.side == "v" || s.side == "c" || s.side == "u" || s.side == "s" || s.side == "e" || s.side == "m" || s.side == "sh")
                    && s.transType == "all"
                    );

                });

                RefreshCashView();
                SectionData.EndAwait(grid_ucCashTransfer, this);
            }
            catch(Exception ex)
            {
                SectionData.EndAwait(grid_ucCashTransfer , this);
                SectionData.ExceptionMessage(ex,this,sender);
            }
        }

        void RefreshCashView()
        {
            dg_accounts.ItemsSource = cashesQuery;
            //cashes = cashes.Where(x => x.processType != "balance");
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_select_Click(null, null);
            }
        }

        private void Btn_select_Click(object sender, RoutedEventArgs e)
        {//select

        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {//close
            this.Close();
        }
    }
}
