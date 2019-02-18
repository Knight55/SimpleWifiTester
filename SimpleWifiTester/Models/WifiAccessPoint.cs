namespace SimpleWifiTester.Models
{
    public class WifiAccessPoint
    {
        public string Name { get; set; }

        public bool IsSecure { get; set; }

        public bool IsConnected { get; set; }

        public uint SignalStrength { get; set; }
    }
}
