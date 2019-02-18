using Prism.Mvvm;
using SimpleWifi;
using SimpleWifiTester.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using SimpleWifiTester.Services;

namespace SimpleWifiTester.ViewModels
{
    public class WifiConnectionViewModel : BindableBase
    {
        public ObservableCollection<WifiAccessPoint> AccessPoints { get; set; }

        public DelegateCommand GetAccessPointsCommand { get; set; }

        public bool WifiAvailable => WifiService.WifiAvailable;

        public WifiConnectionViewModel()
        {
            AccessPoints = new ObservableCollection<WifiAccessPoint>();
            GetAccessPointsCommand = new DelegateCommand(GetAccessPoints);
        }

        public void GetAccessPoints()
        {
            var accessPoints = WifiService.GetAccessPointsOrderedBySignalStrength();
            foreach (var accessPoint in accessPoints)
            {
                AccessPoints.Add(new WifiAccessPoint
                {
                    Name = accessPoint.Name,
                    SignalStrength = accessPoint.SignalStrength,
                    IsConnected = accessPoint.IsConnected,
                    IsSecure = accessPoint.IsSecure
                });
            }
        }
    }
}
