using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GAMEDATAHUB.Models.BF2042Model
{
    public class ObjectModel
    {
        public string Armed { get; set; }
        public string Captured { get; set; }
        public string Neutralized { get; set; }
        public string Destroyed { get; set; }
        public Time Times { get; set; }

    }

    public class Time {
        public string Total { get; set; }
        public string Attacked { get; set; }
        public string Defended { get; set; }
    }
}