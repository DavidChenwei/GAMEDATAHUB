using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class ClassModel
    {
        public string ClassName { get; set; }
        public string CharacterName { get; set; }
        public string StatName { get; set; }
        public string Image { get; set; }

        public AvatarImage AvatarImages;
        public string Id { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public decimal KPM { get; set; }
        public decimal KillDeath { get; set; }
        public int Spawns { get; set; }
        public int Revives { get; set; }
        public int Assists { get; set; }
        public int HazardZoneStreaks { get; set; }
        public int SecondsPlayed { get; set; }

    }

    public class AvatarImage { 
        public string Us { get; set; }
        public string Rus { get; set; }
    }
}