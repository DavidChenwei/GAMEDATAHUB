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
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string Matches { get; set; }
        public string WinPercent { get; set; }
        public string SecondsPlayed { get; set; }

    }
}