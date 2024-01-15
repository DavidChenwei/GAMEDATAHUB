using Newtonsoft.Json;
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
        public string PlatForm { get; set; }
        public string UserId { get; set; }
        public string Avatar { get; set; }
        public string UserName { get; set; }
        public string Id { get; set; }
        public string BestClass { get; set; }
        public string HumanPrecentage { get; set; }
        public decimal HumanPrecentageD { get
            {
                if ((string.IsNullOrEmpty(WinPercent))){
                    return 0.0m;
                }
                else {
                    if (decimal.TryParse(HumanPrecentage.Replace("%", ""), out decimal HumanPrecent))
                    {
                        return HumanPrecent / 100;
                    }
                    else
                    {
                        return 0.0m;
                    }
                }
            }
        }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public decimal KillsPerMinute { get; set; }
        public decimal DamagePerMinute { get; set; }
        public decimal KillsPerMatch { get; set; }
        public decimal DamagePerMatch { get; set; }
        [JsonProperty("headShots")]
        public int HeadShotAmount { get; set; }
        public string WinPercent { get; set; }
        public decimal WinPercentD {
            get
            {
                if (string.IsNullOrEmpty(WinPercent))
                {
                    return 0.0m;
                }
                else
                {
                    decimal.TryParse(WinPercent.Replace("%", ""), out decimal WinRate);
                    return WinRate;
                }
            }
        }

        [JsonProperty("headshots")]
        public string HeadShotRate { get; set; }
        public decimal HeadShotRateD {
            get
            {
                if (string.IsNullOrEmpty(HeadShotRate))
                {
                    return 0.0m;
                }
                else
                {
                    decimal.TryParse(HeadShotRate.Replace("%", ""), out decimal HSRate);
                    return HSRate;
                }
            }
        }
        public decimal KillDeath { get; set; }
        public decimal InfantryKillDeath { get; set; }
        public int Damage { get; set; }
        public string TimePlayed { get; set; }
        public string Accuracy { get; set; }
        public decimal AccuracyD
        {
            get
            {
                if (string.IsNullOrEmpty(Accuracy))
                {
                    return 0.0m;
                }
                else
                {
                    decimal.TryParse(Accuracy.Replace("%", ""), out decimal AccuracyRate);
                    return AccuracyRate;
                }
            }
        }
        public int Revives { get; set; }
        public int Heals { get; set; }
        public int Resupplies { get; set; }
        public int Repairs { get; set; }
        public int SquadmateRevive { get; set; }
        public int SquadmateRespawn { get; set; }
        public int ThrownThrowables { get; set; }

        public int GadgetsDestoyed { get; set; }
        public int CallIns { get; set; }
        public int PlayerTakeDowns { get; set; }
        public int MatchesPlayed { get; set; }
        public int SecondsPlayed { get; set; }
        public int BestSquad { get; set; }
        public int TeammatesSupported { get; set; }
        public int SaviorKills { get; set; }
        public int ShotsFired { get; set; }
        public int ShotsHit { get; set; }
        public int KillAssists { get; set; }
        public int VehiclesDestroyed { get; set; }
        public int EnemiesSpotted { get; set; }
        public int Mvp { get; set; }
        public string SortMethod { get; set; } = "DESC";
        public string HeaderIndex { get; set; } = "header1";

        public RankInfo HeroRank { get; set; }

        public DividedKillsModel DividedKills;

        public ObjectivetModel Objective;

        public List<XpModel> XP;

        public SectorModel Sector;

        public List<WeaponModel> Weapons;

        public List<VehicleModel> Vehicles;

        public List<WeaponGroupModel> WeaponGroups;

        public List<VehicleGroupModel> VehicleGroups;

        public List<ClassModel> Classes;

        public List<GamemodeModel> Gamemodes;

        public List<MapModel> Maps;

        public List<GadgetModel> Gadgets;

    }
}