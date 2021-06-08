using POS.Classes;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace POS.controlTemplate
{
    /// <summary>
    /// Interaction logic for UC_squareCard.xaml
    /// </summary>
    public partial class UC_squareCard : UserControl
    {
        public int ContentId { get; set; }
        public CardViewItems categoryCardView { get; set; }
        public int rowCount { get; set; }
        public int columnCount { get; set; }

        public UC_squareCard()
        {
            InitializeComponent();

        }
        public UC_squareCard(CardViewItems _categoryCardView)
        {
            InitializeComponent();
            categoryCardView = _categoryCardView;
            //SectionData.getImg("Category", _categoryCardView.category.image, btn_cardImage);
            InitializeControls();

        }

       
        void InitializeControls()
        {
            this.DataContext = this;

            #region
            /*
            #region Grid Container
            Grid gridContainer = new Grid();

            ColumnDefinition[] cd = new ColumnDefinition[2];
            for (int i = 0; i < 2; i++)
                cd[i] = new ColumnDefinition();
            cd[0].Width = new GridLength(1.2, GridUnitType.Star);
            cd[1].Width = new GridLength(1, GridUnitType.Star);
            for (int i = 0; i < 2; i++)
                gridContainer.ColumnDefinitions.Add(cd[i]);


            //< RowDefinition Height = "5*" />
            //         < RowDefinition Height = "16*" />
            //          < RowDefinition Height = "13*" />
            //           < RowDefinition Height = "20*" />

            RowDefinition[] rd = new RowDefinition[4];
            for (int i = 0; i < 4; i++)
            {
                rd[i] = new RowDefinition();
            }
            rd[0].Height = new GridLength(5, GridUnitType.Star);
            rd[1].Height = new GridLength(16, GridUnitType.Star);
            rd[2].Height = new GridLength(13, GridUnitType.Star);
            rd[3].Height = new GridLength(20, GridUnitType.Star);
            for (int i = 0; i < 4; i++)
            {
                gridContainer.RowDefinitions.Add(rd[i]);
            }
            gridContainer.Height = this.ActualHeight - 10;
            gridContainer.Width = this.ActualWidth - 10;
            brd_main.Child = gridContainer;
            #endregion
            if (itemCardView.language == "ar")
                grid_main.FlowDirection = FlowDirection.RightToLeft;
            else grid_main.FlowDirection = FlowDirection.LeftToRight;
            
            #region Image
            Button buttonImage = new Button();
            buttonImage.Background = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFFFF"));
            //Grid.SetRowSpan(buttonImage, 4);
            //Grid.SetColumn(buttonImage, 1);
            //buttonImage.Height = 107;
            buttonImage.Height = (gridContainer.Height) - 7.5;
            //buttonImage.Width = 100;
            buttonImage.Width = (gridContainer.Width / 2.2) - 7.5;
            buttonImage.BorderThickness = new Thickness(0);
            buttonImage.Padding = new Thickness(0);
            //buttonImage.Margin = new Thickness(5);
            buttonImage.FlowDirection = FlowDirection.LeftToRight;
            //buttonImage.HorizontalAlignment = HorizontalAlignment.Center;
            //buttonImage.VerticalAlignment = VerticalAlignment.Center;
            //MaterialDesignThemes.Wpf.ButtonAssist.SetCornerRadius(buttonImage, (new CornerRadius(0, 10, 10, 0)));
            SectionData.getImg("Item", itemCardView.item.image, buttonImage);


            Grid grid_image = new Grid();
            grid_image.Height = buttonImage.Height - 2;
            grid_image.Width = buttonImage.Width - 1;
            //grid_image.HorizontalAlignment = HorizontalAlignment.Center;
            //grid_image.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetRowSpan(grid_image, 4);
            Grid.SetColumn(grid_image, 1);
            grid_image.Children.Add(buttonImage);
            //////////////
            #endregion
           
            gridContainer.Children.Add(grid_image);
            */
            #endregion

            #region   Title
            var titleText = new TextBlock();
            titleText.Text = categoryCardView.category.name;
            Grid.SetRow(titleText, 1);
            titleText.Foreground = (SolidColorBrush)(new BrushConverter().ConvertFrom("#6e6e6e"));
            titleText.VerticalAlignment = VerticalAlignment.Center;
            titleText.HorizontalAlignment = HorizontalAlignment.Center;
            titleText.FontWeight = FontWeights.Bold;
            titleText.FontSize = 12;
            //titleText.TextWrapping = TextWrapping.Wrap;
            #endregion
            grid_main.Children.Add(titleText);


        }
        //#region squareCardText
        //public static readonly DependencyProperty squareCardTextDependencyProperty = DependencyProperty.Register("squareCardText",
        //    typeof(string),
        //    typeof(UC_squareCard),
        //    new PropertyMetadata("DEFAULT"));
        //public string squareCardText
        //{
        //    set
        //    { SetValue(squareCardTextDependencyProperty, value); }
        //    get
        //    { return (string)GetValue(squareCardTextDependencyProperty); }
        //}


        //#endregion
        //#region ButtonImageSource
        //public static readonly DependencyProperty squareCardImageSourceDependencyProperty = DependencyProperty.Register("squareCardImageSource",
        //    typeof(string),
        //    typeof(UC_squareCard),
        //    new PropertyMetadata("DEFAULT"));
        //public string squareCardImageSource
        //{
        //    set
        //    { SetValue(squareCardImageSourceDependencyProperty, value); }
        //    get
        //    { return (string)GetValue(squareCardImageSourceDependencyProperty); }
        //}

        //#endregion
        #region ButtonBorderBrush
        public static readonly DependencyProperty squareCardBorderBrushDependencyProperty = DependencyProperty.Register("squareCardBorderBrush",
            typeof(string),
            typeof(UC_squareCard),
            new PropertyMetadata("DEFAULT"));
        public string squareCardBorderBrush
        {
            set
            { SetValue(squareCardBorderBrushDependencyProperty, value); }
            get
            { return (string)GetValue(squareCardBorderBrushDependencyProperty); }
        }
        #endregion





    }
}
