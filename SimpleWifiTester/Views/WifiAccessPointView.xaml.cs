using System.Windows;
using System.Windows.Controls;
using SimpleWifiTester.Models;
using SimpleWifiTester.ViewModels;

namespace SimpleWifiTester.Views
{
    /// <summary>
    /// Interaction logic for WifiAccessPointView.xaml
    /// </summary>
    public partial class WifiAccessPointView : UserControl
    {
        public WifiAccessPointView()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            DataContext = new WifiAccessPointViewModel((WifiAccessPoint) DataContext);
        }
    }
}
