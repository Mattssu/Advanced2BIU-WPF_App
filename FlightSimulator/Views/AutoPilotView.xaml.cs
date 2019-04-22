using System.Windows.Controls;
//
using FlightSimulator.ViewModels;

namespace FlightSimulator.Views
{
    /// <summary>
    /// Interaction logic for AutoPilotView.xaml
    /// </summary>
    public partial class AutoPilotView : UserControl
    {
        private AutoPilotViewModel viewModel;

        public AutoPilotView()
        {
            InitializeComponent();
            viewModel = new AutoPilotViewModel();
            DataContext = viewModel;
        }
    }
}
