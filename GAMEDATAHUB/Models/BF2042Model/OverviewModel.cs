using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class OverviewModel
    {
        #region Lifetime Overview
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string MatchesPlayed { get; set; }
        public string DamagePerMinute { get; set; }
        public string KillDeath { get; set; }
        public string Headshots { get; set; }
        public string WinPercent { get; set; }
        public string HumanKD { get; set; }
        public string Kills { get; set; }
        public string Deaths { get; set; }
        public string KillAssists { get; set; }
        public string KillsPerMinute { get; set; }
        public string KillsPerMatch { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string Damage { get; set; }  
        public string VehiclesDestroyed { get; set; }
        public string DamagePerMatch { get; set; }
        #endregion

        #region Kills
        public string MultiKills { get; set; }
        public string HeadShots { get; set; }
        public string RoadKills { get; set; }
        public string MeleeKills { get; set; }
        public string VechileKills { get; set; }
        public string GrenadesKills { get; set; }
        public string HipfireKills { get; set; }
        public string AIKills { get; set; }
        public string HumanKills { get; set; }
        public string ScopedKills { get; set; }
        #endregion

        #region Object
        public string ObjectTotal { get; set; }
        public string AttackedTotal { get; set; }
        public string DefendedTotal { get; set; }
        public string ArmedObject { get; set; }
        public string DefusedObject { get; set; }
        public string DestroyedObject { get; set; }
        public string CapturedObject { get; set; }
        public string NeutralizedObject { get; set; }
        public string AttackedSector { get; set; }
        public string DefendedSector { get; set; }
        #endregion
    }
}