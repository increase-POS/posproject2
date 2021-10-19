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

        //async public  Enumerable ItemUnit GetItemUnits(int itemId)
        //{
        //    var itemUnits = await itemUnit.GetItemUnits(itemId);
        //    return itemUnits;

        //}

        // public async  List<ItemUnit>  GetItemUnits(string itemId)
        //{
        //    BillDetails b = new BillDetails();
        //    var itemUnits = await itemUnit.GetItemUnits(int.Parse(itemId));
        //    //List<ItemUnit> list = await Task.Run(() => itemUnit.GetItemUnits(int.Parse(itemId)));
        //    b.itemUnit = itemUnits;
        //    return b.itemUnit;
        //}

        //private Task<List<ItemUnit>> GetItemUnits(string itemId)
        //{
        //    return Task.Run(() => itemUnit.GetItemUnits(int.Parse(itemId)));
        //}
        public  object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result  = Task.Run(() => itemUnit.GetItemUnits(int.Parse(value.ToString()))).Result;
            return  result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
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
