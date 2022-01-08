﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    class isActiveConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.ToString().Equals("True"))
                value = MainWindow.resourcemanager.GetString("trValid");
            else if (value.ToString().Equals("False"))
                value = MainWindow.resourcemanager.GetString("trInValid");
            else
                value = "";
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
