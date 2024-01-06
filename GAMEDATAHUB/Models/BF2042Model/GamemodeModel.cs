using System.Collections.Generic;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class GamemodeModel
    {
        public string GamemodeName { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
        public int Kills { get; set; }
        public int Assists { get; set; }
        public int Revives { get; set; }
        public int BestSquad { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Mvp { get; set; }
        public int Matches { get; set; }
        public int SectorDefend { get; set; }
        public int ObjectivesArmed { get; set; }
        public int ObjectivesDisarmed { get; set; }
        public int ObjectivesDefended { get; set; }
        public int ObjectivesDestroyed { get; set; }
        public int objectivesCaptured { get; set; }
        public int ObjetiveTime { get; set; }
        public decimal KPM { get; set; }
        public string WinPercent { get; set; }
        public decimal WinPercentD { get; set; }
        public int SecondsPlayed { get; set; }
    }

    public class ModeJson {
        public string HeaderName { get; set; }
        public string SortMethod { get; set; }
        public string HeroName { get; set; }
        public string PlatForm { get; set; }
    }

}