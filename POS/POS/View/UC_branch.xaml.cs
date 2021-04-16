
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
    /// Interaction logic for UC_branch.xaml
    /// </summary>
    public partial class UC_branch : UserControl
    {

        public int BranchId;
        Branch branches = new Branch();
        public UC_branch()
        {
            InitializeComponent();


            List<Branch> branches = new List<Branch>();



            for (int i = 1; i < 50; i++)
            {
                branches.Add(new Branch()
                {
                    Id = i,
                    name = "branch name " + i,
                    address = "branch address" + i,
                    code = "branch code" + i,

                    mobile = "Test mobile" + i,
                    phone = "Test phone" + i,
                    email = "Test email" + i,
                    details = "branch details" + i,

                }); 
            }





            dg_branch.ItemsSource = branches;
        }

        private void DG_Branch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Branch branch = new Branch();
            if (dg_branch.SelectedIndex != -1)
            {
                branch = dg_branch.SelectedItem as Branch;
                this.DataContext = branch;

                if (branch != null)
                {

                    if (branch.Id != 0)
                    {
                        BranchId = branch.Id;
                    }
                }
            }
        }
    }
}

