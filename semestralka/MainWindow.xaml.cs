using Microsoft.Win32;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            Vehicle vehicle = new Vehicle("Prázne", "Vozidlo", "AA000BB", "", "", 0, 0, 0, 0);
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

            new VehicleLeaseWindow(this, (Vehicle) AvailableVehiclesList.SelectedItem).ShowDialog();
        }

        private void SelectLeasedVehicles(object sender, MouseButtonEventArgs e)
        {
            if (LeasedVehiclesList.SelectedItem == null) return;

            if (editMode)
            {
                EditVehicle((Vehicle) LeasedVehiclesList.SelectedItem);
                return;
            }

            new VehicleLeaseInfoWindow(this, (Vehicle) LeasedVehiclesList.SelectedItem).ShowDialog();
        }

        private void EditVehicle(Vehicle vehicle)
        {
            new VehicleWindow(this, vehicle).ShowDialog();
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

        private void DoubleClickOnVehicle(object sender, RoutedEventArgs e)
        {
            editMode = !editMode;

            ((Button)sender).Content = editMode ? "Dvojklik: Úprava" : "Dvojklik: Správa";
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

            VehicleInfo.Text = currentVehicle.VehicleDetails();

            LeasesList.Items.Clear();
            foreach (var item in currentVehicle.leases)
            {
                LeasesList.Items.Add(item);
            }
        }

		private void SelectedLease(object sender, MouseButtonEventArgs e)
		{
            if (LeasesList.SelectedItem == null) return;

            new VehicleLeaseInfoWindow(this, (LeaseInfo) LeasesList.SelectedItem).ShowDialog();
		}

        private void VehicleEditButton(object sender, RoutedEventArgs e)
        {
            if (currentVehicle == null) return;

            EditVehicle(currentVehicle);
        }

        private void VehicleAdminButton(object sender, RoutedEventArgs e)
        {
            if (currentVehicle == null) return;

            if (AvailableVehiclesList.Items.Contains(currentVehicle))
            {
                new VehicleLeaseWindow(this, currentVehicle).ShowDialog();
                return;
            }
            else if (LeasedVehiclesList.Items.Contains(currentVehicle))
            {
                new VehicleLeaseInfoWindow(this, currentVehicle).ShowDialog();
                return;
            }
        }

        private void LoadButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FileHandlerReader fileHandler = new FileHandlerReader(openFileDialog.OpenFile());

                AvailableVehiclesList.Items.Clear();
                LeasedVehiclesList.Items.Clear();

                foreach (Vehicle vehicle in fileHandler.GetVehicles("available"))
                {
                    AvailableVehiclesList.Items.Add(vehicle);
                }

                foreach (Vehicle vehicle in fileHandler.GetVehicles("leased"))
                {
                    LeasedVehiclesList.Items.Add(vehicle);
                }

                fileHandler.Close();
            }
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV File|*.csv";

            if (saveFileDialog.ShowDialog() == true && saveFileDialog.FileName != "")
            {
                FileHandlerWriter fileHandler = new FileHandlerWriter(saveFileDialog.OpenFile());

                foreach (Vehicle vehicle in AvailableVehiclesList.Items)
                {
                    fileHandler.SaveVehicle(vehicle, "available");
                }

                foreach (Vehicle vehicle in LeasedVehiclesList.Items)
                {
                    fileHandler.SaveVehicle(vehicle, "leased");
                }

                fileHandler.Close();
            }
        }
    }
}
