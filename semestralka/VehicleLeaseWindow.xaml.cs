using System;
using System.Windows;
using semestralka.Data;
using semestralka.Utils;

namespace semestralka
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class VehicleLeaseWindow
    {
        private Vehicle? _currentVehicle;
        private readonly MainWindow _mainWindow;

        public VehicleLeaseWindow(MainWindow parent, Vehicle vehicle)
        {
            InitializeComponent();
            _mainWindow = parent;
            this.SetVehicle(vehicle);
        }

        public void SetVehicle(Vehicle vehicle)
        {
            _currentVehicle = vehicle;
        }

        private void Lease(object sender, RoutedEventArgs e)
        {
            if (_currentVehicle == null) return;

            var from = FromCalendar.SelectedDate;
            var to = ToCalendar.SelectedDate;

            var range = to - from;

            if (NameTB.Text.Length == 0)
            {
                MessageBox.Show("Meno je povinné !", Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (from == null || to == null || range == null || from >= to)
            {
                MessageBox.Show("Neplatné dátumy !", Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var totalCost = _currentVehicle.rentPrice * (int)range.Value.TotalDays;
            var leaseInfo = new LeaseInfo(NameTB.Text, ContactTB.Text, (DateTime)from, (DateTime)to, totalCost);

            this._mainWindow.LeaseVehicle(this._currentVehicle, leaseInfo);
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
