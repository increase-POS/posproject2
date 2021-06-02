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
            #region
            /*
            ICollection<SuggestedPeriod> personSepcilaization = (ICollection<SuggestedPeriod>)value;
            if (personSepcilaization.Count > 0)
            {
                string result = "";
                foreach (var item in personSepcilaization)
                {
                    result += item.PeriodDay + ",";
                }
                return result;
            }
            return "";
            */
            /*
            string key = value as string;
            Parent p1 = new Parent();
            p1.Children.Add(new Child { Name = "Ahmad1" });
            p1.Children.Add(new Child { Name = "Mohamad1" });
            Parent p2 = new Parent();
            p2.Children.Add(new Child { Name = "Ahmad2" });
            p2.Children.Add(new Child { Name = "Mohamad2" });
            p2.Children.Add(new Child { Name = "Mohamad3" });
            p2.Children.Add(new Child { Name = "Mohamad4" });
            switch (key)
            {
                case "1":
                    return p1.Children;
                case "2":
                    return p2.Children;

            }
            return p1.Children;
            */
            #endregion
            //BillDetails b = new BillDetails();
            //b.itemUnit =  GetItemUnits(value.ToString()).Result;
            //return b.itemUnit;

            //return GetItemUnits(value.ToString()).Result;
           return Task.Run(() => itemUnit.GetItemUnits(int.Parse(value.ToString()))).Result;

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
            return "unitItemsComboTag" + value;
            

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
