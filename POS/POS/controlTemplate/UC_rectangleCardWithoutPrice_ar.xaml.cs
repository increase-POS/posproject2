using POS.Classes;
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
    public partial class UC_rectangleCardWithoutPrice_ar : UserControl
    {
        public UC_rectangleCardWithoutPrice_ar()
        {
            InitializeComponent();
        }
        public Item item { get; set; }
        public UC_rectangleCardWithoutPrice_ar(Item _item)
        {
            InitializeComponent();
            SectionData.getImg("Item", _item.image, btn_cardImage);
            item = _item;
        }
        public int ContentId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
        }
        #region rectangleCardWithoutPriceBorderBrush_ar
        public static readonly DependencyProperty rectangleCardWithoutPriceBorderBrushDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceBorderBrush_ar",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceBorderBrush_ar
        {
            set
            { SetValue(rectangleCardWithoutPriceBorderBrushDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceBorderBrushDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceImageSource_ar
        public static readonly DependencyProperty rectangleCardWithoutPriceImageSourceDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceImageSource_ar",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceImageSource_ar
        {
            set
            { SetValue(rectangleCardWithoutPriceImageSourceDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceImageSourceDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceTitleText_ar
        public static readonly DependencyProperty rectangleCardWithoutPriceTitleTextDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceTitleText_ar",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceTitleText_ar
        {
            set
            { SetValue(rectangleCardWithoutPriceTitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceTitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceSubtitleText_ar
        public static readonly DependencyProperty rectangleCardWithoutPriceSubtitleTextDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceSubtitleText_ar",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceSubtitleText_ar
        {
            set
            { SetValue(rectangleCardWithoutPriceSubtitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceSubtitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceWithoutPriceTitle_ar
        public static readonly DependencyProperty rectangleCardWithoutPriceWithoutPriceTitleDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceWithoutPriceTitle_ar",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceWithoutPriceTitle_ar
        {
            set
            { SetValue(rectangleCardWithoutPriceWithoutPriceTitleDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceWithoutPriceTitleDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceNew_ar
        public static readonly DependencyProperty rectangleCardWithoutPriceNewDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceNew_ar",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceNew_ar
        {
            set
            { SetValue(rectangleCardWithoutPriceNewDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceNewDependencyProperty); }
        }
        #endregion
        #region rectangleCardWithoutPriceOffer_ar
        public static readonly DependencyProperty rectangleCardWithoutPriceOfferDependencyProperty = DependencyProperty.Register("rectangleCardWithoutPriceOffer_ar",
            typeof(string),
            typeof(UC_rectangleCardWithoutPrice),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardWithoutPriceOffer_ar
        {
            set
            { SetValue(rectangleCardWithoutPriceOfferDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardWithoutPriceOfferDependencyProperty); }
        }
        #endregion
    }
}
