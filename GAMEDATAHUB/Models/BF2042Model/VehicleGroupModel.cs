using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class VehicleGroupModel
    {
        public string GroupName { get; set; }
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
    }
}