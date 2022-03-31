using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class invoicePayStatus : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string s = value as string;
            switch (value)
            {
                case "payed": return MainWindow.resourcemanager.GetString("trPaid_");
                
                case "unpayed": return MainWindow.resourcemanager.GetString("trUnPaid");

                case "partpayed": return MainWindow.resourcemanager.GetString("trPartPaid");

                default: return "";
              
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
