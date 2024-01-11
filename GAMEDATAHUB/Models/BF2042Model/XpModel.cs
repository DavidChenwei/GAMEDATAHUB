using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class XpModel
    {
        public int Total { get; set; }
        public int Performance { get; set; }
        public Ribbon Ribbons;
    }

    public class Ribbonss {
        public int Total { get; set; }
        public int Squad { get; set; }
        public int Combat { get; set; }
        public int Intel { get; set; }
        public int Objective { get; set; }
        public int Support { get; set; }
    }
}