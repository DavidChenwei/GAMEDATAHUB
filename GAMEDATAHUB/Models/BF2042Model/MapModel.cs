using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
        public int SecondsPlayed { get; set; }

    }
}