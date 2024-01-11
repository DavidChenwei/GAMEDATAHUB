using System;
using System.Collections.Generic;
using System.Linq;

namespace GAMEDATAHUB.Repository
{
    public class Utils
    {
        public const string DescMethods = "Desc";
        public const string AsceMethod = "Asce";
        public const string HeaderWin = "Wins";
        public const string HeaderWinPercent = "Win %";
        public const string HeaderKill = "Kills";
        public const string HeaderKPM = "Kills/min";
        public const string HeaderKD = "K/D";
        public const string HeaderPlayTime = "Playtime";
        public const string HeaderGameMode = "Gamemode";
        public const string HeaderSpecialist = "Specialist";
        public const string HeaderAccuracy = "Accuracy";
        public const string HeaderDPM = "Damage/min";
        public const string HeaderHeadShot = "HS%";
        public const string HeaderUse = "Uses";
        public const string HeaderDamage = "Damage";
        public const string HeaderLosses = "Losses";
        public const string HeaderMatches = "Matches";

        public static readonly Dictionary<string, int> MapNamesToIds = new Dictionary<string, int>
        {
            {"Renewal", 1},
            {"Orbital", 2},
            {"Manifest", 3},
            {"Discarded", 4},
            {"Kaleidescope", 5},
            {"Breakaway", 6},
            {"Hourglass", 7},
            {"Spearhead", 8},
            {"Exposure", 9},
            {"Stranded", 10},
            {"Noshahr Canals", 11},
            {"Caspian Border", 12},
            {"Valparaiso", 13},
            {"Arica Harbor", 14},
            {"Battle of the Bulge", 15},
            {"El Alamein", 16},
            {"Flashpoint", 17},
            {"Reclaimed", 18},
            {"Redacted", 19}

        };

        public static readonly Dictionary<string, int> ModeNamesToIds = new Dictionary<string, int>
        {
            {"Breakthrough Large", 1},
            {"Breakthrough", 2},
            {"Conquest Large", 3},
            {"Conquest", 4},
            {"Custom", 5},
            {"Rush", 6},
            {"Hazard Zone Large", 7},
            {"Hazard Zone", 8}

        };

        public static readonly Dictionary<string, int> SpecialistNamesToIds = new Dictionary<string, int>
        {
            {"Mackay", 1},
            {"Angel", 2},
            {"Falck", 3},
            {"Paik", 4},
            {"Sundance", 5},
            {"Dozer", 6},
            {"Rao", 7},
            {"Lis", 8},
            {"Irish", 9},
            {"Crawford", 10},
            {"Boris", 11},
            {"Zain", 12},
            {"Casper", 13},
            {"Blasco", 14},
            {"BF3 Recon", 15},
            {"BF3 Assault", 16},
            {"BF3 Support", 17},
            {"BF3 Engineer", 18},
            {"BC2 Recon", 19},
            {"BC2 Medic", 20},
            {"BC2 Engineer", 21},
            {"BC2 Assault", 22},
            {"1942 Anti-tank", 23},
            {"1942 Assault", 24},
            {"1942 Engineer", 25},
            {"1942 Medic", 26},
            {"1942 Scout", 27}
        };

