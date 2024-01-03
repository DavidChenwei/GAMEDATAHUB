using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class GadgetModel
    {
        public string Type { get; set; }
        public string GadgetName { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
        public int Kills { get; set; }
        public int Spawns { get; set; }
        public int Damage { get; set; }
        public int Uses { get; set; }
        public int MultiKills { get; set; }
        public int VehiclesDestroyedWith { get; set; }
        public decimal KPM { get; set; }
        public decimal DPM { get; set; }
        public int SecondsPlayed { get; set; }
    }
}