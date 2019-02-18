using System.Windows;
using SimpleWifiTester.ViewModels;

namespace SimpleWifiTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new WifiConnectionViewModel();
        }

        private void OnPopupButtonClicked(object sender, RoutedEventArgs args)
        {
            var popupWindow = new PopupWindow();
            popupWindow.Show();
            popupWindow.Activate();
            popupWindow.Topmost = true;
            popupWindow.Focus();
        }
    }
}
