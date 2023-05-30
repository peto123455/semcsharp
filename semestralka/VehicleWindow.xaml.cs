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
    public partial class VehicleWindow : Window
    {
        private Vehicle currentVehicle;
        private MainWindow mainWindow;

        public VehicleWindow(MainWindow parent)
        {
            InitializeComponent();
            mainWindow = parent;
        }

        public VehicleWindow(MainWindow parent, Vehicle vehicle)
        {
            InitializeComponent();
            mainWindow = parent;
            this.SetVehicle(vehicle);
        }

        public void SetVehicle(Vehicle vehicle)
        {
            currentVehicle = vehicle;

            LoadTexts();
        }

        private void LoadTexts()
        {
            BrandTB.Text = currentVehicle.brand;
            ModelTB.Text = currentVehicle.model;
            VINTB.Text = currentVehicle.vin;
            PlateTB.Text = currentVehicle.plate;
            ColorTB.Text = currentVehicle.color;
            DoorsTB.Text = currentVehicle.numberOfDoors.ToString();
            MilageTB.Text = currentVehicle.milage.ToString();
            YearTB.Text = currentVehicle.year.ToString();
            PriceTB.Text = currentVehicle.rentPrice.ToString();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (BrandTB.Text.Length == 0 || ModelTB.Text.Length == 0 || PlateTB.Text.Length == 0)
            {
                MessageBox.Show("Výrobca, Model a ŠPZ sú povinné polia");
                return;
            }

            currentVehicle.brand = BrandTB.Text;
            currentVehicle.model = ModelTB.Text;
            currentVehicle.vin = VINTB.Text;
            currentVehicle.plate = PlateTB.Text;
            currentVehicle.color = ColorTB.Text;
            currentVehicle.numberOfDoors = int.Parse(DoorsTB.Text);
            currentVehicle.milage = int.Parse(MilageTB.Text);
            currentVehicle.year = int.Parse(YearTB.Text);
            currentVehicle.rentPrice = int.Parse(PriceTB.Text);

            this.mainWindow.Update();
            this.Close();
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