        public static readonly Dictionary<string, int> WeaponNamesToIds = new Dictionary<string, int>
        {
            {"PP-29", 1},
            {"MP9", 2},
            {"K30", 3},
            {"PBX-45", 4},
            {"SWS-10", 5},
            {"NTW-50", 6},
            {"DXR-1", 7},
            {"AM40", 8},
            {"VCAR", 9},
            {"Ghostmaker R10", 10},
            {"BSV-M", 11},
            {"G57", 12},
            {"M44", 13},
            {"MCS-880", 14},
            {"12M Auto", 15},
            {"MP28", 16},
            {"Rorsch Mk-4", 17},
            {"Avancys", 18},
            {"PKP-BP", 19},
            {"LCMG", 20},
            {"M24 Sniper", 21},
            {"M16A3", 22},
            {"GVT 45-70", 23},
            {"P90", 24},
            {"PF51", 25},
            {"AC-42", 26},
            {"AK-24", 27},
            {"M5A3", 28},
            {"SFAR-M GL", 29},
            {"K98 Sniper", 30},
            {"DM7", 31},
            {"AKS-74u", 32},
            {"M240B", 33},
            {"MP412 REX", 34},
            {"MP443", 35},
            {"M93R", 36},
            {"SPAS-12", 37},
            {"M60E4", 38},
            {"M39 EMR", 39},
            {"A-91", 40},
            {"SVD", 41},
            {"ACW-R", 42},
            {"M98B", 43},
            {"M416", 44},
            {"SCAR-H", 45},
            {"AEK-971", 46},
            {"NVK-P125", 47},
            {"NVK-S22", 48},
            {"SVK", 49},
            {"XM8 Compact", 50},
            {"StG 44", 51},
            {"M2 Carbine", 52},
            {"PP-2000", 53},
            {"M1911", 54},
            {"DAO-12", 55},
            {"Type 88", 56},
            {"M249 SAW", 57},
            {"XM8 LMG", 58},
            {"GOL Sniper Magnum", 59},
            {"M60", 60},
            {"M1 Garand", 61},
            {"M95 Sniper", 62},
            {"XM8 Prototype", 63},
            {"MP 40", 64},
            {"Walther P38", 65},
            {"BAR 1918", 66},
            {"Bren LMG", 67},
            {"AN94", 68},
            {"K98", 69},
            {"G3A3", 70},
            {"AS Val", 71},
            {"M1 Garand Sniper", 72},
            {"M16A2", 73},
            {"No 4", 74},
            {"No 4 Sniper", 75},
            {"Gewerhr 43 ZF4", 76},
            {"Gewerhr 43", 77},
            {"Thompson", 78},
            {"RPT-3", 79},
            {"AC9", 80},
            {"Super 500", 81},
            {"RM68", 82},
            {"MTAR-21", 83},
            {"Mk VI Revolver", 84},
            {"RPK-74M", 85},
            {"XCE BAR", 86},
            {"GEW-46", 87},
            {"BFP.50", 88},
            {"12G Automatic", 89},
            {"Sten", 90},
            {"Melee", 91},
            {"G3", 92},
            {"Panzerschreck", 93},
            {"VHX D3", 94},
            {"G428", 95},
            {"L9CZ", 96}
        };

    }

