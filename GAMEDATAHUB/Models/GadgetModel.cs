using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models
{
    public class GadgetModel
    {
        public string Type { get; set; }
        public string GadgetName { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
        public string Kills { get; set; }
        public string Spawns { get; set; }
        public string Damage { get; set; }
        public string Uses { get; set; }
        public string MultiKills { get; set; }
        public string VehiclesDestroyedWith { get; set; }
        public string KPM { get; set; }
        public string DPM { get; set; }
        public string SecondsPlayed { get; set; }
    }
}