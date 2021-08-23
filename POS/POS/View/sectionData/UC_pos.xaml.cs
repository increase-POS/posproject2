﻿using POS.Classes;
using System;
using netoaster;
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

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_pos.xaml
    /// </summary>
    public partial class UC_posAccounts : UserControl
    {
        Pos posModel = new Pos();

        Branch branchModel = new Branch();

        Pos pos = new Pos();

        Branch branch = new Branch();

        IEnumerable<Pos> possQuery;
        IEnumerable<Pos> poss;
        byte tgl_posState;
        string searchText = "";

        BrushConverter bc = new BrushConverter();
        ReportCls reportclass = new ReportCls();
        LocalReport rep = new LocalReport();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        string basicsPermission = "pos_basics";
        private static UC_posAccounts _instance;
        public static UC_posAccounts Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_posAccounts();
                return _instance;
            }
        }
        public UC_posAccounts()
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
            { SectionData.ExceptionMessage(ex, this); }
        }

        private async void fillBranches()
        {

            var branches = await branchModel.GetAllWithoutMain("all");
            cb_branch.ItemsSource = branches;
            cb_branch.SelectedValuePath = "branchId";
            cb_branch.DisplayMemberPath = "name";
        }

        private async void DG_pos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                p_errorName.Visibility = Visibility.Collapsed;
                p_errorCode.Visibility = Visibility.Collapsed;
                p_errorSelectBranch.Visibility = Visibility.Collapsed;

                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tt_errorSelectBranch.Background = (Brush)bc.ConvertFrom("#f8f8f8");

                if (dg_pos.SelectedIndex != -1)
                {
                    pos = dg_pos.SelectedItem as Pos;
                    this.DataContext = pos;
                }
                if (pos != null)
                {
                    if (pos.branchId != 0)
                    {
                        //display branch by id
                        branch = await branchModel.getBranchById(pos.branchId.Value);
                        cb_branch.SelectedValue = branch.branchId;
                    }

                    if (pos.canDelete)
                    {
                        txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
                        txt_delete_Icon.Kind =
                                 MaterialDesignThemes.Wpf.PackIconKind.Delete;
                        tt_delete_Button.Content = MainWindow.resourcemanager.GetString("trDelete");
                    }

                    else
                    {
                        if (pos.isActive == 0)
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
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Tb_code_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void Tb_code_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void Tb_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void Tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void Cb_branchId_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }

        private void Cb_branchId_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
            }
            catch (Exception ex)
            { SectionData.ExceptionMessage(ex, this, sender); }
        }
        private void translate()
        {

            txt_pos.Text = MainWindow.resourcemanager.GetString("trPOS");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_search, MainWindow.resourcemanager.GetString("trSearchHint"));
            txt_baseInformation.Text = MainWindow.resourcemanager.GetString("trBaseInformation");
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_name, MainWindow.resourcemanager.GetString("trPosNameHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(tb_code, MainWindow.resourcemanager.GetString("trPosCodeHint"));
            MaterialDesignThemes.Wpf.HintAssist.SetHint(cb_branch, MainWindow.resourcemanager.GetString("trSelectPosBranchHint"));

            txt_addButton.Text = MainWindow.resourcemanager.GetString("trAdd");
            txt_updateButton.Text = MainWindow.resourcemanager.GetString("trUpdate");
            txt_deleteButton.Text = MainWindow.resourcemanager.GetString("trDelete");
            dg_pos.Columns[0].Header = MainWindow.resourcemanager.GetString("trPosName");
            dg_pos.Columns[1].Header = MainWindow.resourcemanager.GetString("trPosCode");
            dg_pos.Columns[2].Header = MainWindow.resourcemanager.GetString("trBranchName");
            dg_pos.Columns[3].Header = MainWindow.resourcemanager.GetString("trNote");



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
                fillBranches();

                Keyboard.Focus(tb_code);

                cb_branch.SelectedIndex = 0;

                this.Dispatcher.Invoke(() =>
                {
                    Tb_search_TextChanged(null, null);
                });
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }

        }

        private void Btn_clear_Click(object sender, RoutedEventArgs e)
        {//clear
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                tb_name.Clear();
                tb_code.Clear();
                tb_notes.Clear();
                cb_branch.SelectedIndex = -1;

                p_errorName.Visibility = Visibility.Collapsed;
                p_errorCode.Visibility = Visibility.Collapsed;
                p_errorSelectBranch.Visibility = Visibility.Collapsed;

                tb_name.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                tb_code.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                cb_branch.Background = (Brush)bc.ConvertFrom("#f8f8f8");
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private async void Btn_add_Click(object sender, RoutedEventArgs e)
        {//add
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "add") || SectionData.isAdminPermision())
                {
                    pos.posId = 0;
                    #region validate
                    bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "", "Pos", 0);
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty code
                    SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
                    //chk empty branch
                    SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
                    #endregion
                    if ((!tb_name.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
                    {
                        //duplicate
                        if (iscodeExist)
                            SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode, "trDuplicateCodeToolTip");
                        else
                        {
                            pos.code = tb_code.Text;
                            pos.name = tb_name.Text;
                            pos.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                            pos.createUserId = MainWindow.userID.Value;
                            pos.updateUserId = MainWindow.userID.Value;
                            pos.isActive = 1;
                            pos.note = tb_notes.Text;

                            string s = await posModel.savePos(pos);

                            if (s.Equals("Pos Is Added Successfully"))
                            {
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopAdd"), animation: ToasterAnimation.FadeIn);
                                Btn_clear_Click(null, null);
                            }
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            await RefreshPosList();
                            Tb_search_TextChanged(null, null);
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    #region validate
                    bool iscodeExist = await SectionData.isCodeExist(tb_code.Text, "", "Pos", pos.posId);
                    //chk empty name
                    SectionData.validateEmptyTextBox(tb_name, p_errorName, tt_errorName, "trEmptyNameToolTip");
                    //chk empty code
                    SectionData.validateEmptyTextBox(tb_code, p_errorCode, tt_errorCode, "trEmptyCodeToolTip");
                    //chk empty branch
                    SectionData.validateEmptyComboBox(cb_branch, p_errorSelectBranch, tt_errorSelectBranch, "trEmptyBranchToolTip");
                    #endregion

                    if ((!tb_name.Text.Equals("")) && (!tb_code.Text.Equals("")) && (!cb_branch.Text.Equals("")))
                    {
                        //duplicate
                        if (iscodeExist)
                            SectionData.validateDuplicateCode(tb_code, p_errorCode, tt_errorCode, "trDuplicateCodeToolTip");
                        else
                        {
                            pos.code = tb_code.Text;
                            pos.name = tb_name.Text;
                            pos.branchId = Convert.ToInt32(cb_branch.SelectedValue);
                            pos.updateUserId = MainWindow.userID.Value;
                            pos.note = tb_notes.Text;

                            string s = await posModel.savePos(pos);

                            if (s.Equals("Pos Is Updated Successfully"))
                                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopUpdate"), animation: ToasterAnimation.FadeIn);
                            else
                                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

                            await RefreshPosList();
                            Tb_search_TextChanged(null, null);
                        }
                    }
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
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
                    if (pos.posId != 1)
                    {
                        if (pos.posId != 0)
                        {
                            if ((!pos.canDelete) && (pos.isActive == 0))
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
                                if (pos.canDelete)
                                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDelete");
                                if (!pos.canDelete)
                                    w.contentText = MainWindow.resourcemanager.GetString("trMessageBoxDeactivate");
                                w.ShowDialog();
                                Window.GetWindow(this).Opacity = 1;
                                #endregion
                                if (w.isOk)
                                {
                                    string popupContent = "";
                                    if (pos.canDelete) popupContent = MainWindow.resourcemanager.GetString("trPopDelete");
                                    if ((!pos.canDelete) && (pos.isActive == 1)) popupContent = MainWindow.resourcemanager.GetString("trPopInActive");

                                    bool b = await posModel.deletePos(pos.posId, MainWindow.userID.Value, pos.canDelete);

                                    if (b)
                                        Toaster.ShowSuccess(Window.GetWindow(this), message: popupContent, animation: ToasterAnimation.FadeIn);
                                    else
                                        Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);
                                }
                            }

                            await RefreshPosList();
                            Tb_search_TextChanged(null, null);

                            //clear textBoxs
                            Btn_clear_Click(null, null);

                        }
                    }
                    else
                        Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trCannotDeleteTheMainPos"), animation: ToasterAnimation.FadeIn);

                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void activate()
        {//activate

            pos.isActive = 1;

            string s = await posModel.savePos(pos);

            if (s.Equals("Pos Is Updated Successfully"))
                Toaster.ShowSuccess(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopActive"), animation: ToasterAnimation.FadeIn);
            else
                Toaster.ShowWarning(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trPopError"), animation: ToasterAnimation.FadeIn);

            await RefreshPosList();
            Tb_search_TextChanged(null, null);

        }

        async Task<IEnumerable<Pos>> RefreshPosList()
        {
            poss = await posModel.GetPosAsync();
            return poss;
        }
        void RefreshPosView()
        {

            dg_pos.ItemsSource = possQuery;
            txt_count.Text = possQuery.Count().ToString();
            cb_branch.SelectedIndex = -1;

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

                    if (poss is null)
                        await RefreshPosList();
                    searchText = tb_search.Text.ToLower();
                    possQuery = poss.Where(s => (s.name.ToLower().Contains(searchText) ||
                    s.code.ToLower().Contains(searchText)
                    ) && s.isActive == tgl_posState);
                    RefreshPosView();
                }
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void Tgl_posIsActive_Checked(object sender, RoutedEventArgs e)
        {//Active
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (poss is null)
                    await RefreshPosList();
                tgl_posState = 1;
                Tb_search_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private async void Tgl_posIsActive_Unchecked(object sender, RoutedEventArgs e)
        {//inActive
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);
                if (poss is null)
                    await RefreshPosList();
                tgl_posState = 0;
                Tb_search_TextChanged(null, null);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void Btn_refresh_Click(object sender, RoutedEventArgs e)
        {//refresh
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "show") || SectionData.isAdminPermision())
                {
                    RefreshPosList();
                    Tb_search_TextChanged(null, null);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        void FN_ExportToExcel()
        {

            var QueryExcel = possQuery.AsEnumerable().Select(x => new
            {
                Name = x.name,
                Code = x.code,
                Branch = x.branchName,
                Notes = x.note
            });
            var DTForExcel = QueryExcel.ToDataTable();

            DTForExcel.Columns[0].Caption = MainWindow.resourcemanager.GetString("trName");
            DTForExcel.Columns[1].Caption = MainWindow.resourcemanager.GetString("trCode");
            DTForExcel.Columns[2].Caption = MainWindow.resourcemanager.GetString("trBranch");
            DTForExcel.Columns[3].Caption = MainWindow.resourcemanager.GetString("trNote");

            ExportToExcel.Export(DTForExcel);

        }

        private void Btn_exportToExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    Thread t1 = new Thread(() =>
                    {
                        List<ReportParameter> paramarr = new List<ReportParameter>();

                        string addpath;
                        bool isArabic = ReportCls.checkLang();
                        if (isArabic)
                        {
                            addpath = @"\Reports\SectionData\Ar\ArPosReport.rdlc";
                        }
                        else addpath = @"\Reports\SectionData\En\PosReport.rdlc";

                        string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                        clsReports.posReport(possQuery, rep, reppath);
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
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }



        private void Btn_pdf_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    List<ReportParameter> paramarr = new List<ReportParameter>();
                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArPosReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\En\PosReport.rdlc";

                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    clsReports.posReport(possQuery, rep, reppath);
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
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }

        private void Btn_print_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);

                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    List<ReportParameter> paramarr = new List<ReportParameter>();
                    string addpath;
                    bool isArabic = ReportCls.checkLang();
                    if (isArabic)
                    {
                        addpath = @"\Reports\SectionData\Ar\ArPosReport.rdlc";
                    }
                    else addpath = @"\Reports\SectionData\En\PosReport.rdlc";

                    string reppath = reportclass.PathUp(Directory.GetCurrentDirectory(), 2, addpath);

                    clsReports.posReport(possQuery, rep, reppath);
                    clsReports.setReportLanguage(paramarr);
                    clsReports.Header(paramarr);

                    rep.SetParameters(paramarr);
                    rep.Refresh();
                    LocalReportExtensions.PrintToPrinter(rep);
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void btn_pieChart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_main);


                if (MainWindow.groupObject.HasPermissionAction(basicsPermission, MainWindow.groupObjects, "report") || SectionData.isAdminPermision())
                {
                    Window.GetWindow(this).Opacity = 0.2;
                    win_lvc win = new win_lvc(possQuery, 5);
                    win.ShowDialog();
                    Window.GetWindow(this).Opacity = 1;
                }
                else
                    Toaster.ShowInfo(Window.GetWindow(this), message: MainWindow.resourcemanager.GetString("trdontHavePermission"), animation: ToasterAnimation.FadeIn);
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_main, this);
                SectionData.ExceptionMessage(ex, this, sender);
            }
        }
        private void Tb_code_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        private void Tb_code_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }


    }
}
