using System;
using System.Windows;
using semestralka.Data;
using semestralka.Utils;

namespace semestralka
{
    public partial class VehicleWindow
    {
        private Vehicle _currentVehicle;
        private readonly MainWindow _mainWindow;

        public VehicleWindow(MainWindow parent, Vehicle vehicle)
        {
            InitializeComponent();
            _mainWindow = parent;
            _currentVehicle = vehicle;
            LoadTexts();
        }

        private void LoadTexts()
        {
            BrandTB.Text = _currentVehicle.brand;
            ModelTB.Text = _currentVehicle.model;
            VINTB.Text = _currentVehicle.vin;
            PlateTB.Text = _currentVehicle.plate;
            ColorTB.Text = _currentVehicle.color;
            DoorsTB.Text = _currentVehicle.numberOfDoors.ToString();
            MilageTB.Text = _currentVehicle.mileage.ToString();
            YearTB.Text = _currentVehicle.year.ToString();
            PriceTB.Text = _currentVehicle.rentPrice.ToString();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            if (BrandTB.Text.Length == 0 || ModelTB.Text.Length == 0 || PlateTB.Text.Length == 0)
            {
                MessageBox.Show("Výrobca, Model a ŠPZ sú povinné polia", Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _currentVehicle.brand = BrandTB.Text;
            _currentVehicle.model = ModelTB.Text;
            _currentVehicle.vin = VINTB.Text;
            _currentVehicle.plate = PlateTB.Text;
            _currentVehicle.color = ColorTB.Text;
            try
            {
                _currentVehicle.numberOfDoors = int.Parse(DoorsTB.Text);
                _currentVehicle.mileage = int.Parse(MilageTB.Text);
                _currentVehicle.year = int.Parse(YearTB.Text);
                _currentVehicle.rentPrice = int.Parse(PriceTB.Text);
            } catch (Exception ex)
            {
                MessageBox.Show(Constants.ErrorSomewhere + "\nChyba: " + ex.Message, Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _mainWindow.Update();
            Close();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Naozaj chceš odstrániť toto vozidlo?", "Odstránenie vozidla", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            _mainWindow.Remove(this._currentVehicle);
            Close();
        }
    }
}
