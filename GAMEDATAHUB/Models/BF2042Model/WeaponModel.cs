using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class WeaponModel
    {
        public string Type { get; set; }
        public string WeaponName { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
        public int Kills { get; set; }
        public int Damage { get; set; }
        public int BodyKills { get; set; }
        public int HeadshotKills { get; set; }
        public int HipfireKills { get; set; }
        public int MultiKills { get; set; }
        public string Accuracy { get; set; }
        public decimal KillsPerMinute { get; set; }
        public decimal DamagePerMinute { get; set; }
        public string Headshots { get; set; }
        public decimal HitVKills { get; set; }
        public int ShotsHit { get; set; }
        public int ShotsFired { get; set; }
        public int Spawns { get; set; }
        public int TimeEquipped { get; set; }
    }

    public class WeaponModelView
    {
        public WeaponModelView()
        {
            Weapons = new List<WeaponModel>();
        }
        public List<WeaponModel> Weapons { get; set; }
        public decimal MaxKD { get; set; }
        public int MaxKills { get; set; }
        public decimal MaxKPM { get; set; }
        public decimal MaxAccuracy { get; set; }
        public int MaxTime { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string PlatForm { get; set; }
    }
}