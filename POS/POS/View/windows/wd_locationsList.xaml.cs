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
using System.Data;
using System.Resources;
using System.Reflection;

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
        //Location location = new Location();
        
        
        //bool isOpend=true;
        public int sectionId { get; set; }
        Classes.Section section = new Classes.Section();
        Classes.Section sectionModel = new Classes.Section();

        List<Location> allLocationsSource = new List<Location>();
        public List<Location> selectedLocationsSource = new List<Location>();

        List<Location> allLocations = new List<Location>();
        public List<Location> selectedLocations = new List<Location>();

        Location locationModel = new Location();
        Location location = new Location();

        /// <summary>
        /// Selcted Locations if selectedLocations Have Locations At the beginning
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {//load
            SectionData.StartAwait(grid_mainGrid);
            //MessageBox.Show(sectionId.ToString());
            if (MainWindow.lang.Equals("en"))
            { MainWindow.resourcemanager = new ResourceManager("POS.en_file", Assembly.GetExecutingAssembly()); grid_locations.FlowDirection = FlowDirection.LeftToRight; }
            else
            { MainWindow.resourcemanager = new ResourceManager("POS.ar_file", Assembly.GetExecutingAssembly()); grid_locations.FlowDirection = FlowDirection.RightToLeft; }

            translat();

            section = await sectionModel.GetSectionByID(sectionId);
            //MessageBox.Show(section.name);
            allLocationsSource = await locationModel.Get();
            allLocationsSource = allLocationsSource.Where(x => x.branchId == MainWindow.branchID && x.isFreeZone != 1).ToList();

            var query = allLocationsSource.Where(i => i.sectionId == sectionId && i.isFreeZone != 1 && i.isActive == 1);
            selectedLocationsSource = query.ToList();

            allLocations.AddRange(allLocationsSource);
            selectedLocations.AddRange(selectedLocationsSource);

            //remove selected locations from all locations
            foreach (var i in selectedLocations)
            {
                allLocations.Remove(i);
            }
            /////////////////////////////////////////////////
            foreach (var i in allLocations)
            {
                i.x = i.x.Trim() + i.y.Trim() + i.z.Trim();
            }

            foreach (var i in selectedLocations)
            {
                i.x = i.x.Trim() + i.y.Trim() + i.z.Trim();
            }

            lst_allLocations.ItemsSource = allLocations;
            lst_allLocations.SelectedValuePath = "x";
            lst_allLocations.DisplayMemberPath = "locationId";

            lst_selectedLocations.ItemsSource = selectedLocations;
            lst_selectedLocations.SelectedValuePath = "x";
            lst_selectedLocations.DisplayMemberPath = "locationId";
            SectionData.EndAwait(grid_mainGrid,this);
        }

        private void translat()
        {
            //MaterialDesignThemes.Wpf.HintAssist.SetHint(txb_searchitems, MainWindow.resourcemanager.GetString("trSearchHint"));

            btn_save.Content = MainWindow.resourcemanager.GetString("trSave");

            lst_allLocations.Columns[0].Header = MainWindow.resourcemanager.GetString("trLocation");
            lst_selectedLocations.Columns[0].Header = MainWindow.resourcemanager.GetString("trSelectedLocations");

            txt_locations.Text = MainWindow.resourcemanager.GetString("trLocation");
            txt_location.Text = MainWindow.resourcemanager.GetString("trLocation");
            txt_selectedLocations.Text = MainWindow.resourcemanager.GetString("trSelectedLocations");
            //txt_HeaderTitle.Text = MainWindow.resourcemanager.GetString("trSection");
            tt_searchX.Content = MainWindow.resourcemanager.GetString("trX");
            tt_searchY.Content = MainWindow.resourcemanager.GetString("trY");
            tt_searchZ.Content = MainWindow.resourcemanager.GetString("trZ");

            tt_selectAllItem.Content = MainWindow.resourcemanager.GetString("trSelectAllItems");
            tt_unselectAllItem.Content = MainWindow.resourcemanager.GetString("trUnSelectAllItems");
            tt_selectItem.Content = MainWindow.resourcemanager.GetString("trSelectOneItem");
            tt_unselectItem.Content = MainWindow.resourcemanager.GetString("trUnSelectOneItem");

        }

        private void HandleKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Btn_save_Click(null, null);
            }
        }
        private async void Btn_save_Click(object sender, RoutedEventArgs e)
        {//save
            string s = await location.saveLocationsSection(selectedLocations , sectionId, MainWindow.userID.Value);

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
        {//select all
            int x = allLocations.Count;
            for (int i = 0; i < x; i++)
            {
                //MessageBox.Show(i.ToString());
                lst_allLocations.SelectedIndex = 0;
                Btn_selectedLocation_Click(null, null);
            }
        }
        private void Btn_selectedLocation_Click(object sender, RoutedEventArgs e)
        {//select one
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
        {//unselect one
            location = lst_selectedLocations.SelectedItem as Location;
            if (location != null)
            {
                selectedLocations.Remove(location);

                allLocations.Add(location);

                lst_allLocations.ItemsSource = allLocations;
                lst_selectedLocations.ItemsSource = selectedLocations;

                lst_allLocations.Items.Refresh();
                lst_selectedLocations.Items.Refresh();
            }
        }

        private async void Btn_unSelectedAll_Click(object sender, RoutedEventArgs e)
        {//unselect all
            int x = selectedLocations.Count;
            for (int i = 0; i < x; i++)
            {
                lst_selectedLocations.SelectedIndex = 0;
                Btn_unSelectedLocation_Click(null, null);
            }

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

        private void Grid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            //// Have to do this in the unusual case where the border of the cell gets selected.
            //// and causes a crash 'EditItem is not allowed'
            e.Cancel = true;
        }
    }

}
