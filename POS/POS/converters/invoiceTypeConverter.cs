﻿using POS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
     
    public class invoiceTypeConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return Task.Run(() => itemUnit.GetItemUnits(int.Parse(value.ToString()))).Result;
            string s = value as string ;
            //if (value.Equals("pd"))
            //    return MainWindow.resourcemanager.GetString("trSaleInvoice");
            //else 
            if (value.Equals("pbd"))
                return MainWindow.resourcemanager.GetString("trReturnInvoice");
            else return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class invoiceTypeVisibilityConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return Task.Run(() => itemUnit.GetItemUnits(int.Parse(value.ToString()))).Result;
            string s = value as string;
            //if (value.Equals("pd"))
            //    return MainWindow.resourcemanager.GetString("trSaleInvoice");
            //else 
            if (value.Equals("pbd") || value.Equals("pbd"))
                return System.Windows.Visibility.Visible;
            else return System.Windows.Visibility.Collapsed; ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}