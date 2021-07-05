using POS.Classes;
using netoaster;
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
using System.IO;
using Microsoft.Reporting.WinForms;
using Microsoft.Win32;
using POS.View.windows;
using POS.View.sectionData.Charts;

namespace POS.View.sectionData
{
    /// <summary>
    /// Interaction logic for uc_card.xaml
    /// </summary>
    public partial class uc_card : UserControl
    {
        Card cardModel = new Card();
        Card card = new Card();
        IEnumerable<Card> cardsQuery;
        IEnumerable<Card> cards;
        byte tgl_cardState;
        string searchText = "";
        //phone variabels

        CountryCode countrycodes = new CountryCode();
        City cityCodes = new City();
        BrushConverter bc = new BrushConverter();
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();

        private static uc_card _instance;
        public static uc_card Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new uc_card();
                return _instance;
            }
        }
        public uc_card()
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

       
        private void translate()
        {
            //txt_card.Text = MainWindow.resourcemanager.GetString("trCard");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_search, MainWindow.resourcemanager.GetString("trSelectCardNameHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trCardNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            //dg_card.Columns[0].Header = MainWindow.resourcemanager.GetString("trCardName");
            //dg_card.Columns[1].Header = MainWindow.resourcemanager.GetString("trAccNumber");
            //dg_card.Columns[2].Header = MainWindow.resourcemanager.GetString("trAddress");
            //dg_card.Columns[3].Header = MainWindow.resourcemanager.GetString("trMobile");

            btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

            tt_name.Content = MainWindow.resourcemanager.GetString("trName");
            tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
            tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
            tt_add_Button.Content = MainWindow.resourcemanager.GetString("trAdd");
            tt_update_Button.Content = MainWindow.resourcemanager.GetString("trUpdate");
            tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

            tt_clear.Content = MainWindow.resourcemanager.GetString("trClear");
            tt_report.Content = MainWindow.resourcemanager.GetString("trPdf");
            tt_excel.Content = MainWindow.resourcemanager.GetString("trExcel");
            tt_count.Content = MainWindow.resourcemanager.GetString("trCount");
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (MainWindow.lang.Equals("en"))
            {
                MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                grid_ucCard.FlowDirection = FlowDirection.LeftToRight;
            }
            else
            {
                MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                grid_ucCard.FlowDirection = FlowDirection.RightToLeft;
            }

            translate();

            Keyboard.Focus(tb_name);

            this.Dispatcher.Invoke(() =>
            {
                Tb_search_TextChanged(null, null);
            });
            MainWindow mw = new MainWindow();
        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
        }
       
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            tb_name.Clear();
            tb_notes.Clear();

            p_errorName.Visibility = Visibility.Collapsed;

            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            card.cardId = 0;
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
           
            //string phoneStr = "";

            if ((!tb_name.Text.Equals("")))
            {
                bool isCardExist = await chkDuplicateCard();
                if (isCardExist)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopCardExist"), animation: ToasterAnimation.FadeIn);
                    p_errorName.Visibility = Visibility.Visible;
                    tt_errorName.Content = MainWindow.resourcemanager.GetString("trPopCardExist");
                    tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {
                    card.name = tb_name.Text;
                    card.notes = tb_notes.Text;
                    card.createUserId = MainWindow.userID;
                    card.updateUserId = MainWindow.userID;
                    card.isActive = 1;

                    string s = await cardModel.Save(card);
                    
                    if (s.Equals("true")) //{SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopAdd")); Btn_clear_Click(null, null); }
                    {
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                        Btn_clear_Click(null, null);
                    }
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshCardsList();
                    Tb_search_TextChanged(null, null);
                }
            }

        }

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            //chk empty name
            SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            
            if ((!tb_name.Text.Equals("")))
            {
                bool isCardExist = await chkDuplicateCard();
                if (isCardExist)
                {
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopCardExist"), animation: ToasterAnimation.FadeIn);
                    p_errorName.Visibility = Visibility.Visible;
                    tt_errorName.Content = MainWindow.resourcemanager.GetString("trPopCardExist");
                    tb_name.Background = (Brush)bc.ConvertFrom("#15FF0000");
                }
                else
                {

                    card.name = tb_name.Text;
                    card.notes = tb_notes.Text;
                    card.createUserId = MainWindow.userID;
                    card.updateUserId = MainWindow.userID;
                    card.isActive = 1;

                    string s = await cardModel.Save(card);

                    if (s.Equals("true")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopUpdate"));
                        Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                    else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    await RefreshCardsList();
                    Tb_search_TextChanged(null, null);
                }
            }

        }

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            if (card.cardId != 0)
            {
                if ((!card.canDelete) && (card.isActive == 0))
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
                    if (card.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                    if (!card.canDelete)
                        w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                    w.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                    if (w.isOk)
                    {
                        string popupContent = "";
                        if (card.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                        if ((!card.canDelete) && (card.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                        bool b = await cardModel.deleteCard(card.cardId, MainWindow.userID.Value, card.canDelete);

                        if (b) //SectionData.popUpResponse("", popupContent);
                            Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                        else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                            Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                    }
                }
                await RefreshCardsList();
                Tb_search_TextChanged(null, null);
            }
            //clear textBoxs
            Btn_clear_Click(sender, e);
        }

        private async void activate()
        {//activate
            card.isActive = 1;

            string s = await cardModel.Save(card);

            if (s.Equals("true")) //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopActive"));
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else //SectionData.popUpResponse("", MainWindow.resourcemanager.GetString("trPopError"));
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshCardsList();
            Tb_search_TextChanged(null, null);

        }
        private void Dg_card_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            p_errorName.Visibility = Visibility.Collapsed;


            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (dg_card.SelectedIndex != -1)
            {
                card = dg_card.SelectedItem as Card;
                this.DataContext = card;

            }

            if (card != null)
            {

                #region delete
                if (card.canDelete)
                {
                    txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                    txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Delete;
                    tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");

                }
                else
                {
                    if (card.isActive == 0)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trActive");
                        txt_delete_Icon.Kind =
                         MaterialDesignThemes.Wpf.PackIconKind.Check;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trActive");

                    }
                    else
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trInActive");
                        txt_delete_Icon.Kind =
                             MaterialDesignThemes.Wpf.PackIconKind.Cancel;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trInActive");

                    }

                }
                #endregion 
            }

        }

      

        private void tb_phone_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

       

        private void Tb_mobile_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_accNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        void FN_ExportToExcel()
        {
            var QueryExcel = cardsQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                Notes = x.notes
            });
            var DTForExcel = QueryExcel.ToDataTable();
            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });

        }

        private async void Tgl_cardIsActive_Checked(object sender, RoutedEventArgs e)
        {
            if (cards is null)
                await RefreshCardsList();
            tgl_cardState = 1;
            Tb_search_TextChanged(null, null);
        }

        private async void Tgl_cardIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cards is null)
                await RefreshCardsList();
            tgl_cardState = 0;
            Tb_search_TextChanged(null, null);
        }

        async Task<IEnumerable<Card>> RefreshCardsList()
        {
            MainWindow.mainWindow.StartAwait();
            cards = await cardModel.GetAll();
            MainWindow.mainWindow.EndAwait();
            return cards;
        }
        void RefreshCardView()
        {
            dg_card.ItemsSource = cardsQuery;
            txt_count.Text = cardsQuery.Count().ToString();
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            p_errorName.Visibility = Visibility.Collapsed;
            tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

            if (cards is null)
                await RefreshCardsList();
            searchText = tb_search.Text.ToLower();
            cardsQuery = cards.Where(s =>(
            s.name.ToLower().Contains(searchText)
            
             && s.isActive == tgl_cardState));
            RefreshCardView();

        }
         

        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshCardsList();
            Tb_search_TextChanged(null, null);
        }

        private async Task<bool> chkDuplicateCard()
        {
            bool b = false;

            List<Card> cards = await cardModel.GetAll();
            Card card1 = new Card();
            for (int i = 0; i < cards.Count(); i++)
            {
                card1 = cards[i];
                if ((card1.name.Equals(tb_name.Text.Trim())))
                { b = true; break; }
            }

            return b;
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                Thread t1 = new Thread(FN_ExportToExcel);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            });
        }

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
/*
            string addpath = @"\Reports\CardReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            rep.ReportPath = reppath;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetCard", cardsQuery));

            ReportParameter[] paramarr = new ReportParameter[4];
            paramarr[0] = new ReportParameter("Title", MainWindow.resourcemanager.GetString("trCards"));
            paramarr[1] = new ReportParameter("trName", MainWindow.resourcemanager.GetString("trName"));
            paramarr[2] = new ReportParameter("trNote", MainWindow.resourcemanager.GetString("trNote"));
            paramarr[3] = new ReportParameter("lang", MainWindow.lang);
            rep.SetParameters(paramarr);

            rep.Refresh();

            saveFileDialog.Filter = "PDF|*.pdf;";

            if (saveFileDialog.ShowDialog() == true)
            {

                string filepath = saveFileDialog.FileName;
                LocalReportExtensions.ExportToPDF(rep, filepath);

            }
            */
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            /*
            string addpath = @"\Reports\CardReport.rdlc";
            string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

            rep.ReportPath = reppath;
            rep.DataSources.Clear();
            rep.DataSources.Add(new ReportDataSource("DataSetCard", cardsQuery));
            ReportParameter[] paramarr = new ReportParameter[4];
            paramarr[0] = new ReportParameter("Title", MainWindow.resourcemanager.GetString("trCards"));
            paramarr[1] = new ReportParameter("trName", MainWindow.resourcemanager.GetString("trName"));
            paramarr[2] = new ReportParameter("trNote", MainWindow.resourcemanager.GetString("trNote"));
            paramarr[3] = new ReportParameter("lang", MainWindow.lang);
            rep.SetParameters(paramarr);
            rep.Refresh();
            LocalReportExtensions.PrintToPrinter(rep);
            */
        }

        private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Opacity = 0.2;
            win_lvc win = new win_lvc(cardsQuery, 6);
            win.ShowDialog();
            Window.GetWindow(this).Opacity = 1;
        }
    }
}
