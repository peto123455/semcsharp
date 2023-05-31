using semestralka.Data;
using System.Windows;
using System.Windows.Controls;

namespace semestralka
{
    public partial class PaperWorkWindow
    {
        private PaperWork? _currentPaperWork;
        private readonly Vehicle _vehicle;

        public PaperWorkWindow(Vehicle vehicle)
        {
            InitializeComponent();
            _vehicle = vehicle;

            ResetList();
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
            ResetList();
        }


        public void AddPaperWork(PaperWork paperWork)
        {
            _vehicle.paperWorks.Add(paperWork);
            ResetList();
            Update();
        }

        private void Update()
        {
            PaperworkList.Items.Refresh();

            if (_currentPaperWork == null) return;
            PaperworkTb.Text = _currentPaperWork.PaperworkDetails();
        }

        private void ResetList()
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
