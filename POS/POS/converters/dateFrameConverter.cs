using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    public class dateFrameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
            DateTime date;
            if (value is DateTime)
                date = (DateTime)value;
            else return value;

            switch (MainWindow.dateFormat)
            {
                case "ShortDatePattern":
                    return date.ToString(dtfi.ShortDatePattern);
                    break;
                case "LongDatePattern":
                    return date.ToString(dtfi.LongDatePattern);
                    break;
                case "MonthDayPattern":
                    return date.ToString(dtfi.MonthDayPattern);
                    break;
                case "YearMonthPattern":
                    return date.ToString(dtfi.YearMonthPattern);
                    break;
                default:
                    return date.ToString(dtfi.ShortDatePattern);
                    break;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
