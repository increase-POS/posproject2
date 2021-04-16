using POS.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POS.View
{
    /// <summary>
    /// Interaction logic for UC_store.xaml
    /// </summary>
    public partial class UC_store : UserControl
    {
       

        public int BranchId;
        Branch store = new Branch();
        public UC_store()
             {
            InitializeComponent();


            List<Branch> stores = new List<Branch>();



            for (int i = 1; i < 50; i++)
            {
                stores.Add(new Branch()
                {
                    Id = i,
                    name = "store name " + i,
                    address = "store address" + i,
                    code = "store code" + i,

                    mobile = "Test mobile" + i,
                    phone = "Test phone" + i,
                    email = "Test email" + i,
                    details = "store details" + i,

                }); ; ;
            }





            dg_store.ItemsSource = stores;
        }

        private void DG_Store_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Branch store = new Branch();
            if (dg_store.SelectedIndex != -1)
            {
                store = dg_store.SelectedItem as Branch;
                this.DataContext = store;

                if (store != null)
                {

                    if (store.Id != 0)
                    {
                        BranchId = store.Id;
                    }
                }
            }
        
    }
}
}
