using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class HeroInfoModel
    {
        public HeroInfoModel() {
            Weapons = new List<WeaponModel>();
            Vehicles = new List<VehicleModel>();
            WeaponGroups = new List<WeaponGroupModel>();
            Classes = new List<ClassModel>();
            Gamemodes = new List<GamemodeModel>();
            Maps = new List<MapModel>();
            Gadgets = new List<GadgetModel>();
            XP = new List<XpModel>();
        }
        public string UserId { get; set; }
        public string Avatar { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public string BestClass { get; set; }
        public string HumanPrecentage { get; set; }
        public string Kills { get; set; }
        public string Deaths { get; set; }
        public string Wins { get; set; }
        public string Loses { get; set; }
        public string KillsPerMinute { get; set; }
        public string DamagePerMinute { get; set; }
        public string KillsPerMatch { get; set; }
        public string DamagePerMatch { get; set; }
        public string HeadShots { get; set; }
        public string WinPercent { get; set; }
        public string Headshots { get; set; }
        public string KillDeath { get; set; }
        public string InfantryKillDeath { get; set; }
        public string Damage { get; set; }
        public string TimePlayed { get; set; }
        public string Accuracy { get; set; }
        public string Revives { get; set; }
        public string Heals { get; set; }
        public string Resupplies { get; set; }
        public string Repairs { get; set; }
        public string SquadmateRevive { get; set; }
        public string SquadmateRespawn { get; set; }
        public string ThrownThrowables { get; set; }

        public string GadgetsDestoyed { get; set; }
        public string CallIns { get; set; }
        public string PlayerTakeDowns { get; set; }
        public string MatchesPlayed { get; set; }
        public string SecondsPlayed { get; set; }
        public string BestSquad { get; set; }
        public string TeammatesSupported { get; set; }
        public string SaviorKills { get; set; }
        public string ShotsFired { get; set; }
        public string ShotsHit { get; set; }
        public string KillAssists { get; set; }
        public string VehiclesDestroyed { get; set; }
        public string EnemiesSpotted { get; set; }
        public string Mvp { get; set; }

        public List<WeaponModel> Weapons;

        public List<VehicleModel> Vehicles;

        public List<WeaponGroupModel> WeaponGroups;

        public List<VehicleGroupModel> VehicleGroups;

        public List<ClassModel> Classes;

        public List<GamemodeModel> Gamemodes;

        public List<MapModel> Maps;

        public List<GadgetModel> Gadgets;

        public List<XpModel> XP;

    }
}