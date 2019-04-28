using FlightSimulator.Communication;
using System.ComponentModel;
using System.Windows;

namespace FlightSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //in over to disconnect properly
        protected override void OnClosing(CancelEventArgs e)
        {
            Info.Instance.Disconnect();
            base.OnClosing(e);
        }
    }
}
