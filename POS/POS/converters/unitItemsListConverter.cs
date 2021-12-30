using POS.Classes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using static POS.View.uc_payInvoice;

namespace POS.converters
{
    public class unitItemsListConverter : IValueConverter
    {
        ItemUnit itemUnit = new ItemUnit();
         
        //public  object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        //{
        //    var result  = Task.Run(() => itemUnit.GetItemUnits(int.Parse(value.ToString()))).Result;
        //    return  result;
        //}
        public  object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var result = Task.Run(() => itemUnit.GetItemUnits(int.Parse(value.ToString()))).Result;

            if(MainWindow.mainWindow.GlobalItemUnitsList.Count == 0 )
                //MainWindow.mainWindow.GlobalItemUnitsList = await MainWindow.mainWindow.GlobalItemUnit.GetIU();
                MainWindow.mainWindow.GlobalItemUnitsList = Task.Run(() =>  MainWindow.mainWindow.GlobalItemUnit.GetIU()).Result;
            var result = itemUnit.GetIUbyItem(int.Parse(value.ToString()),
                MainWindow.mainWindow.GlobalItemUnitsList,
                MainWindow.mainWindow.GlobalUnitsList);

            return result;
        }

        public  object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class unitItemsComboTagConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
            

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
