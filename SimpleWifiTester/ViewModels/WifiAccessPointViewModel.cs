using System.Diagnostics;
using System.Linq;
using System.Timers;
using Prism.Commands;
using Prism.Mvvm;
using SimpleWifi;
using SimpleWifiTester.Models;

namespace SimpleWifiTester.ViewModels
{
    public class WifiAccessPointViewModel : BindableBase
    {
        public WifiAccessPoint WifiAccessPoint { get; set; }

        public DelegateCommand ConnectCommand { get; set; }
        public DelegateCommand DisconnectCommand { get; set; }

        private bool _canConnect;
        public bool CanConnect
        {
            get => _canConnect;
            set => SetProperty(ref _canConnect, value);
        }

        private bool _canDisconnect;
        public bool CanDisconnect
        {
            get => _canDisconnect;
            set => SetProperty(ref _canDisconnect, value);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public WifiAccessPointViewModel(WifiAccessPoint wifiAccessPoint)
        {
            WifiAccessPoint = wifiAccessPoint;
            _canConnect = !wifiAccessPoint.IsConnected;
            _canDisconnect = wifiAccessPoint.IsConnected;

            ConnectCommand = new DelegateCommand(Connect, CanExecuteConnect);
            DisconnectCommand = new DelegateCommand(Disconnect, CanExecuteDisconnect);

            var timer = new Timer(500);
            timer.Elapsed += (sender, args) => CanConnect = !CanConnect;
            timer.Start();

            var timer2 = new Timer(750);
            timer2.Elapsed += (sender, args) => CanDisconnect = !CanDisconnect;
            timer2.Start();
        }

        public bool CanExecuteConnect() => CanConnect;
        public bool CanExecuteDisconnect() => CanDisconnect;

        /// <summary>
        /// Connect to the given access point.
        /// </summary>
        public void Connect()
        {
            // TODO
        }

        /// <summary>
        /// Disconnects the currently connected access point.
        /// </summary>
        public void Disconnect()
        {
            //var accessPoints = _wifi.GetAccessPoints();
            //foreach (var accessPoint in accessPoints)
            //{
            //    if (accessPoint.Name.Equals(WifiAccessPoint.Name))
            //    {
            //        if (!accessPoint.IsConnected)
            //        {
            //            Debug.WriteLine($"Access point {accessPoint.Name} is already disconnected.");
            //            return;
            //        }

            //        _wifi.Disconnect();
            //    }
            //}
        }
    }
}
