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
    public partial class VehicleLeaseInfoWindow : Window
    {
        private Vehicle currentVehicle;
        private MainWindow mainWindow;

        public VehicleLeaseInfoWindow(MainWindow parent)
        {
            InitializeComponent();
            mainWindow = parent;
        }

        public VehicleLeaseInfoWindow(MainWindow parent, Vehicle vehicle)
        {
            InitializeComponent();
            mainWindow = parent;
            this.SetVehicle(vehicle);

            LoadText();
        }

        public void SetVehicle(Vehicle vehicle)
        {
            currentVehicle = vehicle;
            LoadText();
        }

        private void LoadText()
        {
            LeaseInfo leaseInfo = currentVehicle.leases.Last();

            Name.Content = leaseInfo.Name;
            Contact.Content = leaseInfo.Contact;
            From.Content = leaseInfo.from.ToString("dd.MM.yyyy");
            To.Content = leaseInfo.to.ToString("dd.MM.yyyy");
            Price.Content = leaseInfo.totalCost.ToString() + " €";
        }

        private void Return(object sender, RoutedEventArgs e)
        {
            this.mainWindow.ReturnVehicle(currentVehicle);
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
