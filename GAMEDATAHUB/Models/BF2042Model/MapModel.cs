using System.Collections.Generic;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class MapModel
    {
        public string MapName { get; set; }
        public string Image { get; set; }
        public string Id { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Matches { get; set; }
        public string WinPercent { get; set; }

        public decimal WinPercentD
        {
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

        public int SecondsPlayed { get; set; }
        public int HoursPlayed
        {
            get
            {
                return SecondsPlayed / 3600;
            }
        }
    }

    public class MapModeView
    {
        public MapModeView()
        {
            Maps = new List<MapModel>();
        }

        public List<MapModel> Maps { get; set; }

        public int MaxWins { get; set; }
        public decimal MaxWinPercent { get; set; }
        public int MaxLosses { get; set; }
        public decimal MaxMatch { get; set; }
        public int MaxTime { get; set; }

        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string PlatForm { get; set; }
    }
}