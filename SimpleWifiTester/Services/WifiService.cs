using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using SimpleWifi;

namespace SimpleWifiTester.Services
{
    /// <summary>
    /// This service manages the WiFi communication.
    /// </summary>
    public static class WifiService
    {
        /// <summary>
        /// Static Wifi object.
        /// </summary>
        private static readonly Wifi Wifi = new Wifi();

        /// <summary>
        /// True if there is any access point available, False otherwise.
        /// </summary>
        public static bool WifiAvailable => !Wifi.NoWifiAvailable;

        static WifiService()
        {
            Wifi.ConnectionStatusChanged += OnConnectionStatusChanged;
        }

        /// <summary>
        /// Returns a list of access points ordered by their signal strength.
        /// </summary>
        /// <returns>
        /// An IEnumerable of AccessPoints.
        /// </returns>
        public static IEnumerable<AccessPoint> GetAccessPointsOrderedBySignalStrength()
        {
            var accessPoints = Wifi.GetAccessPoints();
            accessPoints.RemoveAll(ap => string.IsNullOrEmpty(ap.Name));
            var orderedAccessPoints = accessPoints.OrderByDescending(ap => ap.SignalStrength);

            return orderedAccessPoints;
        }

        /// <summary>
        /// Tries to connect to the given access point.
        /// </summary>
        /// <param name="name">The name of the access point.</param>
        public static void Connect(string name)
        {
            var accessPoints = GetAccessPointsOrderedBySignalStrength();
            foreach (var accessPoint in accessPoints)
            {
                if (accessPoint.Name.Equals(name))
                {
                    if (accessPoint.IsConnected)
                    {
                        Debug.WriteLine($"Already connected to access point named {accessPoint.Name}.\n");
                        return;
                    }

                    var authRequest = new AuthRequest(accessPoint);
                    var overwrite = true;

                    if (authRequest.IsPasswordRequired)
                    {
                        if (accessPoint.HasProfile)
                        {
                            // Console.Write("\r\nA network profile already exist, do you want to use it (y/n)? ");
                            overwrite = false;
                        }
                    }

                    if (overwrite)
                    {
                        if (authRequest.IsUsernameRequired)
                        {
                            // Popup window for username
                            authRequest.Username = "";
                        }

                        // Popup window for password
                        authRequest.Password = "";

                        if (authRequest.IsDomainSupported)
                        {
                            // Popup window for domain. Is this really necessary???
                        }
                    }

                    accessPoint.ConnectAsync(authRequest, overwrite, OnConnectionCompleted);
                    return;
                }
            }
        }

        /// <summary>
        /// Disconnects the currently connected access point if there is any.
        /// </summary>
        public static void Disconnect()
        {
            Wifi?.Disconnect();
        }

        /// <summary>
        /// ConnectionCompleted event handler. Called when an access point gets connected
        /// or disconnected.
        /// </summary>
        /// <param name="success">True if the connection was successful, False otherwise.</param>
        private static void OnConnectionCompleted(bool success)
        {
            Debug.WriteLine(success ? "Connection was successful." : "Connection failed.");

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void OnConnectionStatusChanged(object sender, WifiStatusEventArgs args)
        {
            Debug.WriteLine($"Wifi connection status changed to {args.NewStatus}");
            switch (args.NewStatus)
            {
                case WifiStatus.Connected:
                    break;
                case WifiStatus.Disconnected:
                    break;
            }
        }
    }
}