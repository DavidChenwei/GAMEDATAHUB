﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class VehicleGroupModel
    {
        public string GroupName { get; set; }
        public string Id { get; set; }
        public string Kills { get; set; }
        public string KillsPerMinute { get; set; }
        public string Damage { get; set; }
        public string Spawns { get; set; }
        public string RoadKills { get; set; }
        public string PassengerAssists { get; set; }
        public string MultiKills { get; set; }
        public string DistanceTraveled { get; set; }
        public string DriverAssists { get; set; }
        public string VehiclesDestroyedWith { get; set; }
        public string Assists { get; set; }
        public string CallIns { get; set; }
        public string DamageTo { get; set; }
        public string Destroyed { get; set; }
        public string TimeIn { get; set; }
    }
}