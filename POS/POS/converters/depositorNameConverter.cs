using POS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class depositorNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            CashTransfer s = value as CashTransfer;
            
            if (!string.IsNullOrEmpty(s.agentName))
                return s.agentName;
            else if (!string.IsNullOrEmpty(s.usersLName)) 
                return s.usersLName;
            else
                return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    

}
