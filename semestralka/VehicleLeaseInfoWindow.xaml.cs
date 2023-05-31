using System;
using System.Linq;
using System.Windows;
using semestralka.Data;

namespace semestralka
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
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
			this.SetVehicle(vehicle);

			LoadText();
		}

		public VehicleLeaseInfoWindow(MainWindow parent, LeaseInfo leaseInfo)
		{
			InitializeComponent();

            ReturnButton.IsEnabled = false;

			_mainWindow = parent;
			this.SetLease(leaseInfo);

			LoadText();
		}

		public void SetVehicle(Vehicle vehicle)
		{
			_currentVehicle = vehicle;
            SetLease(_currentVehicle.leases.Last());
		}

		public void SetLease(LeaseInfo leaseInfo)
		{
            this._leaseInfo = leaseInfo;
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

            this._mainWindow.ReturnVehicle(_currentVehicle);
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
