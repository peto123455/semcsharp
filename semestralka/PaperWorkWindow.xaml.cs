using semestralka.Data;
using System.Windows;
using System.Windows.Controls;

namespace semestralka
{
    public partial class PaperWorkWindow
    {
        private PaperWork? _currentPaperWork;
        private readonly Vehicle _vehicle;
        private readonly MainWindow _mainWindow;

        public PaperWorkWindow(MainWindow parent, Vehicle vehicle)
        {
            InitializeComponent();
            _mainWindow = parent;
            _vehicle = vehicle;

            resetList();
            Update();
        }

        private void AddItemButton(object sender, RoutedEventArgs e)
        {
            new PaperWorkWindowEdit(this, _vehicle).ShowDialog();
        }

        private void DeleteItemButton(object sender, RoutedEventArgs e)
        {
            if (PaperworkList.SelectedItem == null) return;

            var result = MessageBox.Show("Naozaj chceš odstrániť zvolený doklad ?", "Mazanie dokladu", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result != MessageBoxResult.Yes) return;

            _vehicle.paperWorks.Remove((PaperWork)PaperworkList.SelectedItem);
            resetList();
        }


        public void addPaperWork(PaperWork paperWork)
        {
            _vehicle.paperWorks.Add(paperWork);
            resetList();
            Update();
        }

        private void Update()
        {
            PaperworkList.Items.Refresh();

            if (_currentPaperWork == null) return;
            PaperworkTb.Text = _currentPaperWork.PaperworkDetails();
        }

        private void resetList()
        {
            PaperworkList.Items.Clear();

            foreach (var paperWork in _vehicle.paperWorks)
            {
                PaperworkList.Items.Add(paperWork);
            }

            Update();
        }

        private void PaperworkListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PaperworkList.SelectedItem == null) return;

            _currentPaperWork = (PaperWork)PaperworkList.SelectedItem;
            Update();
        }
    }
}
