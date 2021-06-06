using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Resources;
using System.Windows.Shapes;
using POS.Classes;

namespace POS.controlTemplate
{
    /// <summary>
    /// Interaction logic for UC_rectangleCard.xaml
    /// </summary>
    public partial class UC_rectangleCard : UserControl
    {
        public UC_rectangleCard()
        {
            InitializeComponent();
        }
        public int contentId { get; set; }
        public ItemCardView itemCardView { get; set; }
        public UC_rectangleCard(ItemCardView _itemCardView)
        {
            InitializeComponent();





            itemCardView = _itemCardView;
        }
        //ImageBrush brush = new ImageBrush();

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
            if (itemCardView.cardType == "purchase")
            {
                if (itemCardView.language == "ar")
                    grid_main.FlowDirection = FlowDirection.RightToLeft;
                else grid_main.FlowDirection = FlowDirection.LeftToRight;
                #region   Title
                var titleText = new TextBlock();
                titleText.Text = itemCardView.item.name;
                titleText.Margin = new Thickness(5, 0, 5, 0);
                titleText.FontWeight = FontWeights.Bold;
                titleText.VerticalAlignment = VerticalAlignment.Top;
                titleText.HorizontalAlignment = HorizontalAlignment.Left;
                titleText.FontSize = 12;
                titleText.TextWrapping = TextWrapping.Wrap;
                titleText.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#000000"));
                Grid.SetRow(titleText, 1);
                /////////////////////////////////

                #endregion

                #region  subTitle
                var subTitleText = new TextBlock();
                subTitleText.Text = itemCardView.item.details;
                subTitleText.Margin = new Thickness(5, 0, 5, 0);
                subTitleText.FontWeight = FontWeights.Regular;
                subTitleText.VerticalAlignment = VerticalAlignment.Top;
                subTitleText.HorizontalAlignment = HorizontalAlignment.Left;
                subTitleText.FontSize = 10;
                subTitleText.TextWrapping = TextWrapping.Wrap;
                subTitleText.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6e6e6e"));
                Grid.SetRow(subTitleText, 2);
                /////////////////////////////////

                #endregion

                #region Price
                Grid gridPrice = new Grid();
                Grid.SetRow(gridPrice, 3);
                gridPrice.Width = 70;
                gridPrice.Height = 25;
                gridPrice.HorizontalAlignment = HorizontalAlignment.Left;
                gridPrice.Margin = new Thickness(5, 0, 5, 0);
                /////////////////////////////
                Rectangle rectanglePrice = new Rectangle();
                rectanglePrice.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#178DD2"));
                rectanglePrice.RadiusX = 4;
                rectanglePrice.RadiusY = 4;
                gridPrice.Children.Add(rectanglePrice);
                ////////////////////////////////
                var priceText = new TextBlock();
                priceText.Text = itemCardView.item.price.ToString();
                priceText.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                priceText.FontWeight = FontWeights.Bold;
                priceText.VerticalAlignment = VerticalAlignment.Center;
                priceText.HorizontalAlignment = HorizontalAlignment.Center;
                priceText.FontSize = 14;
                gridPrice.Children.Add(priceText);
                /////////////////////////////////

                #endregion

                #region Image
                Button buttonImage = new Button();
                buttonImage.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
                Grid.SetRowSpan(buttonImage, 4);
                Grid.SetColumn(buttonImage, 1);
                buttonImage.Height = 107;
                buttonImage.Width = 100;
                buttonImage.BorderThickness = new Thickness(0);
                buttonImage.Padding = new Thickness(0);
                buttonImage.FlowDirection = FlowDirection.LeftToRight;
                MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(buttonImage, (new CornerRadius(0, 10, 10, 0)));
                SectionData.getImg("Item", itemCardView.item.image, buttonImage);
                //////////////
                #endregion

                #region Path
                //string dataStar = "";
                Path path = new Path();
                Grid.SetRowSpan(path, 4);
                path.Fill = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFA926"));
                path.Stretch = Stretch.Fill;
                Grid.SetColumnSpan(path, 2);
                path.Height = path.Width = 18;
                path.VerticalAlignment = VerticalAlignment.Bottom;
                path.HorizontalAlignment = HorizontalAlignment.Right;
                path.Margin = new Thickness(5);
                path.Data = App.Current.Resources["StarIconGeometry"] as Geometry;

                
                #endregion


                grid_container.Children.Add(titleText);
                grid_container.Children.Add(subTitleText);
                grid_container.Children.Add(gridPrice);
                grid_container.Children.Add(buttonImage);
                grid_container.Children.Add(path);

                //grid_Offer.Visibility = Visibility.Visible;

            }

            else if (itemCardView.cardType == "sale")
            {
                if (itemCardView.language == "ar")
                {

                }
                else
                {

                }
            }
        }

    #region rectangleCardBorderBrush
    public static readonly DependencyProperty rectangleCardBorderBrushDependencyProperty = DependencyProperty.Register("rectangleCardBorderBrush",
            typeof(string),
            typeof(UC_rectangleCard),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardBorderBrush
        {
            set
            { SetValue(rectangleCardBorderBrushDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardBorderBrushDependencyProperty); }
        }
        #endregion

        /*
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
*/



    }
}
