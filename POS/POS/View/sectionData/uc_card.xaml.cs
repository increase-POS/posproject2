﻿using POS.Classes;
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
using System.Windows.Resources;

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

        string basicsPermission = "cards_basics";
        private static uc_card _instance;

        bool isImgPressed = false;
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string imgFileName = "pic/no-image-icon-125x125.png";
        ImageBrush brush = new ImageBrush();

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
            try
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
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex,this); }
        }


        private void translate()
        {
          
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
                txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trCardNameHint"));
                MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_notes, MainWindow.resourcemanager.GetString("trNoteHint"));
                txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
                txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
                txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");

                btn_clear.ToolTip = MainWindow.resourcemanager.GetString("trClear");

                //tt_name.Content = MainWindow.resourcemanager.GetString("trName");
                //tt_notes.Content = MainWindow.resourcemanager.GetString("trNote");
                //tt_search.Content = MainWindow.resourcemanager.GetString("trSearch");
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
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                MainWindow.mainWindow.initializationMainTrack(this.Tag.ToString(), 1);

                #region translate
                if (MainWindow.lang.Equals("en"))
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.LeftToRight;
                }
                else
                {
                    MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly());
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                }

                translate();
                #endregion

                Keyboard.Focus(tb_name);

                this.Dispatcher.Invoke(() =>
                {
                    Tb_search_TextChanged(null, null);
                });
                MainWindow mw = new MainWindow();
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

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            }
            catch (Exception ex) { SectionData.ExceptionMessage(ex, this); }
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            }
            catch (Exception ex) { SectionData.ExceptionMessage(ex, this); }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }


        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                tb_name.Clear();
                tb_notes.Clear();
                //clear img
                Uri resourceUri = new Uri("pic/no-image-icon-125x125.png", UriKind.Relative);
                StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
                BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
                brush.ImageSource = temp;
                img_card.Background = brush;
                p_errorName.Visibility = Visibility.Collapsed;

                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
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

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    card.cardId = 0;
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

                            //if (s.Equals("true"))
                            if (!s.Equals(""))
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);

                                if (isImgPressed)
                                {
                                    int cardId = int.Parse(s);
                                    string b = await cardModel.uploadImage(imgFileName,
                                        Md5Encription.MD5Hash("Inc-m" + cardId.ToString()), cardId);
                                    card.image = b;
                                    isImgPressed = false;
                                }

                                Btn_clear_Click(null, null);
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            await RefreshCardsList();
                            Tb_search_TextChanged(null, null);
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private async void Btn_update_Click(object sender, RoutedEventArgs e)
        {//update
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "update") || SectionData.isAdminPermision())
                {
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

                            //if (s.Equals("true"))
                            if (!s.Equals(""))
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                                if (isImgPressed)
                                {
                                    int cardId = int.Parse(s);
                                    string b = await cardModel.uploadImage(imgFileName, Md5Encription.MD5Hash("Inc-m" + cardId.ToString()), cardId);
                                    card.image = b;
                                    isImgPressed = false;
                                    if (!b.Equals(""))
                                    {
                                        getImg();
                                    }
                                    else
                                    {
                                        SectionData.clearImg(img_card);
                                    }
                                }
                            }
                            else 
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            await RefreshCardsList();
                            Tb_search_TextChanged(null, null);
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private async void Btn_delete_Click(object sender, RoutedEventArgs e)
        {//delete
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "delete") || SectionData.isAdminPermision())
                {
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
                                await activate();
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

                                if (b)
                                    Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                                else
                                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            }
                        }
                        await RefreshCardsList();
                        Tb_search_TextChanged(null, null);
                    }
                    //clear textBoxs
                    Btn_clear_Click(null,null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private async Task activate()
        {//activate
           
                card.isActive = 1;

                string s = await cardModel.Save(card);

                if (s.Equals("true")) 
                    Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
                else 
                    Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                await RefreshCardsList();
                Tb_search_TextChanged(null, null);

        }
        private void Dg_card_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {//selection
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                p_errorName.Visibility = Visibility.Collapsed;
                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                if (dg_card.SelectedIndex != -1)
                {
                    card = dg_card.SelectedItem as Card;
                    this.DataContext = card;
                }

                if (card != null)
                {
                    getImg();

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

     

        private async void Tgl_cardIsActive_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (cards is null)
                    await RefreshCardsList();
                tgl_cardState = 1;
                Tb_search_TextChanged(null, null);
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

        private async void Tgl_cardIsActive_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (cards is null)
                    await RefreshCardsList();
                tgl_cardState = 0;
                Tb_search_TextChanged(null, null);
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

        async Task<IEnumerable<Card>> RefreshCardsList()
        {
            cards = await cardModel.GetAll();           
            return cards;
        }
        void RefreshCardView()
        {
           
                dg_card.ItemsSource = cardsQuery;
                txt_count.Text = cardsQuery.Count().ToString();
           
        }

        private async void Tb_search_TextChanged(object sender, TextChangedEventArgs e)
        {//search
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    p_errorName.Visibility = Visibility.Collapsed;
                    tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                    if (cards is null)
                        await RefreshCardsList();
                    searchText = tb_search.Text.ToLower();
                    cardsQuery = cards.Where(s => (
                    s.name.ToLower().Contains(searchText)

                     && s.isActive == tgl_cardState));
                    RefreshCardView();
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


        private async void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {

                    await RefreshCardsList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private async Task<bool> chkDuplicateCard()
        {
            bool b = false;
          
                List<Card> cards = await cardModel.GetAll();
            if(cards.Any(c => c.name == tb_name.Text && c.cardId != card.cardId))
             b = true; 
            //Card card1 = new Card();
            //for (int i = 0; i < cards.Count(); i++)
            //{
            //    card1 = cards[i];
            //    if ((card1.name.Equals(tb_name.Text.Trim())))
            //    { b = true; break; }
            //}
            return b;
        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {//excel
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    //this.Dispatcher.Invoke(() =>
                    //{
                    //    Thread t1 = new Thread(FN_ExportToExcel);
                    //    t1.SetApartmentState(ApartmentState.STA);
                    //    t1.Start();
                    //});
                    #region
                    Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\SectionData\Ar\ArCardReport.rdlc";
                        }
                        else addpath = @"\Reports\SectionData\En\CardReport.rdlc";
                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        ReportCls.checkLang();

                        clsReports.cardReport(cardsQuery, rep, reppath);
                        clsReports.setReportLanguage(paramarr);
                        clsReports.Header(paramarr);

                        rep.SetParameters(paramarr);

                        rep.Refresh();
                        this.Dispatcher.Invoke(() =>
                        {
                            saveFileDialog.Filter = "EXCEL|*.xls;";
                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string filepath = saveFileDialog.FileName;
                                LocalReportExtensions.ExportToExcel(rep, filepath);
                            }
                        });


                    });
                    t1.Start();
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {//pdf
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArCardReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\EN\CardReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.cardReport(cardsQuery, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);

                    rep.Refresh();

                    saveFileDialog.Filter = "PDF|*.pdf;";

                    if (saveFileDialog.ShowDialog() == true)
                    {
                        string filepath = saveFileDialog.FileName;
                        LocalReportExtensions.ExportToPDF(rep, filepath);
                    }
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {//print
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArCardReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\EN\CardReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();
                    clsReports.cardReport(cardsQuery, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    LocalReportExtensions.PrintToPrinterbyNameAndCopy(rep, MainWindow.rep_printer_name, short.Parse(MainWindow.rep_print_count));
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {//pie
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    win_lvc win = new win_lvc(cardsQuery, 9);
                    win.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Btn_preview_Click(object sender, RoutedEventArgs e)
        {//preview
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    #region
                    Window.GetWindow(this).Opacity = 0.2;
                    string pdfpath = "";

                    List<ReportParameter> paramarr = new List<ReportParameter>();

                    pdfpath = @"\Thumb\report\temp.pdf";
                    pdfpath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, pdfpath);

                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArCardReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\EN\CardReport.rdlc";
                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    ReportCls.checkLang();

                    clsReports.cardReport(cardsQuery, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);

                    rep.Refresh();

                    LocalReportExtensions.ExportToPDF(rep, pdfpath);
                    wd_previewPdf w = new wd_previewPdf();
                    w.pdfPath = pdfpath;
                    if (!string.IsNullOrEmpty(w.pdfPath))
                    {
                        w.ShowDialog();
                        w.wb_pdfWebViewer.Dispose();
                    }
                    Window.GetWindow(this).Opacity = 1;
                    #endregion
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
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

        private void Img_card_Click(object sender, RoutedEventArgs e)
        {//select image
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                isImgPressed = true;
                openFileDialog.Filter = "Images|*.png;*.jpg;*.bmp;*.jpeg;*.jfif";
                if (openFileDialog.ShowDialog() == true)
                {
                    brush.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName, UriKind.Relative));
                    img_card.Background = brush;
                    imgFileName = openFileDialog.FileName;
                }
                else
                { }
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

        private async void getImg()
        {

            if (string.IsNullOrEmpty(card.image))
            {
                SectionData.clearImg(img_card);
            }
            else
            {
                byte[] imageBuffer = await cardModel.downloadImage(card.image);

                var bitmapImage = new BitmapImage();
                if (imageBuffer != null)
                {
                    using (var memoryStream = new MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }

                    img_card.Background = new ImageBrush(bitmapImage);
                    // configure trmporary path
                    string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string tmpPath = System.IO.Path.Combine(dir, Global.TMPCardsFolder);
                    tmpPath = System.IO.Path.Combine(tmpPath, card.image);
                    openFileDialog.FileName = tmpPath;
                }
                else
                    SectionData.clearImg(img_card);
            }
        }

    }

}
