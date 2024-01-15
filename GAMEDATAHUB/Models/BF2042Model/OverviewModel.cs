using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class OverviewModel
    {
        public OverviewModel(){
            WeapoinOverViews = new List<WeapoinOverView>();
            VehiclesOverViews = new List<VehiclesOverView>();
            SpecialistsOverViews = new List<SpecialistsOverView>();
        }

        public int XP { get; set; }
        public int PlayedTime { get; set; }

        public int Level { get; set; }
        public decimal progess { get; set; }

        #region Lifetime Overview
        public string UserName { get; set; }
        public string PlatForm { get; set; }
        public string Avatar { get; set; }
        public int MatchesPlayed { get; set; }
        public decimal DamagePerMinute { get; set; }
        public decimal KillDeath { get; set; }
        public string HeadShotRate { get; set; }
        public string WinPercent { get; set; }
        public decimal HumanKD { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public int KillAssists { get; set; }
        public decimal KillsPerMinute { get; set; }
        public decimal KillsPerMatch { get; set; }
        public int Wins { get; set; }
        public int Loses { get; set; }
        public int Damage { get; set; }  
        public int VehiclesDestroyed { get; set; }
        public decimal DamagePerMatch { get; set; }
        #endregion

        #region Kills
        public int MultiKills { get; set; }
        public int HeadShotAmount { get; set; }
        public int RoadKills { get; set; }
        public int MeleeKills { get; set; }
        public int VechileKills { get; set; }
        public int GrenadesKills { get; set; }
        public int HipfireKills { get; set; }
        public int AIKills { get; set; }
        public int HumanKills { get; set; }
        public int ScopedKills { get; set; }
        #endregion

        #region Object
        public int ObjectTotal { get; set; }
        public int AttackedTotal { get; set; }
        public int DefendedTotal { get; set; }
        public int ArmedObject { get; set; }
        public int DefusedObject { get; set; }
        public int DestroyedObject { get; set; }
        public int CapturedObject { get; set; }
        public int NeutralizedObject { get; set; }
        public int AttackedSector { get; set; }
        public int DefendedSector { get; set; }
        #endregion

        #region Top Data
        #endregion

        #region Weapon/Vehcile/Specialists
        public List<WeapoinOverView> WeapoinOverViews;
        public List<VehiclesOverView> VehiclesOverViews;
        public List<SpecialistsOverView> SpecialistsOverViews;
        #endregion

        public bool isValid { get; set; } = true;

        public RankInfo HeroRank { get; set; }
    }

    public class WeapoinOverView {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Kills { get; set; }
        public string HeadShotRate { get; set; }
    }

    public class VehiclesOverView
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int Kills { get; set; }
        public decimal DPM { get; set; }
    }

    public class SpecialistsOverView
    {
        public string Name { get; set; }
        public string AvatarImage { get; set; }
        public int Playtime { get; set; }
        public int Kills { get; set; }
        public decimal KD { get; set; }
        public decimal KPM { get; set; }
    }

    public class Animation {
        public string HeroName { get; set; } ="";
        public string Platform { get; set; } = ""; 
        public string TargetPage { get; set; } = "";
        public bool isValid { get; set; } = true;
    }

    public class RankInfo {
        public decimal KDRank { get; set; }
        public decimal HSRank { get; set; }
        public decimal WinPercentRank { get; set; }
        public decimal HumanKDRank { get; set; }
        public decimal DeathRank { get; set; }
        public decimal KPMRank { get; set; }
        public decimal KPMatchRank { get; set; }
        public decimal WinRank { get; set; }
        public decimal LostRank { get; set; }
        public decimal DamageRank { get; set; }
        public decimal DPMRank { get; set; }
        public decimal VehiclesDestroyedRank { get; set; }
        public decimal HSAmountRank { get; set; }
        public decimal RoadKillRank { get; set; }
        public decimal MeleeKillRank { get; set; }
        public decimal VehicleKillRank { get; set; }
        public decimal ScopedKillRank { get; set; }
        public decimal HipfireKillRank { get; set; }
        public decimal HumanKillRank { get; set; }
        public decimal AIKillRank { get; set; }
        public decimal ObjectiveTimeRank { get; set; }
        public decimal DisarmedObjectRank { get; set; }
        public decimal CapturedObjectiRank { get; set; }
        public decimal ObjectivesDeutralizeRank { get; set; }
        public decimal SectorsDefendeRank { get; set; }
        public decimal SectorsCapturedRank { get; set; }
        public decimal AttackedObjectRank { get; set; }
        public decimal HeroID { get; set; }
    }
}