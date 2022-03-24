using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class accuracyDiscountConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null)
            {
                //var type      = values[0];
                decimal value = (decimal)values[1];

                decimal num = decimal.Parse(value.ToString());
                string s = num.ToString();

                switch (MainWindow.accuracy)
                {
                    case "0":
                        s = string.Format("{0:F0}", num);
                        break;
                    case "1":
                        s = string.Format("{0:F1}", num);
                        break;
                    case "2":
                        s = string.Format("{0:F2}", num);
                        break;
                    case "3":
                        s = string.Format("{0:F3}", num);
                        break;
                    default:
                        s = string.Format("{0:F1}", num);
                        break;
                }

                string sdc = string.Format("{0:G29}", decimal.Parse(s));

                string isCoupon = (string)values[2];
                if (isCoupon == "c")
                {
                    byte type = (byte)values[0];
                    if (type == 2)
                        return sdc + "%";
                    else
                        return s;
                }
                else if ((string)values[2] == "o")
                {
                    string type = (string)values[0];
                    if (type == "2")
                        return sdc + "%";
                    else
                        return s;
                }
                else
                    return "";

            }
            else return "";
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
