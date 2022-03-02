using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class offerDiscountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //string oType = (string)values[0];
            //decimal oValue = (decimal)values[1];

            string oType = values[0].ToString();
            decimal oValue = (decimal)values[1];

            if (oType == "1")
                return oValue + " " + MainWindow.Currency;
            else if (oType == "2")
                return oValue + "%";
            else
                return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
