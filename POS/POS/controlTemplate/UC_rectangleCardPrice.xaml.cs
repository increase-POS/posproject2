using System;
using System.Collections.Generic;
using System.Linq;
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

namespace POS.controlTemplate
{
    /// <summary>
    /// Interaction logic for UC_rectangleCardPrice.xaml
    /// </summary>
    public partial class UC_rectangleCardPrice : UserControl
    {
        public UC_rectangleCardPrice()
        {
            InitializeComponent();
        }
        public int ContentId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
        }
        #region rectangleCardPriceBorderBrush
        public static readonly DependencyProperty rectangleCardPriceBorderBrushDependencyProperty = DependencyProperty.Register("rectangleCardPriceBorderBrush",
            typeof(string),
            typeof(UC_rectangleCardPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardPriceBorderBrush
        {
            set
            { SetValue(rectangleCardPriceBorderBrushDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardPriceBorderBrushDependencyProperty); }
        }
        #endregion
        #region rectangleCardPriceImageSource
        public static readonly DependencyProperty rectangleCardPriceImageSourceDependencyProperty = DependencyProperty.Register("rectangleCardPriceImageSource",
            typeof(string),
            typeof(UC_rectangleCardPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardPriceImageSource
        {
            set
            { SetValue(rectangleCardPriceImageSourceDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardPriceImageSourceDependencyProperty); }
        }
        #endregion
        #region rectangleCardPriceTitleText
        public static readonly DependencyProperty rectangleCardPriceTitleTextDependencyProperty = DependencyProperty.Register("rectangleCardPriceTitleText",
            typeof(string),
            typeof(UC_rectangleCardPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardPriceTitleText
        {
            set
            { SetValue(rectangleCardPriceTitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardPriceTitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardPriceSubtitleText
        public static readonly DependencyProperty rectangleCardPriceSubtitleTextDependencyProperty = DependencyProperty.Register("rectangleCardPriceSubtitleText",
            typeof(string),
            typeof(UC_rectangleCardPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardPriceSubtitleText
        {
            set
            { SetValue(rectangleCardPriceSubtitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardPriceSubtitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardPricePriceTitle
        public static readonly DependencyProperty rectangleCardPricePriceTitleDependencyProperty = DependencyProperty.Register("rectangleCardPricePriceTitle",
            typeof(string),
            typeof(UC_rectangleCardPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardPricePriceTitle
        {
            set
            { SetValue(rectangleCardPricePriceTitleDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardPricePriceTitleDependencyProperty); }
        }
        #endregion
        #region rectangleCardPriceNew
        public static readonly DependencyProperty rectangleCardPriceNewDependencyProperty = DependencyProperty.Register("rectangleCardPriceNew",
            typeof(string),
            typeof(UC_rectangleCardPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardPriceNew
        {
            set
            { SetValue(rectangleCardPriceNewDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardPriceNewDependencyProperty); }
        }
        #endregion
        #region rectangleCardPriceOffer
        public static readonly DependencyProperty rectangleCardPriceOfferDependencyProperty = DependencyProperty.Register("rectangleCardPriceOffer",
            typeof(string),
            typeof(UC_rectangleCardPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardPriceOffer
        {
            set
            { SetValue(rectangleCardPriceOfferDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardPriceOfferDependencyProperty); }
        }
        #endregion
    }
}
