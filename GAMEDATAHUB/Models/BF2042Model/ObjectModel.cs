using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class ObjectModel
    {
        public int Armed { get; set; }
        public int Captured { get; set; }
        public int Neutralized { get; set; }
        public int Destroyed { get; set; }
        public Time Times { get; set; }

    }

    public class Time {
        public int Total { get; set; }
        public int Attacked { get; set; }
        public int Defended { get; set; }
    }
}