    public class LevelExperience
    {
        private List<KeyValuePair<int, int>> levelExperience = new List<KeyValuePair<int, int>>()
        {
            new KeyValuePair<int, int>(1, 0),
            new KeyValuePair<int, int>(2, 3000),
            new KeyValuePair<int, int>(3, 9000),
            new KeyValuePair<int, int>(4, 16000),
            new KeyValuePair<int, int>(5, 24000),
            new KeyValuePair<int, int>(6, 33000),
            new KeyValuePair<int, int>(7, 44000),
            new KeyValuePair<int, int>(8, 57000),
            new KeyValuePair<int, int>(9, 72000),

            new KeyValuePair<int, int>(10, 89000),
            new KeyValuePair<int, int>(11, 108000),
            new KeyValuePair<int, int>(12, 129000),
            new KeyValuePair<int, int>(13, 152000),
            new KeyValuePair<int, int>(14, 177500),
            new KeyValuePair<int, int>(15, 203500),
            new KeyValuePair<int, int>(16, 229750),
            new KeyValuePair<int, int>(17, 256750),
            new KeyValuePair<int, int>(18, 284250),
            new KeyValuePair<int, int>(19, 312250),

            new KeyValuePair<int, int>(20, 340750),
            new KeyValuePair<int, int>(21, 369500),
            new KeyValuePair<int, int>(22, 398750),
            new KeyValuePair<int, int>(23, 428500),
            new KeyValuePair<int, int>(24, 458500),
            new KeyValuePair<int, int>(25, 489000),
            new KeyValuePair<int, int>(26, 519750),
            new KeyValuePair<int, int>(27, 551000),
            new KeyValuePair<int, int>(28, 582750),
            new KeyValuePair<int, int>(29, 615000),

            new KeyValuePair<int, int>(30, 647500),
            new KeyValuePair<int, int>(31, 680750),
            new KeyValuePair<int, int>(32, 714250),
            new KeyValuePair<int, int>(33, 748500),
            new KeyValuePair<int, int>(34, 783250),
            new KeyValuePair<int, int>(35, 818500),
            new KeyValuePair<int, int>(36, 854250),
            new KeyValuePair<int, int>(37, 890500),
            new KeyValuePair<int, int>(38, 927500),
            new KeyValuePair<int, int>(39, 965000),

            new KeyValuePair<int, int>(40, 1003000),
            new KeyValuePair<int, int>(41, 1041500),
            new KeyValuePair<int, int>(42, 1080500),
            new KeyValuePair<int, int>(43, 1120000),
            new KeyValuePair<int, int>(44, 1159750),
            new KeyValuePair<int, int>(45, 1200250),
            new KeyValuePair<int, int>(46, 1241250),
            new KeyValuePair<int, int>(47, 1282750),
            new KeyValuePair<int, int>(48, 1324750),
            new KeyValuePair<int, int>(49, 1367250),

            new KeyValuePair<int, int>(50, 1410250),
            new KeyValuePair<int, int>(51, 1454000),
            new KeyValuePair<int, int>(52, 1498250),
            new KeyValuePair<int, int>(53, 1543000),
            new KeyValuePair<int, int>(54, 1588500),
            new KeyValuePair<int, int>(55, 1634500),
            new KeyValuePair<int, int>(56, 1684250),
            new KeyValuePair<int, int>(57, 1776250),
            new KeyValuePair<int, int>(58, 1824750),
            new KeyValuePair<int, int>(59, 1874000),

            new KeyValuePair<int, int>(60, 1924250),
            new KeyValuePair<int, int>(61, 1924250),
            new KeyValuePair<int, int>(62, 1976000),
            new KeyValuePair<int, int>(63, 2028500),
            new KeyValuePair<int, int>(64, 2082500),
            new KeyValuePair<int, int>(65, 2137750),
            new KeyValuePair<int, int>(66, 2194000),
            new KeyValuePair<int, int>(67, 2251500),
            new KeyValuePair<int, int>(68, 2310500),
            new KeyValuePair<int, int>(69, 2370500),

            new KeyValuePair<int, int>(70, 2431750),
            new KeyValuePair<int, int>(71, 2495250),
            new KeyValuePair<int, int>(72, 2560500),
            new KeyValuePair<int, int>(73, 2628250),
            new KeyValuePair<int, int>(74, 2698000),
            new KeyValuePair<int, int>(75, 2769750),
            new KeyValuePair<int, int>(76, 2843750),
            new KeyValuePair<int, int>(77, 2920000),
            new KeyValuePair<int, int>(78, 2998500),
            new KeyValuePair<int, int>(79, 3079250),

            new KeyValuePair<int, int>(80, 3162000),
            new KeyValuePair<int, int>(81, 3249250),
            new KeyValuePair<int, int>(82, 3340500),
            new KeyValuePair<int, int>(83, 3436500),
            new KeyValuePair<int, int>(84, 3536500),
            new KeyValuePair<int, int>(85, 3641250),
            new KeyValuePair<int, int>(86, 3750250),
            new KeyValuePair<int, int>(87, 3863750),
            new KeyValuePair<int, int>(88, 3981750),
            new KeyValuePair<int, int>(89, 4104250),

            new KeyValuePair<int, int>(90, 4231500),
            new KeyValuePair<int, int>(91, 4359750),
            new KeyValuePair<int, int>(92, 4489000),
            new KeyValuePair<int, int>(93, 4619500),
            new KeyValuePair<int, int>(94, 4750500),
            new KeyValuePair<int, int>(95, 4882250),
            new KeyValuePair<int, int>(96, 5014500),
            new KeyValuePair<int, int>(97, 5147750),
            new KeyValuePair<int, int>(98, 5281250),
            new KeyValuePair<int, int>(99, 5415750),

             new KeyValuePair<int, int>(100, 5550250),
        };

        public List<KeyValuePair<int, decimal>> GetLevel(int experience)
        {
            var sortedLevels = levelExperience.OrderBy(x => x.Value).ToList();
            List<KeyValuePair<int, decimal>> res = new List<KeyValuePair<int, decimal>>();
            if (experience <= 5415750)
            {
                int left = 0;
                int right = sortedLevels.Count - 1;
                while (left < right)
                {
                    int mid = left + (right - left + 1) / 2;
                    if (sortedLevels[mid].Value <= experience)
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                int level = sortedLevels[left].Key;
                int xPleft = 0;
                decimal percent = 0.0m;
                if (level == 1)
                {
                    xPleft = sortedLevels[left + 1].Value - experience;
                    percent = Math.Round((decimal)experience / (sortedLevels[left + 1].Value), 2);
                }
                else
                {
                    xPleft = experience - sortedLevels[left].Value;
                    percent = Math.Round((decimal)xPleft / (sortedLevels[left].Value - sortedLevels[left - 1].Value) * 100.0m, 2);
                }

                res.Add(new KeyValuePair<int, decimal>(level, percent));
                return res;
            }
            else
            {
                int level = experience / 165000;
                int xPleft = 175000 - (experience - level * 165000);
                decimal percent = Math.Round((decimal)xPleft / 165000 * 100.0m, 2);
                res.Add(new KeyValuePair<int, decimal>(level, percent));
                return res;
            }
        }
    }

}