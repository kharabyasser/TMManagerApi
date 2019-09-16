using System;

namespace TMManagerApi.Models
{
    public class OnlineSatellite
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string Truck { get; set; }
        public string Meter { get; set; }
        public bool IsDualMeter { get; set; }
        public string Printer { get; set; }
        public string TruckMasterVersion { get; set; }
        public string RemoteServiceVersion { get; set; }
        public string TeamViewerID { get; set; }
        public string TeamViewerVersion { get; set; }
        public string OS { get; set; }
        public bool IsOnline { get; set; }
        public DateTime LastSynch { get; set; }
    }
}
