using System.Windows.Controls;
//
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ManualView : UserControl
    {
        private ManualViewModel viewModel;
        public ManualView()
        {
            InitializeComponent();
            viewModel = new ManualViewModel();
            DataContext = viewModel;
        }
    }
}
