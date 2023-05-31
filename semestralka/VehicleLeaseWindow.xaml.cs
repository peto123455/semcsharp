using System;
using System.Windows;

namespace semestralka
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class VehicleLeaseWindow : Window
    {
        private Vehicle? currentVehicle;
        private MainWindow mainWindow;

        public VehicleLeaseWindow(MainWindow parent, Vehicle vehicle)
        {
            InitializeComponent();
            mainWindow = parent;
            this.SetVehicle(vehicle);
        }

        public void SetVehicle(Vehicle vehicle)
        {
            currentVehicle = vehicle;
        }

        private void Lease(object sender, RoutedEventArgs e)
        {
            if (currentVehicle == null) return;

            DateTime? from = FromCalendar.SelectedDate;
            DateTime? to = ToCalendar.SelectedDate;

            TimeSpan? range = to - from;

            if (NameTB.Text.Length == 0)
            {
                MessageBox.Show("Meno je povinné !", utils.Constants.ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (from == null || to == null || range == null || from >= to)
            {
                MessageBox.Show("Neplatné dátumy !", utils.Constants.ERROR, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int totalCost = currentVehicle.rentPrice * (int)range.Value.TotalDays;
            LeaseInfo leaseInfo = new LeaseInfo(NameTB.Text, ContactTB.Text, (DateTime)from, (DateTime)to, totalCost);

            this.mainWindow.LeaseVehicle(this.currentVehicle, leaseInfo);
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
