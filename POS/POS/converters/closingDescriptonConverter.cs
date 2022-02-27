using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class closingDescriptonConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //string s = value as string;
            string transType = (string)values[0];
            string side = (string)values[1];

           if (transType.Equals("p"))
            {
                if ((side.Equals("bn")) || (side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trReceiptOperation")+" "+ 
                           MainWindow.resourcemanager.GetString("trFrom") + " " + 
                           side;//receive
                }
                else if ((!side.Equals("bn")) || (!side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trPayment")+" "+
                           MainWindow.resourcemanager.GetString("trTo") + " " + 
                           side;//دفع
                }
                else return "";
            }
            else if (transType.Equals("d"))
            {
                if ((side.Equals("bn")) || (side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trDeposit")+" "+
                           MainWindow.resourcemanager.GetString("trTo") + " " + 
                           side;
                }
                else if ((!side.Equals("bn")) || (!side.Equals("p")))
                {
                    return MainWindow.resourcemanager.GetString("trReceive")+" "+
                           MainWindow.resourcemanager.GetString("trFrom") + " " + 
                           side;//قبض
                }
                else return "";
            }
            else return "";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
