using System;
using System.Linq;
using System.Windows;
using semestralka.Data;

namespace semestralka
{
    public partial class VehicleLeaseInfoWindow
    {
        private Vehicle? _currentVehicle;
        private LeaseInfo? _leaseInfo;
		private readonly MainWindow _mainWindow;

        public VehicleLeaseInfoWindow(MainWindow parent)
        {
            InitializeComponent();
            _mainWindow = parent;
        }

		public VehicleLeaseInfoWindow(MainWindow parent, Vehicle vehicle)
		{
			InitializeComponent();
			_mainWindow = parent;
			SetVehicle(vehicle);

			LoadText();
		}

		public VehicleLeaseInfoWindow(MainWindow parent, LeaseInfo leaseInfo)
		{
			InitializeComponent();

            ReturnButton.IsEnabled = false;

			_mainWindow = parent;
			SetLease(leaseInfo);

			LoadText();
		}

		public void SetVehicle(Vehicle vehicle)
		{
			_currentVehicle = vehicle;
            SetLease(_currentVehicle.leases.Last());
		}

		public void SetLease(LeaseInfo leaseInfo)
		{
            _leaseInfo = leaseInfo;
			LoadText();
		}

		private void LoadText()
        {
            if (_leaseInfo== null) return;

            NameLabel.Content = _leaseInfo.name;
            ContactLabel.Content = _leaseInfo.contact;
            From.Content = _leaseInfo.from.ToString("dd.MM.yyyy");
            To.Content = _leaseInfo.to.ToString("dd.MM.yyyy");
            Price.Content = _leaseInfo.totalCost.ToString() + " €";

            if (_leaseInfo.returned != null)
            {
                Returned.Content = ((DateTime) _leaseInfo.returned).ToString("dd.MM.yyyy HH:mm");
            }
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            if (_currentVehicle == null) return;

            var result = MessageBox.Show("Naozaj chceš označiť vozilo ako vrátené?", "Vrátenie vozidla", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            _mainWindow.ReturnVehicle(_currentVehicle);
            Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
