using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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

        public static readonly Dictionary<string, int> VehicleNamesToIds = new Dictionary<string, int>
        {
            {"MD540 Nightbird", 1},
            {"F-35E Panther", 2},
            {"M5C Bolte", 3},
            {"AH-64GX Apache Warchief", 4},
            {"MV-38 Condor", 5},
            {"EBAA Wildcat", 6},
            {"M1A5", 7},
            {"RAH-68 Huron", 8},
            {"LATV4 Recon", 9},
            {"AH-6J Little Bird", 10},
            {"LCAA Hovercraft", 11},
            {"EBLC-Ram", 12},
            {"MAV", 13},
            {"EMKV90-TOR", 14},
            {"UH-60", 15},
            {"LAV-AD", 16},
            {"M1A2", 17},
            {"M1114", 18},
            {"M1161 ITV", 19},
            {"LAV-25", 20},
            {"AH-64 Apache", 21},
            {"AAV-7A1 AMTRAC", 22},
            {"M3A3 Bradley", 23},
            {"M4 Sherman", 24},
            {"Willys MB", 25},
            {"M10 Wolverine", 26},
            {"Spitfire", 27},
            {"B-17 Bomber", 28},
            {"M3 Halftrack", 29},
            {"F/A-18", 30},
            {"A-10 Warthog", 31},
            {"SU-57 FELON", 32},
            {"Mi-240 Super Hind", 33},
            {"YG-99 Hannibal", 34},
            {"Ju-87 Stuka", 35},
            {"Bf 109", 36},
            {"BMP-2", 37},
            {"Su-35BM", 38},
            {"Tiger I", 39},
            {"VDV Buggy", 40},
            {"Sd. Kfz 251 Halftrack", 41},
            {"Kubelwagen", 42},
            {"9K22 Tunguska-M", 43},
            {"T-90", 44},
            {"3937 Vodnik", 45},
            {"Z-11W", 46},
            {"Mi-28 Havoc", 47},
            {"Panzer IV", 48},
            {"KA-520 Super Hokum", 49},
            {"T28", 50},
            {"CAV-BRAWLER", 51},
            {"Su-25TM Frogfoot", 52},
            {"Mi-24 Hind", 53},
            {"BMD-3", 54},
            {"YUV-2 Pondhawk", 55}
        };

        public static readonly Dictionary<string, int> GadgetNamesToIds = new Dictionary<string, int>
        {
            {"C5 Explosive [Kingston]", 1},
            {"SOB-8 Ballistic Shield", 2},
            {"Carl Gustaf M5", 3},
            {"Frag Grenade", 4},
            {"Anti Armor", 5},
            {"Scatter Grenade", 6},
            {"Repair Tool", 7},
            {"SG-36 Sentry Gun", 8},
            {"EMP Grenade", 9},
            {"Anti-Tank Grenade", 10},
            {"Mini Grenade", 11},
            {"Ammo Box BF3 (Portal)", 12},
            {"Ammo Box BC2 (Portal)", 13},
            {"Grappling Hook", 14},
            {"Cyber Warfare Suite (Signal Hacker)", 15},
            {"Medkit BF3 (Portal)", 16},
            {"Medkit BF1942 (Portal)", 17},
            {"Medkit BF2 (Portal)", 18},
            {"Motion Sensor (Portal)", 19},
            {"OV-P Recon Drone", 20},
            {"Repair Tool BF3 (Portal)", 21},
            {"Repair Tool BF1942 (Portal)", 22},
            {"Repair Tool BC2 (Portal)", 23},
            {"S21 Syrette Pistol", 24},
            {"T-UGS (Portal)", 25},
            {"Ammo Crate", 26},
            {"IBA Armor Plate", 27},
            {"C4 [Portal]", 28},
            {"M18 Claymore", 29},
            {"MAV", 30},
            {"Defibrillator", 31},
            {"Defibrillator (BC2)", 32},
            {"Defibrillator (BF3)", 33},
            {"FGM-148 Javelin", 34},
            {"Medical Crate", 35},
            {"Med-Pen (Self-heal)", 36},
            {"AT Mine [Kingston]", 37},
            {"Mortar Strike", 38},
            {"Insertion Beacon (Spawn) (Portal)", 39},
            {"RPG-7", 40},
            {"SMAW", 41},
            {"ExpPack", 42},
            {"Concussion Grenade", 43},
            {"Incendiary Grenade", 44},
            {"Smoke Grenade", 45},
            {"Prox Sensor (Motion)", 46},
            {"Throwing Knife", 47},
            {"Smoke Grenade Launcher", 48},
            {"Lindmine", 49},
            {"XM370A", 50},
            {"FXM-33 AA Missile", 51},
            {"Smoke Grenade Launchers", 52},
            {"M136 AT4", 53},
            {"G-84 TGM", 54},
            {"Bazooka", 55},
            {"SA-18 Igla", 56},
            {"Binoculars BF1942", 57},
            {"Mounted Vulcan", 58},
            {"RPG-7v2", 59},
            {"SPH Explosive Launcher", 60},
            {"Spring Grenade", 61},
            {"EOD Bot - BF3", 62},
            {"Stick Grenade", 63}
        };

        public static readonly Dictionary<string, int> RibbonToIds = new Dictionary<string, int> {
            {"Total", 1},
            {"Squad", 2},
            {"Combat", 3},
            {"Intel", 4},
            {"Objective", 5},
            {"Support", 6},
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

    public class UsernameValidation : ValidationAttribute {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string message = value.ToString();
                if (Regex.IsMatch(message, @"[!@#$%^&*(),.?""':{}|<>]"))
                {
                    return new ValidationResult("Invalid user name! Only letters and numbers are allowed.");
                }
            }
            else {
                return new ValidationResult("UserName Required");
            }

            return ValidationResult.Success;
        }
    }

    public class PasswordValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string message = value.ToString();
                if (message.Length < 6)
                {
                    return new ValidationResult("The Length of Password must over six");
                }
            }
            else
            {
                return new ValidationResult("Password Required");
            }

            return ValidationResult.Success;
        }
    }

    public class EmailValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();

                if (!IsValidEmail(email))
                {
                    return new ValidationResult(ErrorMessage ?? "Invalid email address format", new[] { validationContext.MemberName });
                }
            }
            else {
                new ValidationResult("Email Address Required");
            }

            return ValidationResult.Success;
        }

        private bool IsValidEmail(string email)
        {
            const string emailRegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailRegexPattern);
        }
    }
}