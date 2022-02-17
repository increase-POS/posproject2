using netoaster;
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
    /// Interaction logic for wd_transfers.xaml
    /// </summary>
    public partial class wd_transfers : Window
    {
         public wd_transfers()
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
        CashTransfer cashModel = new CashTransfer();
        IEnumerable<CashTransfer> cashesQuery;
        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                //if (e.Key == Key.Return)
                //{
                //    Btn_select_Click(null, null);
                //}
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }
                translat();
                #endregion

                await fillDataGrid();

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
        private void translat()
        {
            txt_title.Text = MainWindow.resourcemanager.GetString("trCashtransfers");
            dg_transfers.Columns[0].Header = MainWindow.resourcemanager.GetString("trTransferNumberTooltip");
            dg_transfers.Columns[1].Header = MainWindow.resourcemanager.GetString("trDepositor");
            dg_transfers.Columns[2].Header = MainWindow.resourcemanager.GetString("trRecepient");
            dg_transfers.Columns[4].Header = MainWindow.resourcemanager.GetString("trCashTooltip");

        }

        async Task fillDataGrid()
        {
            cashesQuery = await cashModel.GetCashTransferForPosAsync("all", "p");
            cashesQuery = cashesQuery.Where(c => c.posId == MainWindow.posID && (c.isConfirm == 0 || c.isConfirm2 == 0));

            foreach (var c in cashesQuery)
            {
                if (c.transType.Equals("p"))
                {
                    string s = c.posName;
                    c.posName = c.pos2Name;
                    c.pos2Name = s;
                }
            }

            dg_transfers.ItemsSource = cashesQuery;
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        #region Button In DataGrid

        CashTransfer cashtrans2 = new CashTransfer();
        CashTransfer cashtrans3 = new CashTransfer();
        IEnumerable<CashTransfer> cashes2;

        async void confirmRowinDatagrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                        CashTransfer row = (CashTransfer) dg_transfers.SelectedItems[0];

                        #region get two pos
                        cashes2 = await cashModel.GetbySourcId("p", row.cashTransId);
                        //to insure that the pull operation is in cashtrans2 
                        if (row.transType == "p")
                        {
                            cashtrans2 = cashes2.ToList()[0] as CashTransfer;
                            cashtrans3 = cashes2.ToList()[1] as CashTransfer;
                        }
                        else if (row.transType == "d")
                        {
                            cashtrans2 = cashes2.ToList()[1] as CashTransfer;
                            cashtrans3 = cashes2.ToList()[0] as CashTransfer;
                        }

                        #endregion

                        #region confirm
                        //if another operation not confirmed then just confirm this
                        ////if another operation is confirmed then chk balance before confirm
                        bool confirm = false;
                        if (cashtrans2.cashTransId == row.cashTransId)//chk which record is selected
                        { if (cashtrans3.isConfirm == 0) confirm = false; else confirm = true; }
                        else//chk which record is selected
                        { if (cashtrans2.isConfirm == 0) confirm = false; else confirm = true; }

                        if (!confirm) await confirmOpr(row);
                        else
                        {
                            Pos posModel = new Pos();
                            Pos pos = await posModel.getById(cashtrans2.posId.Value);
                            //there is enough balance
                            if (pos.balance >= cashtrans2.cash)
                            {
                                cashtrans2.isConfirm = 1;
                                int s = await cashModel.Save(cashtrans2);
                                s = await cashModel.MovePosCash(cashtrans2.cashTransId, MainWindow.userID.Value);
                                //   if (s.Equals("transdone"))//tras done so confirm
                                if (s.Equals(1))//tras done so confirm
                                    await confirmOpr(row);
                                else//error then do not confirm
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            }
                            //there is not enough balance
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopNotEnoughBalance"), animation: ToasterAnimation.FadeIn);
                        }
                        await MainWindow.refreshBalance();
                    #endregion
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

        private async Task confirmOpr(CashTransfer cashtrans)
        {
            cashtrans.isConfirm = 1;
            int s = await cashModel.Save(cashtrans);
            if (!s.Equals(0))
            {
                await fillDataGrid();
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopConfirm"), animation: ToasterAnimation.FadeIn);
            }
        }
        
        async void cancelRowinDatagrid(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                    if (vis is DataGridRow)
                    {
                        CashTransfer row = (CashTransfer)dg_transfers.SelectedItems[0];

                        #region get two pos
                        cashes2 = await cashModel.GetbySourcId("p", row.cashTransId);
                        //to insure that the pull operation is in cashtrans2 
                        if (row.transType == "p")
                        {
                            cashtrans2 = cashes2.ToList()[0] as CashTransfer;
                            cashtrans3 = cashes2.ToList()[1] as CashTransfer;
                        }
                        else if (row.transType == "d")
                        {
                            cashtrans2 = cashes2.ToList()[1] as CashTransfer;
                            cashtrans3 = cashes2.ToList()[0] as CashTransfer;
                        }

                        #endregion

                        #region cancel
                        cashtrans2.isConfirm = 2;
                        cashtrans3.isConfirm = 2;

                        int s2 = await cashModel.Save(cashtrans2);
                        int s3 = await cashModel.Save(cashtrans3);

                        if ((!s2.Equals(0)) && (!s3.Equals(0)))
                        {
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopCanceled"), animation: ToasterAnimation.FadeIn);
                            await fillDataGrid();
                        }
                        else
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                        #endregion
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
        #endregion
    }
}
