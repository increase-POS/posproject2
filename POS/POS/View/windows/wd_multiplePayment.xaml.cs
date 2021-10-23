using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Resources;
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_multiplePayment.xaml
    /// </summary>
    public partial class wd_multiplePayment : Window
    {
        public wd_multiplePayment()
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
        static private object _Sender;
        public bool isOk { get; set; }
        ImageBrush brush = new ImageBrush();
        static private string _SelectedPaymentType = "cash";
        static private int _SelectedCard = -1;
        Card cardModel = new Card();
        public IEnumerable<Card> cards;
        public Invoice invoice = new Invoice();

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (sender != null)
                    SectionData.StartAwait(grid_ucInvoice);

                configurProcessType();

                // get it from invoice
                loading_fillCardCombo();

                //////////////////////////
                //invoice.agentId
                //////////////////////////

                tb_moneySympol1.Text = tb_moneySympol2.Text = MainWindow.Currency;


                if (sender != null)
                    SectionData.EndAwait(grid_ucInvoice);
            }
            catch (Exception ex)
            {
                if (sender != null)
                    SectionData.EndAwait(grid_ucInvoice);
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void translat()
        {

            txt_title.Text = MainWindow.resourcemanager.GetString("trMultiplePayment");

            //    MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_search, MainWindow.resourcemanager.GetString("trSearchHint"));


            //    col_num.Header = MainWindow.resourcemanager.GetString("trInvoiceNumber");
            //    col_branch.Header = MainWindow.resourcemanager.GetString("trBranch");
            //    col_user.Header = MainWindow.resourcemanager.GetString("trUser");
            //    col_count.Header = MainWindow.resourcemanager.GetString("trQTR");
            //    col_total.Header = MainWindow.resourcemanager.GetString("trTotal");
            //    col_type.Header = MainWindow.resourcemanager.GetString("trType");


            //    btn_select.Content = MainWindow.resourcemanager.GetString("trSelect");
        }
        private void configurProcessType()
        {
            cb_paymentProcessType.DisplayMemberPath = "Text";
            cb_paymentProcessType.SelectedValuePath = "Value";
            if (invoice.invType.Equals("sbd"))
            {
                var typelist = new[] {
                 new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trCredit") , Value = "balance" },
                };
                cb_paymentProcessType.ItemsSource = typelist;
            }
            else
            {
                var typelist = new[] {
                new { Text = MainWindow.resourcemanager.GetString("trCash")       , Value = "cash" },
                new { Text = MainWindow.resourcemanager.GetString("trCredit") , Value = "balance" },
                new { Text = MainWindow.resourcemanager.GetString("trAnotherPaymentMethods") , Value = "card" },
                 };

                cb_paymentProcessType.ItemsSource = typelist;
            }
            cb_paymentProcessType.SelectedIndex = 0;
        }
        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isOk = false;
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
                SectionData.ExceptionMessage(ex, this);
            }
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

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            isOk = true;

        }

        private void input_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = sender.GetType().Name;
                if (name == "TextBox")
                {
                    if ((sender as TextBox).Name == "tb_processNum")
                        SectionData.validateEmptyTextBox((TextBox)sender, p_errorProcessNum, tt_errorProcessNum, "trEmptyProcessNumToolTip");
                }
                if (name == "ComboBox")
                {
                   
                    if ((sender as ComboBox).Name == "cb_paymentProcessType")
                        SectionData.validateEmptyComboBox((ComboBox)sender, p_errorpaymentProcessType, tt_errorpaymentProcessType, "trErrorEmptyPaymentTypeToolTip");

                }
                if (name == "TextBlock")
                {

                    if ((sender as TextBlock).Name == "txt_card")
                        SectionData.validateEmptyTextBlock((TextBlock)sender, p_errorCard, tt_errorCard, "trSelectCreditCard");
                }

            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void Cb_paymentProcessType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                
                switch (cb_paymentProcessType.SelectedIndex)
                {
                    case 0://cash
                        gd_theRest.Visibility = Visibility.Visible;
                        tb_cashPaid.Text = txt_theRest.Text = "0";
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_processNum.Clear();
                        _SelectedCard = -1;
                        txt_card.Text = "";
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        SectionData.clearValidate(tb_processNum, p_errorCard);
                        break;
                    case 1:// balance
                        gd_theRest.Visibility = Visibility.Collapsed;
                        tb_cashPaid.Text = txt_theRest.Text = "0";
                        gd_card.Visibility = Visibility.Collapsed;
                        tb_processNum.Clear();
                        _SelectedCard = -1;
                        txt_card.Text = "";
                        SectionData.clearTextBlockValidate(txt_card, p_errorCard);
                        SectionData.clearValidate(tb_processNum, p_errorCard);
                        break;
                    case 2://card
                        gd_theRest.Visibility = Visibility.Collapsed;
                        tb_cashPaid.Text = txt_theRest.Text = "0";
                        gd_card.Visibility = Visibility.Visible;
                        break;
                }
                
            }
            catch (Exception ex)
            {
                
                SectionData.ExceptionMessage(ex, this);
            }
        }
        void InitializeCardsPic(IEnumerable<Card> cards)
        {
            #region cardImageLoad
            dkp_cards.Children.Clear();
            int userCount = 0;
            foreach (var item in cards)
            {
                #region Button
                Button button = new Button();
                //button.DataContext = item.name;
                button.DataContext = item;
                button.Tag = item.cardId;
                button.Padding = new Thickness(0, 0, 0, 0);
                button.Margin = new Thickness(2.5, 5, 2.5, 5);
                button.Background = null;
                button.BorderBrush = null;
                button.Height = 35;
                button.Width = 35;
                button.Click += card_Click;
                //Grid.SetColumn(button, 4);
                #region grid
                Grid grid = new Grid();
                #region 
                Ellipse ellipse = new Ellipse();
                //ellipse.Margin = new Thickness(-5, 0, -5, 0);
                ellipse.StrokeThickness = 1;
                ellipse.Stroke = Application.Current.Resources["MainColorOrange"] as SolidColorBrush;
                ellipse.Height = 35;
                ellipse.Width = 35;
                ellipse.FlowDirection = FlowDirection.LeftToRight;
                ellipse.ToolTip = item.name;
                userImageLoad(ellipse, item.image);
                Grid.SetColumn(ellipse, userCount);
                grid.Children.Add(ellipse);
                #endregion
                #endregion
                button.Content = grid;
                #endregion
                dkp_cards.Children.Add(button);

            }
            #endregion
        }
        void card_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            _SelectedCard = int.Parse(button.Tag.ToString());
            //txt_card.Text = button.DataContext.ToString();
            Card card = button.DataContext as Card;
            txt_card.Text = card.name;
            if (card.hasProcessNum.Value)
                tb_processNum.Visibility = Visibility.Visible;
            else
                tb_processNum.Visibility = Visibility.Collapsed;
        }
        async void loading_fillCardCombo()
        {
            try
            {
                InitializeCardsPic(cards);
            }
            catch (Exception)
            { }
        }
        async void userImageLoad(Ellipse ellipse, string image)
        {
            try
            {
                if (!string.IsNullOrEmpty(image))
                {
                    clearImg(ellipse);

                    byte[] imageBuffer = await cardModel.downloadImage(image); // read this as BLOB from your DB
                    var bitmapImage = new BitmapImage();
                    using (var memoryStream = new System.IO.MemoryStream(imageBuffer))
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                    }
                    ellipse.Fill = new ImageBrush(bitmapImage);
                }
                else
                {
                    clearImg(ellipse);
                }
            }
            catch
            {
                clearImg(ellipse);
            }
        }
        private void clearImg(Ellipse ellipse)
        {
            Uri resourceUri = new Uri("pic/no-image-icon-90x90.png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            brush.ImageSource = temp;
            ellipse.Fill = brush;
        }
        private void PreventSpaces(object sender, KeyEventArgs e)
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
        private void Tb_cashPaid_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tb_total.Text) && !string.IsNullOrEmpty(tb_cashPaid.Text))
                {
                    if (tb_cashPaid.Text.Equals("0"))
                    {
                        txt_theRest.Text = "0";
                        txt_theRest.Foreground = Application.Current.Resources["MainColorGrey"] as SolidColorBrush;
                    }
                    else
                    {
                        decimal total = decimal.Parse(tb_total.Text);
                        decimal cashPaid = decimal.Parse(tb_cashPaid.Text);
                        decimal theRest = (cashPaid - total);

                        txt_theRest.Text = theRest.ToString();

                        if (theRest > 0)
                            txt_theRest.Foreground = Application.Current.Resources["mediumGreen"] as SolidColorBrush;
                        else if (theRest < 0)
                            txt_theRest.Foreground = Application.Current.Resources["mediumRed"] as SolidColorBrush;
                        else
                            txt_theRest.Foreground = Application.Current.Resources["MainColorGrey"] as SolidColorBrush;
                    }


                }
                else
                {
                    txt_theRest.Text = "0";
                    txt_theRest.Foreground = Application.Current.Resources["MainColorGrey"] as SolidColorBrush;
                }
            }
            catch (Exception ex)
            {
                SectionData.ExceptionMessage(ex, this);
            }
        }
        private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            try
            {
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
        private void Tb_EnglishDigit_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only english and digits
            Regex regex = new Regex("^[a-zA-Z0-9. -_?]*$");
            if (!regex.IsMatch(e.Text))
                e.Handled = true;
        }
        private void Tb_textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _Sender = sender;
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
                if ((sender as TextBox).Name == "tb_cash")
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
            if (name == "TextBox")
            {
                if ((sender as TextBox).Name == "tb_cash")
                    SectionData.validateEmptyTextBox((TextBox)sender, p_errorCash, tt_errorCash, "trEmptyCashToolTip");
            }

        }
        private void Tb_cash_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {//only decimal
            var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$");
            if (regex.IsMatch(e.Text) && !(e.Text == "." && ((TextBox)sender).Text.Contains(e.Text)))
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
