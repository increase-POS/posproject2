using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class accuracyTaxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
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

                return sdc+"%";
            }
            else return "";
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                throw new NotImplementedException();

            }
            catch
            {
                return value;
            }
        }


    }
}
