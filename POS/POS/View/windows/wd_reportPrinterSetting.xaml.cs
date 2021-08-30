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

using System.Drawing.Printing;
namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_reportPrinterSetting.xaml
    /// </summary>
    public partial class wd_reportPrinterSetting : Window
    {

        public wd_reportPrinterSetting()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this); }
        }


        BrushConverter bc = new BrushConverter();

        // printer
        List<Papersize> papersizeList = new List<Papersize>();
        List<Printers> printersList = new List<Printers>();
        Printers repprinterRow = new Printers();
        Printers salprinterRow = new Printers();
        PosSetting possettingModel = new PosSetting();

        int saleInvPrinterId;
        int reportPrinterId;
        int salepapersizeId;
        int docpapersizeId;

        Printers printerModel = new Printers();
        Papersize papersizeModel = new Papersize();
      

        public List<Printers> getsystemPrinters()
        {
            Printers printermodel = new Printers();
         
            List<Printers> printerList = new List<Printers>();

            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                printermodel = new Printers();

                printermodel.name = (string)PrinterSettings.InstalledPrinters[i];

                printerList.Add(printermodel);

            }
            return printerList;
        }
        async Task GetposSetting()
        {
            papersizeList = await papersizeModel.GetAll();
            possettingModel = await possettingModel.GetByposId((int)MainWindow.posID);
            if (possettingModel is null || possettingModel.posSettingId <= 0)
            {


            }
            else
            {

                reportPrinterId = (int)possettingModel.reportPrinterId;
                saleInvPrinterId = (int)possettingModel.saleInvPrinterId;

                salepapersizeId = (int)possettingModel.saleInvPapersizeId;
                if (possettingModel.docPapersizeId != null && possettingModel.docPapersizeId > 0)
                {
                    docpapersizeId = (int)possettingModel.docPapersizeId;
                //   docpapersizerow = await papersizeModel.GetByID(docpapersizeId);
                }

                if (reportPrinterId > 0)
                    repprinterRow = await printerModel.GetByID(reportPrinterId);
                if (saleInvPrinterId > 0)
                    salprinterRow = await printerModel.GetByID(saleInvPrinterId);



            }


        }
        public void fillcb_repname()
        {
            cb_repname.ItemsSource = printersList;
            cb_repname.DisplayMemberPath = "name";
            cb_repname.SelectedValuePath = "name";

            if (repprinterRow.printerId > 0)
            {
                cb_repname.SelectedValue = Encoding.UTF8.GetString(Convert.FromBase64String(repprinterRow.name));

            }

        }

        public void fillcb_salname()
        {
            cb_salname.ItemsSource = printersList;
            cb_salname.DisplayMemberPath = "name";
            cb_salname.SelectedValuePath = "name";
            if (salprinterRow.printerId > 0)
            {
                cb_salname.SelectedValue = (string)Encoding.UTF8.GetString(Convert.FromBase64String(salprinterRow.name));

            }

        }
        //
        public void fillcb_docpapersize()
        {
            cb_docpapersize.ItemsSource = papersizeList.Where(x => x.printfor.Contains("doc"));
            cb_docpapersize.DisplayMemberPath = "paperSize1";
            cb_docpapersize.SelectedValuePath = "sizeId";
            if (docpapersizeId > 0)
            {

                cb_docpapersize.SelectedValue = docpapersizeId;

            }

        }
        public void fillcb_saleInvPaperSize()
        {

            cb_saleInvPaperSize.ItemsSource = papersizeList.Where(x => x.printfor.Contains("sal"));
            // var paperList = papersizeList.Where(x => x.printfor.Contains("sal"));
            cb_saleInvPaperSize.DisplayMemberPath = "paperSize1";
            cb_saleInvPaperSize.SelectedValuePath = "sizeId";
            if (salepapersizeId > 0)
            {
                cb_saleInvPaperSize.SelectedValue = salepapersizeId;
            }


        }

        async Task refreshWindow()
        {
            printersList = getsystemPrinters();
            await GetposSetting();
            fillcb_salname();
            fillcb_repname();
            fillcb_docpapersize();



            fillcb_saleInvPaperSize();

        }
        public async Task<string> Saveprinters()
        {
            PosSetting posscls = new PosSetting();
            string msg;
            repprinterRow.name = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes((string)cb_repname.SelectedValue));
            repprinterRow.printFor = "rep";
            repprinterRow.createUserId = MainWindow.userID;

            msg = await printerModel.Save(repprinterRow);
            reportPrinterId = int.Parse(msg);


            salprinterRow.name = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes((string)cb_salname.SelectedValue));
            salprinterRow.printFor = "sal";
            salprinterRow.createUserId = MainWindow.userID;

            msg = await printerModel.Save(salprinterRow);
            saleInvPrinterId = int.Parse(msg);

            possettingModel.posId = MainWindow.posID;
            possettingModel.reportPrinterId = reportPrinterId;
            possettingModel.saleInvPrinterId = saleInvPrinterId;

            possettingModel.saleInvPapersizeId = (int)cb_saleInvPaperSize.SelectedValue;
            possettingModel.docPapersizeId = (int)cb_docpapersize.SelectedValue;

            posscls.posSettingId = possettingModel.posSettingId;
            posscls.posId = possettingModel.posId;
            posscls.saleInvPrinterId = possettingModel.saleInvPrinterId;
            posscls.reportPrinterId = possettingModel.reportPrinterId;
            posscls.saleInvPapersizeId = possettingModel.saleInvPapersizeId;
            posscls.docPapersizeId = possettingModel.docPapersizeId;
            msg = await possettingModel.Save(posscls);
            return msg;
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


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

                //translate();
                #endregion

                //
                await refreshWindow();

                if (sender != null)
                    SectionData.EndAwait(grid_main);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }


        private void translate()
        {
            txt_title.Text = winLogIn.resourcemanager.GetString("trInstallationSettings");

        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Return)
                {
                    //Btn_save_Click(null, null);
                }
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        List<SettingCls> set = new List<SettingCls>();

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                e.Cancel = true;
                this.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this, sender);
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
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }



        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            string msg;
            msg= await Saveprinters();


         
         
            await refreshWindow();
            await MainWindow.getPrintersNames();
            if (int.Parse(msg) > 0)
            {
  MessageBox.Show("saved");
            }
            else
            {
                MessageBox.Show("Notsaved");
            }
 


        }
    }
}
