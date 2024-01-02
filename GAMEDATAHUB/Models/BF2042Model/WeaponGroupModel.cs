using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class WeaponGroupModel
    {
        public string GroupName { get; set; }
        public string Id { get; set; }
        public string Kills { get; set; }
        public string Damage { get; set; }
        public string BodyKills { get; set; }
        public string HeadshotKills { get; set; }
        public string HipfireKills { get; set; }
        public string MultiKills { get; set; }
        public string Accuracy { get; set; }
        public string KillsPerMinute { get; set; }
        public string DamagePerMinute { get; set; }
        public string Headshots { get; set; }
        public string HitVKills { get; set; }
        public string ShotsHit { get; set; }
        public string ShotsFired { get; set; }
        public string Spawns { get; set; }
        public string TimeEquipped { get; set; }
    }
}