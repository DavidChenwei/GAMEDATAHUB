using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class VehicleModel
    {
        public string Type { get; set; }
        public string VehicleName { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
        public int Kills { get; set; }
        public decimal KillsPerMinute { get; set; }
        public int Damage { get; set; }
        public int Spawns { get; set; }
        public int RoadKills { get; set; }
        public int PassengerAssists { get; set; }
        public int MultiKills { get; set; }
        public int DistanceTraveled { get; set; }
        public int DriverAssists { get; set; }
        public int VehiclesDestroyedWith { get; set; }
        public int Assists { get; set; }
        public int CallIns { get; set; }
        public int DamageTo { get; set; }
        public int Destroyed { get; set; }
        public int TimeIn { get; set; }
        public int HoursPlayed
        { 
            get
            {
                return TimeIn / 3600;
            } 
        }

        public int DPM
        {
            get
            {
                if (TimeIn == 0) return 0; 
                return Damage / TimeIn/ 360;
            }
        }


    }

    public class VehicleModelView
    {
        public VehicleModelView()
        {
            Vehicles = new List<VehicleModel>();
        }
        public List<VehicleModel> Vehicles { get; set; }
        public int MaxTime { get; set; }
        public int MaxKills { get; set; }
        public decimal MaxKPM { get; set; }
        public decimal MaxDPM { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string PlatForm { get; set; }
    }
}