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
    /// Interaction logic for UC_rectangleCard.xaml
    /// </summary>
    public partial class UC_rectangleCard : UserControl
    {
        public UC_rectangleCard()
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
        #region rectangleCardImageSource
        public static readonly DependencyProperty rectangleCardImageSourceDependencyProperty = DependencyProperty.Register("rectangleCardImageSource",
            typeof(string),
            typeof(UC_rectangleCard),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardImageSource
        {
            set
            { SetValue(rectangleCardImageSourceDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardImageSourceDependencyProperty); }
        }
        #endregion
        #region rectangleCardTitleText
        public static readonly DependencyProperty rectangleCardTitleTextDependencyProperty = DependencyProperty.Register("rectangleCardTitleText",
            typeof(string),
            typeof(UC_rectangleCard),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardTitleText
        {
            set
            { SetValue(rectangleCardTitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardTitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardSubtitleText
        public static readonly DependencyProperty rectangleCardSubtitleTextDependencyProperty = DependencyProperty.Register("rectangleCardSubtitleText",
            typeof(string),
            typeof(UC_rectangleCard),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardSubtitleText
        {
            set
            { SetValue(rectangleCardSubtitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardSubtitleTextDependencyProperty); }
        }
        #endregion
        #region rectangleCardSecondSubtitleText
        public static readonly DependencyProperty rectangleCardSecondSubtitleTextDependencyProperty = DependencyProperty.Register("rectangleCardSecondSubtitleText",
            typeof(string),
            typeof(UC_rectangleCard),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardSecondSubtitleText
        {
            set
            { SetValue(rectangleCardSecondSubtitleTextDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardSecondSubtitleTextDependencyProperty); }
        }
        #endregion
        
        #region rectangleCardVip
        public static readonly DependencyProperty rectangleCardVipDependencyProperty = DependencyProperty.Register("rectangleCardVip",
            typeof(string),
            typeof(UC_rectangleCard),
            new PropertyMetadata("DEFAULT"));
        public string rectangleCardVip
        {
            set
            { SetValue(rectangleCardVipDependencyProperty, value); }
            get
            { return (string)GetValue(rectangleCardVipDependencyProperty); }
        }
        #endregion
       
    }
}
