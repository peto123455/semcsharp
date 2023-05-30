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

namespace semestralka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool editMode = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void VehicleCreateButton(object sender, RoutedEventArgs e)
        {
            Vehicle vehicle = new Vehicle("Audi", "R8", "AA123BB", "123456789", "Čierna", 4, 85500, 2015, 50);

            AvailableVehiclesList.Items.Add(vehicle);
        }

        private void SelectAvailableVehicle(object sender, MouseButtonEventArgs e)
        {
            if (AvailableVehiclesList.SelectedItem == null) return;

            if (editMode)
            {
                VehicleWindow window = new VehicleWindow(this, (Vehicle)AvailableVehiclesList.SelectedItem);
                window.Show();
                return;
            }

            LeasedVehiclesList.Items.Add(AvailableVehiclesList.SelectedItem);
            AvailableVehiclesList.Items.Remove(AvailableVehiclesList.SelectedItem);
        }

        private void SelectLeasedVehicles(object sender, MouseButtonEventArgs e)
        {
            if (LeasedVehiclesList.SelectedItem == null) return;

            if (editMode)
            {
                VehicleWindow window = new VehicleWindow(this, (Vehicle)LeasedVehiclesList.SelectedItem);
                window.Show();
                return;
            }

            AvailableVehiclesList.Items.Add(LeasedVehiclesList.SelectedItem);
            LeasedVehiclesList.Items.Remove(LeasedVehiclesList.SelectedItem);
        }

        public void Update()
        {
            AvailableVehiclesList.Items.Refresh();
            LeasedVehiclesList.Items.Refresh();
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            editMode = true;
        }

        private void AdminMode(object sender, RoutedEventArgs e)
        {
            editMode = false;
        }
    }
}
