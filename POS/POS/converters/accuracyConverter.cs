﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    public class accuracyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            decimal num =  decimal.Parse(value.ToString());
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

            return decimal.Parse(s);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

      
    }
}