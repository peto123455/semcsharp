using System;
using Microsoft.Win32;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using semestralka.Data;
using semestralka.FileHandler;
using semestralka.Utils;

namespace semestralka
{
    public partial class MainWindow
    {
        private bool _editMode = true;
        private Vehicle? _currentVehicle;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void VehicleCreateButton(object sender, RoutedEventArgs e)
        {
            var vehicle = new Vehicle("Prázne", "Vozidlo", "AA000BB", "", "", 0, 0, 0, 0);
            AvailableVehiclesList.Items.Add(vehicle);

            EditVehicle(vehicle);
        }

        private void SelectAvailableVehicle(object sender, MouseButtonEventArgs e)
        {
            if (AvailableVehiclesList.SelectedItem == null) return;

            if (_editMode)
            {
                EditVehicle((Vehicle)AvailableVehiclesList.SelectedItem);
                return;
            }

            new VehicleLeaseWindow(this, (Vehicle) AvailableVehiclesList.SelectedItem).ShowDialog();
        }

        private void SelectLeasedVehicles(object sender, MouseButtonEventArgs e)
        {
            if (LeasedVehiclesList.SelectedItem == null) return;

            if (_editMode)
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
            UpdateVehicleInfo();
        }

        public void LeaseVehicle(Vehicle vehicle, LeaseInfo leaseInfo)
        {
            if (!AvailableVehiclesList.Items.Contains(vehicle)) return;

            vehicle.leases.Add(leaseInfo);
            
            LeasedVehiclesList.Items.Add(vehicle);
            AvailableVehiclesList.Items.Remove(vehicle);

            Update();
        }

        public void ReturnVehicle(Vehicle vehicle)
        {
            if (!LeasedVehiclesList.Items.Contains(vehicle)) return;

            AvailableVehiclesList.Items.Add(vehicle);
            LeasedVehiclesList.Items.Remove(vehicle);

            vehicle.leases.Last().Return();
            Update();
        }

        private void DoubleClickOnVehicle(object sender, RoutedEventArgs e)
        {
            _editMode = !_editMode;

            ((Button)sender).Content = _editMode ? "Dvojklik: Úprava" : "Dvojklik: Správa";
        }

		public bool Remove(Vehicle vehicle)
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
            if (AvailableVehiclesList.SelectedItem == null) return;

            ChangeVehicle((Vehicle) AvailableVehiclesList.SelectedItem);
		}

		private void LeasedVehicleSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            if (LeasedVehiclesList.SelectedItem == null) return;

            ChangeVehicle((Vehicle) LeasedVehiclesList.SelectedItem);
		}

        private void ChangeVehicle(Vehicle vehicle)
        {
            _currentVehicle = vehicle;

            UpdateVehicleInfo();
        }

        private void UpdateVehicleInfo()
        {
            if (_currentVehicle == null) return;

            VehicleInfo.Text = _currentVehicle.VehicleDetails();

            LeasesList.Items.Clear();
            foreach (var item in _currentVehicle.leases)
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
            if (_currentVehicle == null) return;

            EditVehicle(_currentVehicle);
        }

        private void VehicleAdminButton(object sender, RoutedEventArgs e)
        {
            if (_currentVehicle == null) return;

            if (AvailableVehiclesList.Items.Contains(_currentVehicle))
            {
                new VehicleLeaseWindow(this, _currentVehicle).ShowDialog();
            }
            else if (LeasedVehiclesList.Items.Contains(_currentVehicle))
            {
                new VehicleLeaseInfoWindow(this, _currentVehicle).ShowDialog();
            }
        }

        private void LoadButton(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true) return;

            FileHandlerReader fileHandler;
            try
            {
                fileHandler = new FileHandlerReader(openFileDialog.OpenFile());
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.ErrorSomewhere + "\nChyba: " + ex.Message, Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            AvailableVehiclesList.Items.Clear();
            LeasedVehiclesList.Items.Clear();

            foreach (var vehicle in fileHandler.GetVehicles("available"))
            {
                AvailableVehiclesList.Items.Add(vehicle);
            }

            foreach (var vehicle in fileHandler.GetVehicles("leased"))
            {
                LeasedVehiclesList.Items.Add(vehicle);
            }

            fileHandler.Close();

            Update();
        }

        private void SaveButton(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { Filter = "CSV File|*.csv" };

            if (saveFileDialog.ShowDialog() != true || saveFileDialog.FileName == "") return;

            FileHandlerWriter fileHandler;
            try
            {
                fileHandler = new FileHandlerWriter(saveFileDialog.OpenFile());
            }
            catch (Exception ex)
            {
                MessageBox.Show(Constants.ErrorSomewhere + "\nChyba: " + ex.Message, Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            foreach (Vehicle vehicle in AvailableVehiclesList.Items)
            {
                fileHandler.SaveVehicle(vehicle, "available");
            }

            foreach (Vehicle vehicle in LeasedVehiclesList.Items)
            {
                fileHandler.SaveVehicle(vehicle, "leased");
            }

            fileHandler.Close();

            Update();
        }

        private void PaperworkButtonClick(object sender, RoutedEventArgs e)
        {
            if (_currentVehicle == null) return;

            new PaperWorkWindow(_currentVehicle).ShowDialog();
        }
    }
}
