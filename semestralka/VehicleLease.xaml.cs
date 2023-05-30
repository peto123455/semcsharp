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
    public partial class VehicleLease : Window
    {
        private Vehicle currentVehicle;
        private MainWindow mainWindow;

        public VehicleLease(MainWindow parent)
        {
            InitializeComponent();
            mainWindow = parent;
        }

        public VehicleLease(MainWindow parent, Vehicle vehicle)
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

            //LeaseInfo leaseInfo = new LeaseInfo();

            this.mainWindow.Update();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
