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
        public UC_squareCard()
        {
            InitializeComponent();
        }
        public UC_squareCard(Category _category)
        {
            InitializeComponent();
            category = _category;
            SectionData.getImg("Category", _category.image, btn_cardImage);

        }
        public int ContentId { get; set; }
        public int Column { get; set; }
        public int Row { get; set; }
        public int rowCount { get; set; }
        public int columnCount { get; set; }
        public Category category { get; set; }
        ImageBrush brush = new ImageBrush();
         
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = this;
        }
        #region squareCardText
        public static readonly DependencyProperty squareCardTextDependencyProperty = DependencyProperty.Register("squareCardText",
            typeof(string),
            typeof(UC_squareCard),
            new PropertyMetadata("DEFAULT"));
        public string squareCardText
        {
            set
            { SetValue(squareCardTextDependencyProperty, value); }
            get
            { return (string)GetValue(squareCardTextDependencyProperty); }
        }


        #endregion
        #region ButtonImageSource
        public static readonly DependencyProperty squareCardImageSourceDependencyProperty = DependencyProperty.Register("squareCardImageSource",
            typeof(string),
            typeof(UC_squareCard),
            new PropertyMetadata("DEFAULT"));
        public string squareCardImageSource
        {
            set
            { SetValue(squareCardImageSourceDependencyProperty, value); }
            get
            { return (string)GetValue(squareCardImageSourceDependencyProperty); }
        }

        #endregion
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
