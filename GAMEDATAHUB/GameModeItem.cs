//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GAMEDATAHUB
{
    using System;
    using System.Collections.Generic;
    
    public partial class GameModeItem
    {
        public int GameModeItemId { get; set; }
        public Nullable<int> GamemodeID { get; set; }
        public Nullable<int> HeroId { get; set; }
        public Nullable<int> Kills { get; set; }
        public Nullable<int> Assists { get; set; }
        public Nullable<int> Revives { get; set; }
        public Nullable<int> BestSquad { get; set; }
        public Nullable<int> Wins { get; set; }
        public Nullable<int> Losses { get; set; }
        public Nullable<int> Mvp { get; set; }
        public Nullable<int> Matches { get; set; }
        public Nullable<int> SectorDefend { get; set; }
        public Nullable<int> ObjectivesArmed { get; set; }
        public Nullable<int> ObjectivesDisarmed { get; set; }
        public Nullable<int> ObjectivesDefended { get; set; }
        public Nullable<int> ObjectivesDestroyed { get; set; }
        public Nullable<int> ObjetiveTime { get; set; }
        public Nullable<decimal> KPM { get; set; }
        public Nullable<decimal> WinPercent { get; set; }
        public Nullable<int> SecondsPlayed { get; set; }
    
        public virtual GameMode GameMode { get; set; }
        public virtual Hero Hero { get; set; }
    }
}