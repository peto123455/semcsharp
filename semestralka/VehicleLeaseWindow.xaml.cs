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

namespace semestralka
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class VehicleLeaseWindow : Window
    {
        private Vehicle currentVehicle;
        private MainWindow mainWindow;

        public VehicleLeaseWindow(MainWindow parent)
        {
            InitializeComponent();
            mainWindow = parent;
        }

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
            DateTime? from = FromCalendar.SelectedDate;
            DateTime? to = ToCalendar.SelectedDate;

            TimeSpan? range = to - from;

            if (NameTB.Text.Length == 0)
            {
                MessageBox.Show("Meno je povinné !");
                return;
            }
            else if (range == null || from >= to)
            {
                MessageBox.Show("Neplatné dátumy !");
                return;
            }

            int totalCost = currentVehicle.rentPrice * (int)range.Value.TotalDays;
            LeaseInfo leaseInfo = new LeaseInfo(NameTB.Text, ContactTB.Text, (DateTime)FromCalendar.SelectedDate, (DateTime)ToCalendar.SelectedDate, totalCost);

            this.mainWindow.LeaseVehicle(this.currentVehicle, leaseInfo);
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
