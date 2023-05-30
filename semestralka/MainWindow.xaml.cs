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
        private Vehicle? currentVehicle;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void VehicleCreateButton(object sender, RoutedEventArgs e)
        {
            Vehicle vehicle = new Vehicle("Prázne Vozidlo", "", "", "", "", 0, 0, 0, 0);
            AvailableVehiclesList.Items.Add(vehicle);

            EditVehicle(vehicle);
        }

        private void SelectAvailableVehicle(object sender, MouseButtonEventArgs e)
        {
            if (AvailableVehiclesList.SelectedItem == null) return;

            if (editMode)
            {;
                EditVehicle((Vehicle)AvailableVehiclesList.SelectedItem);
                return;
            }

            new VehicleLeaseWindow(this, (Vehicle) AvailableVehiclesList.SelectedItem).Show();
        }

        private void SelectLeasedVehicles(object sender, MouseButtonEventArgs e)
        {
            if (LeasedVehiclesList.SelectedItem == null) return;

            if (editMode)
            {
                EditVehicle((Vehicle) LeasedVehiclesList.SelectedItem);
                return;
            }

            new VehicleLeaseInfoWindow(this, (Vehicle) LeasedVehiclesList.SelectedItem).Show();
        }

        private void EditVehicle(Vehicle vehicle)
        {
            new VehicleWindow(this, vehicle).Show();
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

		public bool remove(Vehicle vehicle)
		{
			if (AvailableVehiclesList.Items.Contains(vehicle))
            {
                AvailableVehiclesList.Items.Remove(vehicle);
                return true;
            }
            else if (LeasedVehiclesList.Items.Contains(vehicle))
            {
                LeasedVehiclesList.Items.Remove(vehicle);
                return true;
            }

            return false;
		}

		private void AvailableVehicleSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			ChangeVehicle((Vehicle) AvailableVehiclesList.SelectedItem);
		}

		private void LeasedVehicleSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            ChangeVehicle((Vehicle) LeasedVehiclesList.SelectedItem);
		}

        private void ChangeVehicle(Vehicle vehicle)
        {
            if (vehicle == null) return;

            this.currentVehicle = vehicle;

            this.UpdateVehicleInfo();
        }

        private void UpdateVehicleInfo()
        {
            if (currentVehicle == null) return;

            VehicleInfo.Text = String.Format("Výrobca: {0}\nModel: {1}", currentVehicle.brand, currentVehicle.model);

            LeasesList.Items.Clear();
            foreach (var item in currentVehicle.leases)
            {
                LeasesList.Items.Add(item);
            }
        }

		private void SelectedLease(object sender, MouseButtonEventArgs e)
		{
            if (LeasesList.SelectedItem == null) return;

            new VehicleLeaseInfoWindow(this, (LeaseInfo) LeasesList.SelectedItem).Show();
		}
	}
}
