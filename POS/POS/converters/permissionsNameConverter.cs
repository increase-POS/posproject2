using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace POS.converters
{
    public class permissionsNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value.Equals("suppliersBasics") || value.Equals("customersBasics") || value.Equals("usersBasics") || value.Equals("cardsBasics") ||
                value.Equals("branchesBasics") || value.Equals("storesBasics") || value.Equals("posBasics") || value.Equals("banksBasics")
                || value.Equals("shippingCompanyBasics") )
            {
                value = MainWindow.resourcemanager.GetString("trPermissionsBasics");
            }
            else if (value.Equals("usersStores") || value.Equals("branchesBranches") || value.Equals("storesBranches"))
            {
                value = MainWindow.resourcemanager.GetString("trBranchs/Stores");
            }
            //else switch (value)
            //{
            //    case "111":
            //        value = MainWindow.resourcemanager.GetString("sssssssssssss");
            //        break;
            //    case "222":
            //        value = MainWindow.resourcemanager.GetString("sssssssssssss");
            //        break;
            //    case "3333":
            //        value = MainWindow.resourcemanager.GetString("sssssssssssss");
            //        break;

            //    default: break;
            //}
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
