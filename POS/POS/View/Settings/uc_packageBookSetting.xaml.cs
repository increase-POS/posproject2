using netoaster;
using POS.Classes;
using POS.View.windows;
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

namespace POS.View.Settings
{
    /// <summary>
    /// Interaction logic for uc_packageBookSetting.xaml
    /// </summary>
    public partial class uc_packageBookSetting : UserControl
    {
        public uc_packageBookSetting()
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

        private static uc_packageBookSetting _instance;
        public static uc_packageBookSetting Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_packageBookSetting();
                return _instance;
            }
        }
        ProgramDetails progDetailsModel = new ProgramDetails();
        ProgramDetails progDetails = new ProgramDetails();
        public async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {//load
            try
            {
                SectionData.StartAwait(grid_main);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_branch.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_store.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_user.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_vendor.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_item.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_salesInv.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_customer.FlowDirection = FlowDirection.LeftToRight;
                    //dpnl_pos.FlowDirection = FlowDirection.LeftToRight; 
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_branch.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_store.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_user.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_vendor.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_item.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_salesInv.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_customer.FlowDirection = FlowDirection.RightToLeft;
                    //dpnl_pos.FlowDirection = FlowDirection.RightToLeft;
                }
                translate();
                #endregion

                progDetails = await progDetailsModel.getCurrentInfo();

                #region unlimited
                if(progDetails.branchCount == -1)
                { dpnl_branch.Visibility = Visibility.Collapsed; txt_branchUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_branch.Visibility = Visibility.Visible; txt_branchUnlimited.Visibility = Visibility.Collapsed; }

                if (progDetails.storeCount == -1)
                { dpnl_store.Visibility = Visibility.Collapsed; txt_storeUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_store.Visibility = Visibility.Visible; txt_storeUnlimited.Visibility = Visibility.Collapsed; }

                if (progDetails.vendorCount == -1)
                { dpnl_vendor.Visibility = Visibility.Collapsed; txt_vendorUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_vendor.Visibility = Visibility.Visible; txt_vendorUnlimited.Visibility = Visibility.Collapsed; }

                if (progDetails.userCount == -1)
                { dpnl_user.Visibility = Visibility.Collapsed; txt_userUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_user.Visibility = Visibility.Visible; txt_userUnlimited.Visibility = Visibility.Collapsed; }

                if (progDetails.customerCount == -1)
                { dpnl_customer.Visibility = Visibility.Collapsed; txt_customerUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_customer.Visibility = Visibility.Visible; txt_customerUnlimited.Visibility = Visibility.Collapsed; }

                if (progDetails.posCount == -1)
                { dpnl_pos.Visibility = Visibility.Collapsed; txt_posUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_pos.Visibility = Visibility.Visible; txt_posUnlimited.Visibility = Visibility.Collapsed; }

                if (progDetails.saleinvCount == -1)
                { dpnl_salesInv.Visibility = Visibility.Collapsed; txt_salesInvUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_salesInv.Visibility = Visibility.Visible; txt_salesInvUnlimited.Visibility = Visibility.Collapsed; }

                if (progDetails.itemCount == -1)
                { dpnl_item.Visibility = Visibility.Collapsed; txt_itemUnlimited.Visibility = Visibility.Visible; }
                else
                { dpnl_item.Visibility = Visibility.Visible; txt_itemUnlimited.Visibility = Visibility.Collapsed; }
                #endregion

                this.DataContext = progDetails;

                SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {

                SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void translate()
        {

            txt_packageDetails.Text = MainWindow.resourcemanager.GetString("trPackageDetails");
            txt_packageCodeTitle.Text = MainWindow.resourcemanager.GetString("trCode");
            txt_packageNameTitle.Text = MainWindow.resourcemanager.GetString("trName");
            txt_agentTitle.Text = MainWindow.resourcemanager.GetString("trAgent");
            txt_customerNameTitle.Text = MainWindow.resourcemanager.GetString("trCustomer");
            txt_expiredTitle.Text = MainWindow.resourcemanager.GetString("trExpiredDate");
            txt_statusTitle.Text = MainWindow.resourcemanager.GetString("trStatus");

            txt_programDetails.Text = MainWindow.resourcemanager.GetString("trProgramDetails");
            txt_programTitle.Text = MainWindow.resourcemanager.GetString("trProgram");
            txt_versionTitle.Text = MainWindow.resourcemanager.GetString("trVersion");

            txt_activationDetails.Text = MainWindow.resourcemanager.GetString("trActivationDetails");
            txt_serialsTitle.Text = MainWindow.resourcemanager.GetString("trSerials");
            txt_activationCodeTitle.Text = MainWindow.resourcemanager.GetString("trActivationCode");

            txt_packageLimits.Text = MainWindow.resourcemanager.GetString("trPackageLimits");
            txt_branchCountTitle.Text = MainWindow.resourcemanager.GetString("trBranches");
            txt_userCountTitle.Text = MainWindow.resourcemanager.GetString("trUsers");
            txt_customerCountTitle.Text = MainWindow.resourcemanager.GetString("trCustomers");
            txt_salesInvCountTitle.Text = MainWindow.resourcemanager.GetString("trInvoices");
            txt_storeCountNameTitle.Text = MainWindow.resourcemanager.GetString("trStores");
            txt_posCountNameTitle.Text = MainWindow.resourcemanager.GetString("trPOSs");
            txt_vendorCountNameTitle.Text = MainWindow.resourcemanager.GetString("trVendors");
            txt_itemCountNameTitle.Text = MainWindow.resourcemanager.GetString("trItems");

            btn_extend.Content = MainWindow.resourcemanager.GetString("trExtend");
            btn_upgrade.Content = MainWindow.resourcemanager.GetString("trUpgrade");
        }

        #region events

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
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
        #endregion

        #region validate - clearValidate - textChange - lostFocus - . . . . 
        void Clear()
        {
          
        }

       
        #endregion

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            GC.Collect();
        }

        private async void Btn_extend_Click(object sender, RoutedEventArgs e)
        {//extend
            int chk = 0;
            string activationkey = progDetails.packageSaleCode;//get from info 
            try
            {
                if (activationkey.Trim() != "".Trim())
                {
                    AvtivateServer ac = new AvtivateServer();

                    chk = await ac.checkconn();

                    chk = await ac.StatSendserverkey(activationkey,"rn");
                    // //change      chk = 3;
                    //nochange     chk = 2;

                    if (chk <= 0)
                    {
                        string message = "inc(" + chk + ")";

                        string messagecode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message));

                        //string msg = "The Activation not complete (Error code:" + messagecode + ")";
                        
                        string msg = MainWindow.resourcemanager.GetString("trActivationNotCompleted")+ "(" +
                                     MainWindow.resourcemanager.GetString("trErrorCode") + ":" + messagecode + ")";

                        Toaster.ShowWarning(Window.GetWindow(this), message: msg, animation: ToasterAnimation.FadeIn);
                    }

                    else
                    {
                        if(chk == 3)
                            //Toaster.ShowSuccess(Window.GetWindow(this), message: "The Activation done successfuly", animation: ToasterAnimation.FadeIn);
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trActivationCompleted"), animation: ToasterAnimation.FadeIn);

                        else if (chk == 2)
                            //Toaster.ShowSuccess(Window.GetWindow(this), message: "No changes", animation: ToasterAnimation.FadeIn);
                            Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trNoChanges"), animation: ToasterAnimation.FadeIn);

                    }
                }
            }
            catch (Exception ex)
            {

                Toaster.ShowWarning(Window.GetWindow(this), message: "The server Not Found", animation: ToasterAnimation.FadeIn);
            }
        }

        private async void Btn_upgrade_Click(object sender, RoutedEventArgs e)
        {//upgrade
            int chk = 0;
            string activationkey = progDetails.packageSaleCode;//get from info 
            try
            {
                if (activationkey.Trim() != "".Trim())
                {
                    AvtivateServer ac = new AvtivateServer();

                    chk = await ac.checkconn();

                    chk = await ac.StatSendserverkey(activationkey, "up");
                    // //change      chk = 3;
                    //nochange     chk = 2;

                    if (chk <= 0)
                    {
                        string message = "inc(" + chk + ")";

                        string messagecode = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message));

                        string msg = "The Activation not complete (Error code:" + messagecode + ")";

                        Toaster.ShowWarning(Window.GetWindow(this), message: msg, animation: ToasterAnimation.FadeIn);
                    }

                    else
                    {
                        if(chk == 3)
                            Toaster.ShowSuccess(Window.GetWindow(this), message: "The Upgrade done successfuly", animation: ToasterAnimation.FadeIn);
                        else if(chk == 2)
                            Toaster.ShowSuccess(Window.GetWindow(this), message: "No changes", animation: ToasterAnimation.FadeIn);

                    }
                }
            }
            catch (Exception ex)
            {

                Toaster.ShowWarning(Window.GetWindow(this), message: "The server Not Found", animation: ToasterAnimation.FadeIn);
            }
        }

        private async void Btn_serials_Click(object sender, RoutedEventArgs e)
        {//serials
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                    Window.GetWindow(this).Opacity = 0.2;
                    wd_serials w = new wd_serials();
                    w.activationCode = progDetails.packageSaleCode;
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;

                    progDetails = await progDetailsModel.getCurrentInfo();

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
