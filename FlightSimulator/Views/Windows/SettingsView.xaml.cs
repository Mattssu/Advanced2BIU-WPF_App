using System.Windows;
using FlightSimulator.ViewModels.Windows;

namespace FlightSimulator.Views.Windows
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class SettingsView : Window
    {
        public SettingsView()
        {
            InitializeComponent();
            DataContext = new SettingsWindowViewModel(this);
        }
    }
}
