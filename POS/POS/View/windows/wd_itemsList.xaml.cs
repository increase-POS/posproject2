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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_itemsList.xaml
    /// </summary>
    public partial class wd_itemsList : Window
    {
        public wd_itemsList()
        {
            InitializeComponent();
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //All
            //LST_PersonWillTake.Items.Add(LST_PersonAll.SelectedItem);
            //LST_PersonWillTake.SelectedValuePath = "PersonID";
            //LST_PersonWillTake.DisplayMemberPath = "PersonName";
            //Person
            //(int)LST_Program.SelectedValue // idperson
            //(int)LST_Program.SelectedValue // idperson
            //(int)LST_Program.SelectedValue // idperson

        }
        void ok()
        {
            //ArrayPerson = new int[LST_PersonWillTake.Items.Count];

            //for (int i = 0; i < LST_PersonWillTake.Items.Count; i++)
            //{
            //    LST_PersonWillTake.SelectedIndex = i;
            //    ArrayPerson[i] = (int)LST_PersonWillTake.SelectedValue;
            //}
            //this.Close();
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
           this.Close();
        }
    }
}
