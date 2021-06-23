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
using System.Windows.Shapes;

namespace POS.View.windows
{
    /// <summary>
    /// Interaction logic for wd_locationsList.xaml
    /// </summary>
    public partial class wd_locationsList : Window
    {
        public wd_locationsList()
        {
            InitializeComponent();
        }

       
        public bool isActive;
        Location location = new Location();
        List<Location> allLocations = new List<Location>();
        public List<Location> selectedLocations = new List<Location>();
        Location locationModel = new Location();
        bool isOpend=true;

        /// <summary>
        /// Selcted Locations if selectedLocations Have Locations At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            allLocations = (await locationModel.Get()).Where(x => x.isActive == 1).ToList();

            foreach (var location in selectedLocations)
            {
                allLocations.Remove(location);

            }
            selectedLocations.AddRange(selectedLocations);


            lst_allLocations.ItemsSource = allLocations;
            lst_selectedLocations.ItemsSource = selectedLocations;



            lst_allLocations.SelectedValuePath = "locationId";
            lst_selectedLocations.SelectedValuePath = "locationId";
            lst_allLocations.DisplayMemberPath = "name";
            lst_selectedLocations.DisplayMemberPath = "name";
        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            isActive = true;
            this.Close();
        }

        private void Btn_colse_Click(object sender, RoutedEventArgs e)
        {
            isActive = false;
            this.Close();
        }

        private void Lst_allLocations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            Btn_selectedLocation_Click(null, null);

        }

        private void Lst_selectedLocations_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Btn_unSelectedLocation_Click(null, null);

        }


        private async void Btn_selectedAll_Click(object sender, RoutedEventArgs e)
        {
            selectedLocations =( await locationModel.Get() ).Where(x => x.isActive == 1).ToList();
            allLocations.Clear();
            lst_allLocations.ItemsSource = allLocations;
            lst_selectedLocations.ItemsSource = selectedLocations;
            lst_allLocations.Items.Refresh();
            lst_selectedLocations.Items.Refresh();
        }
        private void Btn_selectedLocation_Click(object sender, RoutedEventArgs e)
        {
            location = lst_allLocations.SelectedItem as Location;
            if (location != null)
            {
                allLocations.Remove(location);
                selectedLocations.Add(location);
                lst_allLocations.ItemsSource = allLocations;
                lst_selectedLocations.ItemsSource = selectedLocations;
                lst_allLocations.Items.Refresh();
                lst_selectedLocations.Items.Refresh();
            }

        }


        private void Btn_unSelectedLocation_Click(object sender, RoutedEventArgs e)
        {

            location = lst_selectedLocations.SelectedItem as Location;
            if (location != null)
            {
                selectedLocations.Remove(location);
                allLocations.Add(location);

                lst_allLocations.ItemsSource = allLocations;
                lst_allLocations.Items.Refresh();
                lst_selectedLocations.ItemsSource = selectedLocations;
                lst_selectedLocations.Items.Refresh();
            }
        }

        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {
            allLocations = (await locationModel.Get()).Where(x => x.isActive == 1).ToList();
            selectedLocations.Clear();
            lst_allLocations.ItemsSource = allLocations;
            lst_allLocations.Items.Refresh();
            lst_selectedLocations.ItemsSource = selectedLocations;
            lst_selectedLocations.Items.Refresh();

        }

        private void Txb_searchlocations_TextChanged(object sender, TextChangedEventArgs e)
        {
            lst_allLocations.ItemsSource = allLocations.Where(x => (x.x.ToLower().Contains(txb_searchX.Text.ToLower()) &&
            x.y.ToLower().Contains(txb_searchY.Text.ToLower()) &&
            x.z.ToLower().Contains(txb_searchZ.Text.ToLower())
            ) && x.isActive == 1);
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
    }

}
