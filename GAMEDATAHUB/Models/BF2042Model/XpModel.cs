using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class XpModel
    {
        public string Total { get; set; }
        public string Performance { get; set; }
        public Ribbon Ribbons;
    }

    public class Ribbon {
        public string Total { get; set; }
        public string Squad { get; set; }
        public string Combat { get; set; }
        public string Intel { get; set; }
        public string Objective { get; set; }
        public string Support { get; set; }
    }
}