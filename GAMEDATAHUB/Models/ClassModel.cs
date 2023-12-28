using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models
{
    public class ClassModel
    {
        public string ClassName { get; set; }
        public string CharacterName { get; set; }
        public string StatName { get; set; }
        public string Image { get; set; }

        public AvatarImage AvatarImages;
        public string Id { get; set; }
        public string Kills { get; set; }
        public string Deaths { get; set; }
        public string KPM { get; set; }
        public string KillDeath { get; set; }
        public string Spawns { get; set; }
        public string Revives { get; set; }
        public string Assists { get; set; }
        public string HazardZoneStreaks { get; set; }
        public string SecondsPlayed { get; set; }

    }

    public class AvatarImage { 
        public string Us { get; set; }
        public string Rus { get; set; }
    }
}