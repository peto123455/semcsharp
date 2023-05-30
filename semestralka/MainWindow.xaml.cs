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
        public bool editMode = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void VehicleCreateButton(object sender, RoutedEventArgs e)
        {
            Vehicle vehicle = new Vehicle("Prázne Vozidlo", "", "", "", "", 0, 0, 0, 0);

            AvailableVehiclesList.Items.Add(vehicle);
        }

        private void SelectAvailableVehicle(object sender, MouseButtonEventArgs e)
        {
            if (AvailableVehiclesList.SelectedItem == null) return;

            if (editMode)
            {
                VehicleWindow vehicleWindow = new VehicleWindow(this, (Vehicle)AvailableVehiclesList.SelectedItem);
                vehicleWindow.Show();
                return;
            }

            VehicleLeaseWindow vehicleLease = new VehicleLeaseWindow(this, (Vehicle)AvailableVehiclesList.SelectedItem);
            vehicleLease.Show();
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

            VehicleLeaseInfoWindow vehicleLeaseInfo = new VehicleLeaseInfoWindow(this, (Vehicle)LeasedVehiclesList.SelectedItem);
            vehicleLeaseInfo.Show();
        }

        public void Update()
        {
            AvailableVehiclesList.Items.Refresh();
            LeasedVehiclesList.Items.Refresh();
        }

        public void LeaseVehicle(Vehicle vehicle, LeaseInfo leaseInfo)
        {
            if (!AvailableVehiclesList.Items.Contains(vehicle)) return;

            vehicle.leases.Add(leaseInfo);
            
            LeasedVehiclesList.Items.Add(vehicle);
            AvailableVehiclesList.Items.Remove(vehicle);

            this.Update();
        }

        public void ReturnVehicle(Vehicle vehicle)
        {
            if (!LeasedVehiclesList.Items.Contains(vehicle)) return;

            AvailableVehiclesList.Items.Add(vehicle);
            LeasedVehiclesList.Items.Remove(vehicle);

            vehicle.leases.Last().Return();
            this.Update();
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
