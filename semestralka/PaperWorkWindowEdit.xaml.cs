using System;
using System.Windows;
using semestralka.Data;
using semestralka.Utils;

namespace semestralka
{
    public partial class PaperWorkWindowEdit
    {
        private Vehicle? _currentVehicle;
        private readonly PaperWorkWindow _mainWindow;

        public PaperWorkWindowEdit(PaperWorkWindow parent, Vehicle vehicle)
        {
            InitializeComponent();
            _mainWindow = parent;
            _currentVehicle = vehicle;
        }

        private void DeselectCalendarButton(object sender, RoutedEventArgs e)
        {
            ToCalendar.SelectedDate = null;
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            if (_currentVehicle == null) return;

            var from = FromCalendar.SelectedDate;
            var to = ToCalendar.SelectedDate;

            if (NameTB.Text.Length == 0)
            {
                MessageBox.Show("Názov je povinný !", Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (from == null || (to != null && from >= to))
            {
                MessageBox.Show("Neplatný/é dátum/y !", Constants.Error, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var paperWork = new PaperWork(NameTB.Text, (DateTime)from, DescriptionTb.Text);

            if (to != null) paperWork.validUntil = (DateTime)to;

            _mainWindow.AddPaperWork(paperWork);

            Close();
        }
    }
}
