using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class processTypeAndCardConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string pType = (string)values[0];
            string cName = (string)values[1];

            switch (pType)
            {
                case "cash": return MainWindow.resourcemanager.GetString("trCash");
                //break;
                case "doc": return MainWindow.resourcemanager.GetString("trDocument");
                //break;
                case "cheque": return MainWindow.resourcemanager.GetString("trCheque");
                //break;
                case "balance": return MainWindow.resourcemanager.GetString("trCredit");
                //break;
                case "card": return cName;
                //break;
                case "inv": return MainWindow.resourcemanager.GetString("trInv");
                case "multiple": return MainWindow.resourcemanager.GetString("trMultiplePayment");

                //break;
                default: return pType;
                    //break;
            }

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
