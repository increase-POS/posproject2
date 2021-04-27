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
    /// Interaction logic for UC_rectangleCardWithoutPrice.xaml
    /// </summary>
    public partial class UC_rectangleCardWithoutPrice : UserControl
    {
        public UC_rectangleCardWithoutPrice()
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
        #region rectangleCardWithoutPriceBorderBrush
        public static readonly DependencyProperty rectangleCardWithoutPriceBorderBrushDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceBorderBrush",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceBorderBrush
        {
            set
            { SetValue(rectangleCardWithoutPriceBorderBrushDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceBorderBrushDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceImageSource
        public static readonly DependencyProperty rectangleCardWithoutPriceImageSourceDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceImageSource",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceImageSource
        {
            set
            { SetValue(rectangleCardWithoutPriceImageSourceDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceImageSourceDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceTitleText
        public static readonly DependencyProperty rectangleCardWithoutPriceTitleTextDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceTitleText",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceTitleText
        {
            set
            { SetValue(rectangleCardWithoutPriceTitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceTitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceSubtitleText
        public static readonly DependencyProperty rectangleCardWithoutPriceSubtitleTextDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceSubtitleText",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceSubtitleText
        {
            set
            { SetValue(rectangleCardWithoutPriceSubtitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceSubtitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceWithoutPriceTitle
        public static readonly DependencyProperty rectangleCardWithoutPriceWithoutPriceTitleDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceWithoutPriceTitle",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceWithoutPriceTitle
        {
            set
            { SetValue(rectangleCardWithoutPriceWithoutPriceTitleDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceWithoutPriceTitleDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceNew
        public static readonly DependencyProperty rectangleCardWithoutPriceNewDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceNew",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceNew
        {
            set
            { SetValue(rectangleCardWithoutPriceNewDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceNewDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceOffer
        public static readonly DependencyProperty rectangleCardWithoutPriceOfferDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceOffer",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceOffer
        {
            set
            { SetValue(rectangleCardWithoutPriceOfferDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceOfferDependencyProperty); }
        }
        #endregion
    }
}
