using GAMEDATAHUB.Models;
using GAMEDATAHUB.Models.BF2042Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GAMEDATAHUB.DbScripts;
namespace GAMEDATAHUB.Repository
{
    public class Repository
    {
        private MemoryCache cache = MemoryCache.Default;

        public async Task<OverviewModel> HeroInfoGet(string name, string platform)
        {
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            OverviewModel overView = new OverviewModel();
            overView.PlatForm = platform;
            if (cache.Contains(name))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(name);
            }
            else
            {
                string apiUrl = $"https://api.gametools.network/bf2042/stats/?raw=false&format_values=true&name={name}&platform={platform}&skip_battlelog=false";
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            heroInfoModel = JsonConvert.DeserializeObject<HeroInfoModel>(responseBody);
                            cache.Add(name, heroInfoModel, DateTimeOffset.UtcNow.AddMinutes(360));
                            heroInfoModel.Vehicles.RemoveAll(vehicle =>
                                vehicle.VehicleName == "RHIB - BF3" ||
                                vehicle.VehicleName == "Quadbike - BC2" ||
                                vehicle.VehicleName == "KORD HMG" ||
                                vehicle.VehicleName == "4x4 Utility" ||
                                vehicle.VehicleName == "9M133 Kornet" ||
                                vehicle.VehicleName == "Tuk-Tuk" ||
                                vehicle.VehicleName == "M220 TOW Launcher" ||
                                vehicle.VehicleName == "Polaris RZR" ||
                                vehicle.VehicleName == "Polaris Sportsman" ||
                                vehicle.VehicleName == "UAV-1" ||
                                vehicle.VehicleName == "Flak 38" ||
                                vehicle.VehicleName == "HMG" ||
                                vehicle.VehicleName == "Centurion C-RAM" ||
                                vehicle.VehicleName == "Polaris RZR" ||
                                vehicle.VehicleName == "Polaris RZR" ||
                                vehicle.VehicleName == "Polaris RZR");

                            heroInfoModel.Gadgets.RemoveAll(gadget =>
                                gadget.GadgetName == "Crate" ||
                                gadget.GadgetName == "Pouch" ||
                                gadget.GadgetName == "Panzerschreck" ||
                                gadget.GadgetName == "Insertion Beacon (Spawn)" ||
                                gadget.GadgetName == "BF1942 Grenade" ||
                                gadget.GadgetName == "BC2 Grenade" ||
                                gadget.GadgetName == "BF3 Grenade" ||
                                gadget.GadgetName == "Call In Tablet" ||
                                gadget.GadgetName == "Intel Scanner" ||
                                gadget.GadgetName == "AT-Mine"
                                );
                            heroInfoModel.PlatForm = platform;
                        }
                        else
                        {
                            overView.isValid = false;
                            System.Diagnostics.Trace.TraceError(response.StatusCode.ToString());
                            Console.WriteLine($"HTTP Request Failed，Code: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Message: {ex.Message}");
                    }
                }
            }

            if (overView.isValid)
            {
                overView = OverviewDataGenerate(heroInfoModel, overView);
                #region Hero

                GameDataHubEntity dbContext = new GameDataHubEntity();
                Hero hero = new Hero();
                hero = (from s in dbContext.Hero
                        where s.UserID == heroInfoModel.UserId
                        select s).FirstOrDefault();
                if (hero == null)
                {
                    hero = new Hero();
                    hero.UserID = heroInfoModel.UserId ?? "";
                    hero.Avatar = heroInfoModel.Avatar ?? "";
                    hero.UserName = heroInfoModel.UserName ?? "";
                    hero.Id = heroInfoModel.Id ?? "";
                    hero.PlatForm = heroInfoModel.PlatForm ?? "";
                    dbContext.Hero.Add(hero);
                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                Console.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                    }
                }
                else
                {
                    if (hero.UserID != heroInfoModel.UserId && heroInfoModel.UserId != "")
                    {
                        hero.UserID = heroInfoModel.UserId;
                    }
                    if (hero.Avatar != heroInfoModel.Avatar && heroInfoModel.Avatar != "")
                    {
                        hero.Avatar = heroInfoModel.Avatar;
                    }
                    if (hero.UserName != heroInfoModel.UserName && heroInfoModel.UserName != "")
                    {
                        hero.UserName = heroInfoModel.UserName;
                    }
                    if (hero.Id != heroInfoModel.Id && heroInfoModel.Id != "")
                    {
                        hero.Id = heroInfoModel.Id;
                    }
                    if (hero.PlatForm != heroInfoModel.PlatForm && heroInfoModel.PlatForm != "")
                    {
                        hero.PlatForm = heroInfoModel.PlatForm;
                    }
                    dbContext.SaveChanges();
                }
                #endregion Hero
            }

            return overView;
        }

        public void dbtest()
        {

        }
        public OverviewModel OverviewInfoGet(string name, string platform)
        {
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            heroInfoModel.PlatForm = platform;
            OverviewModel overView = new OverviewModel();
            overView.PlatForm = platform;
            if (cache.Contains(name))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(name);
            }
            overView = OverviewDataGenerate(heroInfoModel, overView);
            return overView;
        }

        public OverviewModel OverviewDataGenerate(HeroInfoModel heroInfoModel, OverviewModel overView)
        {
            ResponseModel error = new ResponseModel();

            #region show OverView Date First

            overView.UserName = heroInfoModel.UserName;
            overView.Avatar = heroInfoModel.Avatar;
            overView.MatchesPlayed = heroInfoModel.MatchesPlayed;
            overView.DamagePerMinute = heroInfoModel.DamagePerMinute;
            overView.KillDeath = heroInfoModel.KillDeath;
            overView.HeadShotRate = heroInfoModel.HeadShotRate;
            overView.WinPercent = heroInfoModel.WinPercent;
            overView.HumanKD = Math.Round(heroInfoModel.KillDeath * heroInfoModel.HumanPrecentageD, 2);
            overView.Kills = heroInfoModel.Kills;
            overView.Deaths = heroInfoModel.Deaths;
            overView.KillAssists = heroInfoModel.KillAssists;
            overView.KillsPerMinute = heroInfoModel.KillsPerMinute;
            overView.KillsPerMatch = heroInfoModel.KillsPerMatch;
            overView.Wins = heroInfoModel.Wins;
            overView.Loses = heroInfoModel.Loses;
            overView.Damage = heroInfoModel.Damage;
            overView.DamagePerMatch = heroInfoModel.DamagePerMatch;
            overView.VehiclesDestroyed = heroInfoModel.VehiclesDestroyed;

            overView.MultiKills = heroInfoModel.DividedKills.MultiKills;
            overView.HeadShotAmount = heroInfoModel.HeadShotAmount;
            overView.RoadKills = heroInfoModel.DividedKills.Roadkills;
            overView.MeleeKills = heroInfoModel.DividedKills.Melee;
            overView.VechileKills = heroInfoModel.DividedKills.Vehicle;
            overView.GrenadesKills = heroInfoModel.DividedKills.Grenades;
            overView.HipfireKills = heroInfoModel.DividedKills.Hipfire;
            overView.AIKills = heroInfoModel.DividedKills.Ai;
            overView.HumanKills = heroInfoModel.DividedKills.Human;
            overView.ScopedKills = heroInfoModel.DividedKills.Ads;

            overView.ObjectTotal = heroInfoModel.Objective.Time.Total / 3600;
            overView.AttackedTotal = heroInfoModel.Objective.Time.Attacked / 3600;
            overView.DefendedTotal = heroInfoModel.Objective.Time.Defended / 3600;
            overView.ArmedObject = heroInfoModel.Objective.Armed;
            overView.DefusedObject = heroInfoModel.Objective.Defused;
            overView.DestroyedObject = heroInfoModel.Objective.Destroyed;
            overView.CapturedObject = heroInfoModel.Objective.Captured;
            overView.NeutralizedObject = heroInfoModel.Objective.Neutralized;
            overView.AttackedSector = heroInfoModel.Sector.captured;
            overView.DefendedSector = heroInfoModel.Sector.defended;
            overView.XP = heroInfoModel.XP[0].Total;

            if (!string.IsNullOrEmpty(heroInfoModel.TimePlayed))
            {
                Regex regex = new Regex(@"\d+");
                MatchCollection matches = regex.Matches(heroInfoModel.TimePlayed);
                if (matches.Count > 0)
                {
                    int.TryParse(matches[0].Value, out int day);
                    int.TryParse(matches[1].Value, out int hours);
                    overView.PlayedTime = day * 24 + hours;
                }
            }
            else
            {
                overView.PlayedTime = 0;
            }

            var topThreeWeapons = heroInfoModel.Weapons
                .OrderByDescending(w => w.Kills)
                .Take(3)
                .ToList();
            foreach (var weapon in topThreeWeapons)
            {
                WeapoinOverView weapoinOverView = new WeapoinOverView();
                weapoinOverView.Type = weapon.Type;
                weapoinOverView.Name = weapon.WeaponName;
                weapoinOverView.Kills = weapon.Kills;
                weapoinOverView.HeadShotRate = weapon.Headshots;
                overView.WeapoinOverViews.Add(weapoinOverView);
            }

            var topThreeVehciles = heroInfoModel.Vehicles
                .OrderByDescending(w => w.Kills)
                .Take(3)
                .ToList();
            foreach (var vehcile in topThreeVehciles)
            {
                VehiclesOverView vehiclesOverView = new VehiclesOverView();
                vehiclesOverView.Type = vehcile.Type;
                vehiclesOverView.Name = vehcile.VehicleName;
                vehiclesOverView.Kills = vehcile.Kills;
                vehiclesOverView.DPM = vehcile.DPM;
                overView.VehiclesOverViews.Add(vehiclesOverView);
            }

            var topThreeSpecialists = heroInfoModel.Classes
                .OrderByDescending(w => w.Kills)
                .Take(3)
                .ToList();

            foreach (var specialist in topThreeSpecialists)
            {
                SpecialistsOverView specialistsOverView = new SpecialistsOverView();
                specialistsOverView.Name = specialist.CharacterName;
                specialistsOverView.AvatarImage = specialist.AvatarImages.Us;
                specialistsOverView.Playtime = specialist.SecondsPlayed / 3600;
                specialistsOverView.Kills = specialist.Kills;
                specialistsOverView.KD = specialist.KillDeath;
                specialistsOverView.KPM = specialist.KPM;
                overView.SpecialistsOverViews.Add(specialistsOverView);
            }

            #endregion show OverView Date First

            LevelExperience levelExperience = new LevelExperience();
            List<KeyValuePair<int, decimal>> levelInfo = levelExperience.GetLevel(overView.XP);
            overView.Level = levelInfo[0].Key;
            overView.progess = levelInfo[0].Value;

            return overView;
        }

        public MapModeView MapsInfoGet(string HeroName, string PlatForm)
        {
            MapModeView mapModeView = new MapModeView();
            ResponseModel error = new ResponseModel();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: read from database
            }
            mapModeView.MaxWins = heroInfoModel.Maps.Max(m => m.Wins);
            mapModeView.MaxWinPercent = heroInfoModel.Maps.Max(m => m.WinPercentD);
            mapModeView.MaxLosses = heroInfoModel.Maps.Max(m => m.Losses);
            mapModeView.MaxTime = heroInfoModel.Maps.Max(m => m.HoursPlayed);
            mapModeView.MaxWinPercent = heroInfoModel.Maps.Max(m => m.WinPercentD);
            mapModeView.UserName = heroInfoModel.UserName;
            mapModeView.Avatar = heroInfoModel.Avatar;
            mapModeView.PlatForm = heroInfoModel.PlatForm;
            heroInfoModel.Maps = heroInfoModel.Maps.OrderByDescending(m => m.Wins).ToList();
            mapModeView.Maps = heroInfoModel.Maps;

            return mapModeView;
        }

        public MapModeView MapsInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            MapModeView mapModeView = new MapModeView();
            ResponseModel error = new ResponseModel();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: read from database
            }
            mapModeView.MaxWins = heroInfoModel.Maps.Max(m => m.Wins);
            mapModeView.MaxWinPercent = heroInfoModel.Maps.Max(m => m.WinPercentD);
            mapModeView.MaxLosses = heroInfoModel.Maps.Max(m => m.Losses);
            mapModeView.MaxTime = heroInfoModel.Maps.Max(m => m.HoursPlayed);
            mapModeView.MaxMatch = heroInfoModel.Maps.Max(m => m.Matches);
            mapModeView.UserName = heroInfoModel.UserName;
            mapModeView.Avatar = heroInfoModel.Avatar;
            mapModeView.PlatForm = heroInfoModel.PlatForm;

            if (HeaderName == Utils.HeaderWin)
            {
                if (SortMethod == "Asce")
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderBy(w => w.Wins).ToList();
                }
                else
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderByDescending(w => w.Wins).ToList();
                }
            }

            if (HeaderName == Utils.HeaderWinPercent)
            {
                if (SortMethod == "Asce")
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderBy(w => w.WinPercentD).ToList();
                }
                else
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderByDescending(w => w.WinPercentD).ToList();
                }
            }

            if (HeaderName == Utils.HeaderLosses)
            {
                if (SortMethod == "Asce")
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderBy(w => w.Losses).ToList();
                }
                else
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderByDescending(w => w.Losses).ToList();
                }
            }

            if (HeaderName == Utils.HeaderMatches)
            {
                if (SortMethod == "Asce")
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderBy(w => w.Matches).ToList();
                }
                else
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderByDescending(w => w.Matches).ToList();
                }
            }

            if (HeaderName == Utils.HeaderPlayTime)
            {
                if (SortMethod == "Asce")
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderBy(w => w.SecondsPlayed).ToList();
                }
                else
                {
                    heroInfoModel.Maps = heroInfoModel.Maps.OrderByDescending(w => w.SecondsPlayed).ToList();
                }
            }

            mapModeView.Maps = heroInfoModel.Maps;

            return mapModeView;
        }

        public GameModeView GameModeInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            GameModeView gameModeView = new GameModeView();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            gameModeView.MaxWins = heroInfoModel.Gamemodes.Max(m => m.Wins);
            gameModeView.MaxKills = heroInfoModel.Gamemodes.Max(m => m.Kills);
            gameModeView.MaxKPM = heroInfoModel.Gamemodes.Max(m => m.KPM);
            gameModeView.MaxTime = heroInfoModel.Gamemodes.Max(m => m.HoursPlayed);
            gameModeView.MaxWinPercent = heroInfoModel.Gamemodes.Max(m => m.WinPercentD);

            if (HeaderName == Utils.HeaderWin)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.Wins).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.Wins).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKill)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.Kills).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.Kills).ToList();
                }
            }

            if (HeaderName == Utils.HeaderWinPercent)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.WinPercentD).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.WinPercentD).ToList();
                }
            }

            if (HeaderName == Utils.HeaderPlayTime)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.SecondsPlayed).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.SecondsPlayed).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.KPM).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.KPM).ToList();
                }
            }

            if (HeaderName == Utils.HeaderGameMode)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.GamemodeName).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.GamemodeName).ToList();
                }
            }
            gameModeView.GameModeViews = heroInfoModel.Gamemodes;
            return gameModeView;
        }

        public GameModeView GameModeInfoGet(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            GameModeView gameModeView = new GameModeView();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            gameModeView.MaxWins = heroInfoModel.Gamemodes.Max(m => m.Wins);
            gameModeView.MaxKills = heroInfoModel.Gamemodes.Max(m => m.Kills);
            gameModeView.MaxKPM = heroInfoModel.Gamemodes.Max(m => m.KPM);
            gameModeView.MaxTime = heroInfoModel.Gamemodes.Max(m => m.HoursPlayed);
            gameModeView.MaxWinPercent = heroInfoModel.Gamemodes.Max(m => m.WinPercentD);
            gameModeView.UserName = heroInfoModel.UserName;
            gameModeView.Avatar = heroInfoModel.Avatar;
            gameModeView.PlatForm = heroInfoModel.PlatForm;

            if (HeaderName == Utils.HeaderWin)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.Wins).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.Wins).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKill)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.Kills).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.Kills).ToList();
                }
            }

            if (HeaderName == Utils.HeaderWinPercent)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.WinPercentD).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.WinPercentD).ToList();
                }
            }

            if (HeaderName == Utils.HeaderPlayTime)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.SecondsPlayed).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.SecondsPlayed).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.KPM).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.KPM).ToList();
                }
            }

            if (HeaderName == Utils.HeaderGameMode)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderBy(w => w.GamemodeName).ToList();
                }
                else
                {
                    heroInfoModel.Gamemodes = heroInfoModel.Gamemodes.OrderByDescending(w => w.GamemodeName).ToList();
                }
            }
            gameModeView.GameModeViews = heroInfoModel.Gamemodes;
            return gameModeView;
        }

        public SpecialistModelView SpecialistInfoGet(string HeroName, string PlatForm, string SortMethod, string HeaderName)
        {
            SpecialistModelView specialistModelView = new SpecialistModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            for (int i = 0; i < heroInfoModel.Classes.Count; i++)
            {
                heroInfoModel.Classes[i].HoursPlayed = heroInfoModel.Classes[i].SecondsPlayed / 3600;
            }

            specialistModelView.MaxKD = heroInfoModel.Classes.Max(m => m.KillDeath);
            specialistModelView.MaxKills = heroInfoModel.Classes.Max(m => m.Kills);
            specialistModelView.MaxKPM = heroInfoModel.Classes.Max(m => m.KPM);
            specialistModelView.MaxTime = heroInfoModel.Classes.Max(m => m.HoursPlayed);
            specialistModelView.UserName = heroInfoModel.UserName;
            specialistModelView.Avatar = heroInfoModel.Avatar;
            specialistModelView.PlatForm = heroInfoModel.PlatForm;

            heroInfoModel.Classes = heroInfoModel.Classes.OrderByDescending(w => w.Kills).ToList();

            specialistModelView.Specialists = heroInfoModel.Classes;

            return specialistModelView;
        }

        public SpecialistModelView SpecialistInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            SpecialistModelView specialistModelView = new SpecialistModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            for (int i = 0; i < heroInfoModel.Classes.Count; i++)
            {
                heroInfoModel.Classes[i].HoursPlayed = heroInfoModel.Classes[i].SecondsPlayed / 3600;
            }

            specialistModelView.MaxKD = heroInfoModel.Classes.Max(m => m.KillDeath);
            specialistModelView.MaxKills = heroInfoModel.Classes.Max(m => m.Kills);
            specialistModelView.MaxKPM = heroInfoModel.Classes.Max(m => m.KPM);
            specialistModelView.MaxTime = heroInfoModel.Classes.Max(m => m.HoursPlayed);
            specialistModelView.UserName = heroInfoModel.UserName;
            specialistModelView.Avatar = heroInfoModel.Avatar;
            specialistModelView.PlatForm = heroInfoModel.PlatForm;

            if (HeaderName == Utils.HeaderKill)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderBy(w => w.Kills).ToList();
                }
                else
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderByDescending(w => w.Kills).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKD)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderBy(w => w.KillDeath).ToList();
                }
                else
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderByDescending(w => w.KillDeath).ToList();
                }
            }

            if (HeaderName == Utils.HeaderPlayTime)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderBy(w => w.SecondsPlayed).ToList();
                }
                else
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderByDescending(w => w.SecondsPlayed).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderBy(w => w.KPM).ToList();
                }
                else
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderByDescending(w => w.KPM).ToList();
                }
            }

            if (HeaderName == Utils.HeaderSpecialist)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderBy(w => w.CharacterName).ToList();
                }
                else
                {
                    heroInfoModel.Classes = heroInfoModel.Classes.OrderByDescending(w => w.CharacterName).ToList();
                }
            }

            specialistModelView.Specialists = heroInfoModel.Classes;

            return specialistModelView;
        }

        public WeaponModelView WeaponInfoGet(string HeroName, string PlatForm, string SortMethod, string HeaderName)
        {
            WeaponModelView weaponModelView = new WeaponModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            weaponModelView.MaxDPM = heroInfoModel.Weapons.Max(m => m.DamagePerMinute);
            weaponModelView.MaxKills = heroInfoModel.Weapons.Max(m => m.Kills);
            weaponModelView.MaxKPM = heroInfoModel.Weapons.Max(m => m.KillsPerMinute);
            weaponModelView.MaxHS = heroInfoModel.Weapons.Max(m => m.HeadshotsD);
            weaponModelView.MaxAccuracy = heroInfoModel.Weapons.Max(m => m.AccuracyD);
            weaponModelView.UserName = heroInfoModel.UserName;
            weaponModelView.Avatar = heroInfoModel.Avatar;
            weaponModelView.PlatForm = heroInfoModel.PlatForm;

            heroInfoModel.Weapons = heroInfoModel.Weapons.OrderByDescending(w => w.Kills).ToList();

            weaponModelView.Weapons = heroInfoModel.Weapons;

            return weaponModelView;
        }

        public WeaponModelView WeaponInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            WeaponModelView weaponModelView = new WeaponModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            weaponModelView.MaxDPM = heroInfoModel.Weapons.Max(m => m.DamagePerMinute);
            weaponModelView.MaxKills = heroInfoModel.Weapons.Max(m => m.Kills);
            weaponModelView.MaxKPM = heroInfoModel.Weapons.Max(m => m.KillsPerMinute);
            weaponModelView.MaxHS = heroInfoModel.Weapons.Max(m => m.HeadshotsD);
            weaponModelView.MaxAccuracy = heroInfoModel.Weapons.Max(m => m.AccuracyD);
            weaponModelView.UserName = heroInfoModel.UserName;
            weaponModelView.Avatar = heroInfoModel.Avatar;
            weaponModelView.PlatForm = heroInfoModel.PlatForm;

            if (HeaderName == Utils.HeaderKill)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderBy(w => w.Kills).ToList();
                }
                else
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderByDescending(w => w.Kills).ToList();
                }
            }

            if (HeaderName == Utils.HeaderDPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderBy(w => w.DamagePerMinute).ToList();
                }
                else
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderByDescending(w => w.DamagePerMinute).ToList();
                }
            }

            if (HeaderName == Utils.HeaderAccuracy)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderBy(w => w.AccuracyD).ToList();
                }
                else
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderByDescending(w => w.AccuracyD).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderBy(w => w.KillsPerMinute).ToList();
                }
                else
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderByDescending(w => w.KillsPerMinute).ToList();
                }
            }

            if (HeaderName == Utils.HeaderHeadShot)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderBy(w => w.HeadshotsD).ToList();
                }
                else
                {
                    heroInfoModel.Weapons = heroInfoModel.Weapons.OrderByDescending(w => w.HeadshotsD).ToList();
                }
            }

            weaponModelView.Weapons = heroInfoModel.Weapons;

            return weaponModelView;
        }

        public GadgetModelView GadgetInfoGet(string HeroName, string PlatForm)
        {
            GadgetModelView gadgetModelView = new GadgetModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            gadgetModelView.MaxDPM = heroInfoModel.Gadgets.Max(m => m.DPM);
            gadgetModelView.MaxKills = heroInfoModel.Gadgets.Max(m => m.Kills);
            gadgetModelView.MaxKPM = heroInfoModel.Gadgets.Max(m => m.KPM);
            gadgetModelView.MaxUses = heroInfoModel.Gadgets.Max(m => m.Uses);
            gadgetModelView.UserName = heroInfoModel.UserName;
            gadgetModelView.Avatar = heroInfoModel.Avatar;
            gadgetModelView.PlatForm = heroInfoModel.PlatForm;

            heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderByDescending(w => w.Kills).ToList();

            gadgetModelView.Gadgets = heroInfoModel.Gadgets;

            return gadgetModelView;
        }

        public GadgetModelView GadgetInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            GadgetModelView gadgetModelView = new GadgetModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            gadgetModelView.MaxDPM = heroInfoModel.Gadgets.Max(m => m.DPM);
            gadgetModelView.MaxKills = heroInfoModel.Gadgets.Max(m => m.Kills);
            gadgetModelView.MaxKPM = heroInfoModel.Gadgets.Max(m => m.KPM);
            gadgetModelView.MaxUses = heroInfoModel.Gadgets.Max(m => m.Uses);
            gadgetModelView.UserName = heroInfoModel.UserName;
            gadgetModelView.Avatar = heroInfoModel.Avatar;
            gadgetModelView.PlatForm = heroInfoModel.PlatForm;

            if (HeaderName == Utils.HeaderKill)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderBy(w => w.Kills).ToList();
                }
                else
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderByDescending(w => w.Kills).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderBy(w => w.KPM).ToList();
                }
                else
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderByDescending(w => w.KPM).ToList();
                }
            }

            if (HeaderName == Utils.HeaderDPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderBy(w => w.DPM).ToList();
                }
                else
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderByDescending(w => w.DPM).ToList();
                }
            }

            if (HeaderName == Utils.HeaderUse)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderBy(w => w.Uses).ToList();
                }
                else
                {
                    heroInfoModel.Gadgets = heroInfoModel.Gadgets.OrderByDescending(w => w.Uses).ToList();
                }
            }

            gadgetModelView.Gadgets = heroInfoModel.Gadgets;

            return gadgetModelView;
        }

        public VehicleModelView VehiclesInfoGet(string HeroName, string PlatForm)
        {
            VehicleModelView vehicleModelView = new VehicleModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            vehicleModelView.MaxDamage = heroInfoModel.Vehicles.Max(m => m.Damage);
            vehicleModelView.MaxKills = heroInfoModel.Vehicles.Max(m => m.Kills);
            vehicleModelView.MaxKPM = heroInfoModel.Vehicles.Max(m => m.KillsPerMinute);
            vehicleModelView.MaxTime = heroInfoModel.Vehicles.Max(m => m.HoursPlayed);
            vehicleModelView.UserName = heroInfoModel.UserName;
            vehicleModelView.Avatar = heroInfoModel.Avatar;
            vehicleModelView.PlatForm = heroInfoModel.PlatForm;

            heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderByDescending(w => w.Kills).ToList();

            vehicleModelView.Vehicles = heroInfoModel.Vehicles;

            return vehicleModelView;
        }

        public VehicleModelView VehiclesInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            VehicleModelView vehicleModelView = new VehicleModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ResponseModel error = new ResponseModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            vehicleModelView.MaxDamage = heroInfoModel.Vehicles.Max(m => m.Damage);
            vehicleModelView.MaxKills = heroInfoModel.Vehicles.Max(m => m.Kills);
            vehicleModelView.MaxKPM = heroInfoModel.Vehicles.Max(m => m.KillsPerMinute);
            vehicleModelView.MaxTime = heroInfoModel.Vehicles.Max(m => m.HoursPlayed);
            vehicleModelView.UserName = heroInfoModel.UserName;
            vehicleModelView.Avatar = heroInfoModel.Avatar;
            vehicleModelView.PlatForm = heroInfoModel.PlatForm;

            if (HeaderName == Utils.HeaderKill)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderBy(w => w.Kills).ToList();
                }
                else
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderByDescending(w => w.Kills).ToList();
                }
            }

            if (HeaderName == Utils.HeaderDamage)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderBy(w => w.Damage).ToList();
                }
                else
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderByDescending(w => w.Damage).ToList();
                }
            }

            if (HeaderName == Utils.HeaderKPM)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderBy(w => w.KillsPerMinute).ToList();
                }
                else
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderByDescending(w => w.KillsPerMinute).ToList();
                }
            }

            if (HeaderName == Utils.HeaderPlayTime)
            {
                if (SortMethod == Utils.AsceMethod)
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderBy(w => w.HoursPlayed).ToList();
                }
                else
                {
                    heroInfoModel.Vehicles = heroInfoModel.Vehicles.OrderByDescending(w => w.HoursPlayed).ToList();
                }
            }

            vehicleModelView.Vehicles = heroInfoModel.Vehicles;

            return vehicleModelView;
        }

        public ResponseModel StoreDataAsync(string HeroName)
        {
            ResponseModel response = new ResponseModel();
            HeroInfoModel heroInfoModel = new HeroInfoModel();

            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
                GameDataHubEntity dbContext = new GameDataHubEntity();
                Hero hero = (from s in dbContext.Hero
                             where s.UserName == HeroName
                             select s).FirstOrDefault();

                if (hero != null)
                {
                    HeroOverView heroOverView = (from s in dbContext.HeroOverView
                                                 where s.HeroID == hero.HeroID
                                                 select s).FirstOrDefault();

                    #region heroOverView

                    if (heroOverView == null)
                    {
                        heroOverView = new HeroOverView
                        {
                            HeroID = hero.HeroID,
                            BestClass = heroInfoModel.BestClass,
                            HumanPercentage = heroInfoModel.HumanPrecentageD,
                            Kills = heroInfoModel.Kills,
                            Deaths = heroInfoModel.Deaths,
                            Wins = heroInfoModel.Wins,
                            Losses = heroInfoModel.Loses,
                            KillsPerMinute = heroInfoModel.KillsPerMinute,
                            DamagePerMinute = heroInfoModel.DamagePerMinute,
                            KillsPerMatch = heroInfoModel.KillsPerMatch,
                            DamagePerMatch = heroInfoModel.DamagePerMatch,
                            HeadShots = heroInfoModel.HeadShotAmount,
                            WinPercent = heroInfoModel.WinPercentD,
                            HeadShotrate = heroInfoModel.HeadShotRateD,
                            KillDeath = heroInfoModel.KillDeath,
                            InfantryKillDeath = heroInfoModel.InfantryKillDeath,
                            Damage = heroInfoModel.Damage,
                            TimePlayed = heroInfoModel.TimePlayed,
                            Accuracy = heroInfoModel.AccuracyD,
                            Revives = heroInfoModel.Revives,
                            Heals = heroInfoModel.Heals,
                            Resupplies = heroInfoModel.Resupplies,
                            Repairs = heroInfoModel.Repairs,
                            SquadmateRevive = heroInfoModel.SquadmateRevive,
                            SquadmateRespawn = heroInfoModel.SquadmateRespawn,
                            ThrownThrowables = heroInfoModel.ThrownThrowables,
                            GadgetsDestoyed = heroInfoModel.GadgetsDestoyed,
                            CallIns = heroInfoModel.CallIns,
                            PlayerTakeDowns = heroInfoModel.PlayerTakeDowns,
                            MatchesPlayed = heroInfoModel.MatchesPlayed,
                            SecondsPlayed = heroInfoModel.SecondsPlayed,
                            BestSquad = heroInfoModel.BestSquad,
                            TeammatesSupported = heroInfoModel.TeammatesSupported,
                            SaviorKills = heroInfoModel.SaviorKills,
                            ShotsFired = heroInfoModel.ShotsFired,
                            ShotsHit = heroInfoModel.ShotsHit,
                            KillAssists = heroInfoModel.KillAssists,
                            VehiclesDestroyed = heroInfoModel.VehiclesDestroyed,
                            EnemiesSpotted = heroInfoModel.EnemiesSpotted,
                            Mvp = heroInfoModel.Mvp
                        };
                        dbContext.HeroOverView.Add(heroOverView);
                    }
                    else
                    {
                        if (heroOverView.BestClass != heroInfoModel.BestClass)
                        {
                            heroOverView.BestClass = heroInfoModel.BestClass;
                        }
                        if (heroOverView.HumanPercentage != heroInfoModel.HumanPrecentageD)
                        {
                            heroOverView.HumanPercentage = heroInfoModel.HumanPrecentageD;
                        }
                        if (heroOverView.Kills != heroInfoModel.Kills)
                        {
                            heroOverView.Kills = heroInfoModel.Kills;
                        }
                        if (heroOverView.Deaths != heroInfoModel.Deaths)
                        {
                            heroOverView.Deaths = heroInfoModel.Deaths;
                        }
                        if (heroOverView.Wins != heroInfoModel.Wins)
                        {
                            heroOverView.Wins = heroInfoModel.Wins;
                        }
                        if (heroOverView.Losses != heroInfoModel.Loses)
                        {
                            heroOverView.Losses = heroInfoModel.Loses;
                        }
                        if (heroOverView.KillsPerMinute != heroInfoModel.KillsPerMinute)
                        {
                            heroOverView.KillsPerMinute = heroInfoModel.KillsPerMinute;
                        }
                        if (heroOverView.DamagePerMinute != heroInfoModel.DamagePerMinute)
                        {
                            heroOverView.DamagePerMinute = heroInfoModel.DamagePerMinute;
                        }
                        if (heroOverView.KillsPerMatch != heroInfoModel.KillsPerMatch)
                        {
                            heroOverView.KillsPerMatch = heroInfoModel.KillsPerMatch;
                        }
                        if (heroOverView.DamagePerMatch != heroInfoModel.DamagePerMatch)
                        {
                            heroOverView.DamagePerMatch = heroInfoModel.DamagePerMatch;
                        }
                        if (heroOverView.HeadShots != heroInfoModel.HeadShotAmount)
                        {
                            heroOverView.HeadShots = heroInfoModel.HeadShotAmount;
                        }
                        if (heroOverView.WinPercent != heroInfoModel.WinPercentD)
                        {
                            heroOverView.WinPercent = heroInfoModel.WinPercentD;
                        }
                        if (heroOverView.HeadShotrate != heroInfoModel.HeadShotRateD)
                        {
                            heroOverView.HeadShotrate = heroInfoModel.HeadShotRateD;
                        }
                        if (heroOverView.KillDeath != heroInfoModel.KillDeath)
                        {
                            heroOverView.KillDeath = heroInfoModel.KillDeath;
                        }
                        if (heroOverView.InfantryKillDeath != heroInfoModel.InfantryKillDeath)
                        {
                            heroOverView.InfantryKillDeath = heroInfoModel.InfantryKillDeath;
                        }
                        if (heroOverView.Damage != heroInfoModel.Damage)
                        {
                            heroOverView.Damage = heroInfoModel.Damage;
                        }
                        if (heroOverView.TimePlayed != heroInfoModel.TimePlayed)
                        {
                            heroOverView.TimePlayed = heroInfoModel.TimePlayed;
                        }
                        if (heroOverView.Accuracy != heroInfoModel.AccuracyD)
                        {
                            heroOverView.Accuracy = heroInfoModel.AccuracyD;
                        }
                        if (heroOverView.Revives != heroInfoModel.Revives)
                        {
                            heroOverView.Revives = heroInfoModel.Revives;
                        }
                        if (heroOverView.Heals != heroInfoModel.Heals)
                        {
                            heroOverView.Heals = heroInfoModel.Heals;
                        }
                        if (heroOverView.Resupplies != heroInfoModel.Resupplies)
                        {
                            heroOverView.Resupplies = heroInfoModel.Resupplies;
                        }
                        if (heroOverView.Repairs != heroInfoModel.Repairs)
                        {
                            heroOverView.Repairs = heroInfoModel.Repairs;
                        }
                        if (heroOverView.SquadmateRevive != heroInfoModel.SquadmateRevive)
                        {
                            heroOverView.SquadmateRevive = heroInfoModel.SquadmateRevive;
                        }
                        if (heroOverView.SquadmateRespawn != heroInfoModel.SquadmateRespawn)
                        {
                            heroOverView.SquadmateRespawn = heroInfoModel.SquadmateRespawn;
                        }
                        if (heroOverView.ThrownThrowables != heroInfoModel.ThrownThrowables)
                        {
                            heroOverView.ThrownThrowables = heroInfoModel.ThrownThrowables;
                        }
                        if (heroOverView.GadgetsDestoyed != heroInfoModel.GadgetsDestoyed)
                        {
                            heroOverView.GadgetsDestoyed = heroInfoModel.GadgetsDestoyed;
                        }
                        if (heroOverView.CallIns != heroInfoModel.CallIns)
                        {
                            heroOverView.CallIns = heroInfoModel.CallIns;
                        }
                        if (heroOverView.PlayerTakeDowns != heroInfoModel.PlayerTakeDowns)
                        {
                            heroOverView.PlayerTakeDowns = heroInfoModel.PlayerTakeDowns;
                        }
                        if (heroOverView.MatchesPlayed != heroInfoModel.MatchesPlayed)
                        {
                            heroOverView.MatchesPlayed = heroInfoModel.MatchesPlayed;
                        }
                        if (heroOverView.SecondsPlayed != heroInfoModel.SecondsPlayed)
                        {
                            heroOverView.SecondsPlayed = heroInfoModel.SecondsPlayed;
                        }
                        if (heroOverView.BestSquad != heroInfoModel.BestSquad)
                        {
                            heroOverView.BestSquad = heroInfoModel.BestSquad;
                        }
                        if (heroOverView.TeammatesSupported != heroInfoModel.TeammatesSupported)
                        {
                            heroOverView.TeammatesSupported = heroInfoModel.TeammatesSupported;
                        }
                        if (heroOverView.SaviorKills != heroInfoModel.SaviorKills)
                        {
                            heroOverView.SaviorKills = heroInfoModel.SaviorKills;
                        }
                        if (heroOverView.ShotsFired != heroInfoModel.ShotsFired)
                        {
                            heroOverView.ShotsFired = heroInfoModel.ShotsFired;
                        }
                        if (heroOverView.ShotsHit != heroInfoModel.ShotsHit)
                        {
                            heroOverView.ShotsHit = heroInfoModel.ShotsHit;
                        }
                        if (heroOverView.KillAssists != heroInfoModel.KillAssists)
                        {
                            heroOverView.KillAssists = heroInfoModel.KillAssists;
                        }
                        if (heroOverView.VehiclesDestroyed != heroInfoModel.VehiclesDestroyed)
                        {
                            heroOverView.VehiclesDestroyed = heroInfoModel.VehiclesDestroyed;
                        }
                        if (heroOverView.EnemiesSpotted != heroInfoModel.EnemiesSpotted)
                        {
                            heroOverView.EnemiesSpotted = heroInfoModel.EnemiesSpotted;
                        }
                        if (heroOverView.Mvp != heroInfoModel.Mvp)
                        {
                            heroOverView.Mvp = heroInfoModel.Mvp;
                        }
                    }

                    #endregion heroOverView

                    #region Map

                    List<Map> maps = (from s in dbContext.Map
                                      select s).ToList();
                    if (!maps.Any())
                    {
                        foreach (var map in heroInfoModel.Maps)
                        {
                            Map mapDB = new Map
                            {
                                MapName = !string.IsNullOrEmpty(map.MapName) ? map.MapName : "none",
                                Image = !string.IsNullOrEmpty(map.Image) ? map.Image : "none",
                                Id = !string.IsNullOrEmpty(map.Id) ? map.Id : "none",
                            };
                            dbContext.Map.Add(mapDB);
                        }
                    }

                    List<MapItem> mapItems = (from s in dbContext.MapItem
                                              where s.HeroID == hero.HeroID
                                              orderby s.MapItemId
                                              select s).ToList();
                    if (!mapItems.Any())
                    {
                        foreach (var item in heroInfoModel.Maps)
                        {
                            MapItem mapItem = new MapItem
                            {
                                MapID = MapIdGet(item.MapName),
                                HeroID = hero.HeroID,
                                Wins = item.Wins,
                                Losses = item.Losses,
                                Matches = item.Matches,
                                WinPercent = item.WinPercentD,
                                SecondsPlayed = item.SecondsPlayed
                            };
                            dbContext.MapItem.Add(mapItem);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < mapItems.Count; i++)
                        {
                            if (mapItems[i].Wins != heroInfoModel.Maps[i].Wins)
                            {
                                mapItems[i].Wins = heroInfoModel.Maps[i].Wins;
                            }
                            if (mapItems[i].Losses != heroInfoModel.Maps[i].Losses)
                            {
                                mapItems[i].Losses = heroInfoModel.Maps[i].Losses;
                            }
                            if (mapItems[i].Matches != heroInfoModel.Maps[i].Matches)
                            {
                                mapItems[i].Matches = heroInfoModel.Maps[i].Matches;
                            }
                            if (mapItems[i].WinPercent != heroInfoModel.Maps[i].WinPercentD)
                            {
                                mapItems[i].WinPercent = heroInfoModel.Maps[i].WinPercentD;
                            }
                            if (mapItems[i].SecondsPlayed != heroInfoModel.Maps[i].SecondsPlayed)
                            {
                                mapItems[i].SecondsPlayed = heroInfoModel.Maps[i].SecondsPlayed;
                            }
                        }
                    }

                    #endregion Map

                    #region Mode

                    List<GameMode> gameModes = (from s in dbContext.GameMode
                                                select s).ToList();

                    if (!gameModes.Any())
                    {
                        foreach (var item in heroInfoModel.Gamemodes)
                        {
                            GameMode gameMode = new GameMode
                            {
                                GamemodeName = !string.IsNullOrEmpty(item.GamemodeName) ? item.GamemodeName : "none",
                                Images = !string.IsNullOrEmpty(item.Image) ? item.Image : "none",
                                Id = !string.IsNullOrEmpty(item.Id) ? item.Id : "none"
                            };
                            dbContext.GameMode.Add(gameMode);
                        }
                    }

                    List<GameModeItem> gameModeItems = (from s in dbContext.GameModeItem
                                                        where s.HeroID == hero.HeroID
                                                        orderby s.GameModeID
                                                        select s).ToList();

                    if (!gameModeItems.Any())
                    {
                        foreach (var item in heroInfoModel.Gamemodes)
                        {
                            GameModeItem gameModeItem = new GameModeItem
                            {
                                GameModeID = ModeIdGet(item.GamemodeName),
                                HeroID = hero.HeroID,
                                Kills = item.Kills,
                                Assists = item.Assists,
                                Revives = item.Revives,
                                BestSquad = item.BestSquad,
                                Wins = item.Wins,
                                Losses = item.Losses,
                                Mvp = item.Mvp,
                                Matches = item.Matches,
                                SectorDefend = item.SectorDefend,
                                ObjectivesDisarmed = item.ObjectivesDisarmed,
                                ObjectivesArmed = item.ObjectivesArmed,
                                ObjectivesDestroyed = item.ObjectivesDestroyed,
                                ObjectivesDefended = item.ObjectivesDefended,
                                ObjetiveTime = item.ObjetiveTime,
                                KPM = item.KPM,
                                WinPercent = item.WinPercentD,
                                SecondsPlayed = item.SecondsPlayed
                            };
                            dbContext.GameModeItem.Add(gameModeItem);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < gameModeItems.Count; i++)
                        {
                            if (gameModeItems[i].Kills != heroInfoModel.Gamemodes[i].Kills)
                            {
                                gameModeItems[i].Kills = heroInfoModel.Gamemodes[i].Kills;
                            }
                            if (gameModeItems[i].Assists != heroInfoModel.Gamemodes[i].Assists)
                            {
                                gameModeItems[i].Assists = heroInfoModel.Gamemodes[i].Assists;
                            }
                            if (gameModeItems[i].Revives != heroInfoModel.Gamemodes[i].Revives)
                            {
                                gameModeItems[i].Revives = heroInfoModel.Gamemodes[i].Revives;
                            }
                            if (gameModeItems[i].BestSquad != heroInfoModel.Gamemodes[i].BestSquad)
                            {
                                gameModeItems[i].BestSquad = heroInfoModel.Gamemodes[i].BestSquad;
                            }
                            if (gameModeItems[i].Wins != heroInfoModel.Gamemodes[i].Wins)
                            {
                                gameModeItems[i].Wins = heroInfoModel.Gamemodes[i].Wins;
                            }
                            if (gameModeItems[i].Losses != heroInfoModel.Gamemodes[i].Losses)
                            {
                                gameModeItems[i].Losses = heroInfoModel.Gamemodes[i].Losses;
                            }
                            if (gameModeItems[i].Mvp != heroInfoModel.Gamemodes[i].Mvp)
                            {
                                gameModeItems[i].Mvp = heroInfoModel.Gamemodes[i].Mvp;
                            }
                            if (gameModeItems[i].Matches != heroInfoModel.Gamemodes[i].Matches)
                            {
                                gameModeItems[i].Matches = heroInfoModel.Gamemodes[i].Matches;
                            }
                            if (gameModeItems[i].SectorDefend != heroInfoModel.Gamemodes[i].SectorDefend)
                            {
                                gameModeItems[i].SectorDefend = heroInfoModel.Gamemodes[i].SectorDefend;
                            }
                            if (gameModeItems[i].ObjectivesDisarmed != heroInfoModel.Gamemodes[i].ObjectivesDisarmed)
                            {
                                gameModeItems[i].ObjectivesDisarmed = heroInfoModel.Gamemodes[i].ObjectivesDisarmed;
                            }
                            if (gameModeItems[i].ObjectivesArmed != heroInfoModel.Gamemodes[i].ObjectivesArmed)
                            {
                                gameModeItems[i].ObjectivesArmed = heroInfoModel.Gamemodes[i].ObjectivesArmed;
                            }
                            if (gameModeItems[i].ObjectivesDestroyed != heroInfoModel.Gamemodes[i].ObjectivesDestroyed)
                            {
                                gameModeItems[i].ObjectivesDestroyed = heroInfoModel.Gamemodes[i].ObjectivesDestroyed;
                            }
                            if (gameModeItems[i].ObjectivesDefended != heroInfoModel.Gamemodes[i].ObjectivesDefended)
                            {
                                gameModeItems[i].ObjectivesDefended = heroInfoModel.Gamemodes[i].ObjectivesDefended;
                            }
                            if (gameModeItems[i].ObjetiveTime != heroInfoModel.Gamemodes[i].ObjetiveTime)
                            {
                                gameModeItems[i].ObjetiveTime = heroInfoModel.Gamemodes[i].ObjetiveTime;
                            }
                            if (gameModeItems[i].KPM != heroInfoModel.Gamemodes[i].KPM)
                            {
                                gameModeItems[i].KPM = heroInfoModel.Gamemodes[i].KPM;
                            }
                            if (gameModeItems[i].WinPercent != heroInfoModel.Gamemodes[i].WinPercentD)
                            {
                                gameModeItems[i].WinPercent = heroInfoModel.Gamemodes[i].WinPercentD;
                            }
                            if (gameModeItems[i].SecondsPlayed != heroInfoModel.Gamemodes[i].SecondsPlayed)
                            {
                                gameModeItems[i].SecondsPlayed = heroInfoModel.Gamemodes[i].SecondsPlayed;
                            }
                        }
                    }

                    #endregion Mode

                    #region Specialists

                    List<Specialist> specialists = new List<Specialist>();
                    specialists = (from s in dbContext.Specialist
                                   select s).ToList();
                    if (!specialists.Any())
                    {
                        foreach (var item in heroInfoModel.Classes)
                        {
                            Specialist specialist = new Specialist
                            {
                                ClassName = !string.IsNullOrEmpty(item.ClassName) ? item.ClassName : "none",
                                CharacterName = !string.IsNullOrEmpty(item.CharacterName) ? item.CharacterName : "none",
                                StatName = !string.IsNullOrEmpty(item.StatName) ? item.StatName : "none",
                                Image = !string.IsNullOrEmpty(item.Image) ? item.Image : "none",
                                AvatarImage1 = !string.IsNullOrEmpty(item.AvatarImages.Rus) ? item.AvatarImages.Rus : "none",
                                AvatarImage2 = !string.IsNullOrEmpty(item.AvatarImages.Us) ? item.AvatarImages.Us : "none",
                            };
                            dbContext.Specialist.Add(specialist);
                        }
                    }

                    List<SpecialistItem> specialistItems = new List<SpecialistItem>();
                    specialistItems = (from s in dbContext.SpecialistItem
                                       where s.HeroID == hero.HeroID
                                       orderby s.SpecialistID
                                       select s).ToList();

                    if (!specialistItems.Any())
                    {
                        foreach (var item in heroInfoModel.Classes)
                        {
                            SpecialistItem specialistItem = new SpecialistItem()
                            {
                                SpecialistID = SpecialistIdGet(item.CharacterName),
                                HeroID = hero.HeroID,
                                Kills = item.Kills,
                                Deaths = item.Deaths,
                                KMP = item.KPM,
                                Spawns = item.Spawns,
                                KillDeath = item.KillDeath,
                                Revives = item.Revives,
                                Assists = item.Assists,
                                HazardZoneStreaks = item.HazardZoneStreaks,
                                SecondsPlayed = item.SecondsPlayed
                            };
                            dbContext.SpecialistItem.Add(specialistItem);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < specialistItems.Count; i++)
                        {
                            if (specialistItems[i].Kills != heroInfoModel.Classes[i].Kills)
                            {
                                specialistItems[i].Kills = heroInfoModel.Classes[i].Kills;
                            }
                            if (specialistItems[i].Deaths != heroInfoModel.Classes[i].Deaths)
                            {
                                specialistItems[i].Deaths = heroInfoModel.Classes[i].Deaths;
                            }
                            if (specialistItems[i].KMP != heroInfoModel.Classes[i].KPM)
                            {
                                specialistItems[i].KMP = heroInfoModel.Classes[i].KPM;
                            }
                            if (specialistItems[i].Spawns != heroInfoModel.Classes[i].Spawns)
                            {
                                specialistItems[i].Spawns = heroInfoModel.Classes[i].Spawns;
                            }
                            if (specialistItems[i].KillDeath != heroInfoModel.Classes[i].KillDeath)
                            {
                                specialistItems[i].KillDeath = heroInfoModel.Classes[i].KillDeath;
                            }
                            if (specialistItems[i].Revives != heroInfoModel.Classes[i].Revives)
                            {
                                specialistItems[i].Revives = heroInfoModel.Classes[i].Revives;
                            }
                            if (specialistItems[i].Assists != heroInfoModel.Classes[i].Assists)
                            {
                                specialistItems[i].Assists = heroInfoModel.Classes[i].Assists;
                            }
                            if (specialistItems[i].HazardZoneStreaks != heroInfoModel.Classes[i].HazardZoneStreaks)
                            {
                                specialistItems[i].HazardZoneStreaks = heroInfoModel.Classes[i].HazardZoneStreaks;
                            }
                            if (specialistItems[i].SecondsPlayed != heroInfoModel.Classes[i].SecondsPlayed)
                            {
                                specialistItems[i].SecondsPlayed = heroInfoModel.Classes[i].SecondsPlayed;
                            }
                        }
                    }

                    #endregion Specialists

                    #region Weapon

                    List<Weapon> weapons = new List<Weapon>();
                    weapons = (from s in dbContext.Weapon
                               select s).ToList();
                    if (!weapons.Any())
                    {
                        foreach (var item in heroInfoModel.Weapons)
                        {
                            Weapon weapon = new Weapon
                            {
                                Type = !string.IsNullOrEmpty(item.Type) ? item.Type : "none",
                                WeaponName = !string.IsNullOrEmpty(item.WeaponName) ? item.WeaponName : "none",
                                Image = !string.IsNullOrEmpty(item.Image) ? item.Image : "none",
                                Id = !string.IsNullOrEmpty(item.Id) ? item.Id : "none"
                            };
                                dbContext.Weapon.Add(weapon);
                        }
                    }

                    List<WeaponItem> weaponItems = new List<WeaponItem>();
                    weaponItems = (from s in dbContext.WeaponItem
                                   where s.HeroID == hero.HeroID
                                   orderby s.WeaponID
                                   select s).ToList();
                    if (!weaponItems.Any())
                    {
                        foreach (var item in heroInfoModel.Weapons)
                        {
                            WeaponItem weaponItem = new WeaponItem
                            {
                                WeaponID = WeaponIdGet(item.WeaponName),
                                HeroID = hero.HeroID,
                                Kills = item.Kills,
                                Damage = item.Damage,
                                BodyKills = item.BodyKills,
                                HeadshotKills = item.HeadshotKills,
                                HipfireKills = item.HipfireKills,
                                MultiKills = item.MultiKills,
                                Accuracy = item.AccuracyD,
                                KillsPerMinute = item.KillsPerMinute,
                                DamagePerMinute = item.DamagePerMinute,
                                Headshots = item.HeadshotsD,
                                HitVKills = item.HitVKills,
                                ShotsHit = item.ShotsHit,
                                ShotsFired = item.ShotsFired,
                                Spawns = item.Spawns,
                                TimeEquipped = item.TimeEquipped
                            };
                            dbContext.WeaponItem.Add(weaponItem);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < weaponItems.Count; i++)
                        {
                            if (weaponItems[i].HeroID != hero.HeroID)
                            {
                                weaponItems[i].HeroID = hero.HeroID;
                            }
                            if (weaponItems[i].Kills != heroInfoModel.Weapons[i].Kills)
                            {
                                weaponItems[i].Kills = heroInfoModel.Weapons[i].Kills;
                            }
                            if (weaponItems[i].Damage != heroInfoModel.Weapons[i].Damage)
                            {
                                weaponItems[i].Damage = heroInfoModel.Weapons[i].Damage;
                            }
                            if (weaponItems[i].BodyKills != heroInfoModel.Weapons[i].BodyKills)
                            {
                                weaponItems[i].BodyKills = heroInfoModel.Weapons[i].BodyKills;
                            }
                            if (weaponItems[i].HeadshotKills != heroInfoModel.Weapons[i].HeadshotKills)
                            {
                                weaponItems[i].HeadshotKills = heroInfoModel.Weapons[i].HeadshotKills;
                            }
                            if (weaponItems[i].HipfireKills != heroInfoModel.Weapons[i].HipfireKills)
                            {
                                weaponItems[i].HipfireKills = heroInfoModel.Weapons[i].HipfireKills;
                            }
                            if (weaponItems[i].MultiKills != heroInfoModel.Weapons[i].MultiKills)
                            {
                                weaponItems[i].MultiKills = heroInfoModel.Weapons[i].MultiKills;
                            }
                            if (weaponItems[i].Accuracy != heroInfoModel.Weapons[i].AccuracyD)
                            {
                                weaponItems[i].Accuracy = heroInfoModel.Weapons[i].AccuracyD;
                            }
                            if (weaponItems[i].KillsPerMinute != heroInfoModel.Weapons[i].KillsPerMinute)
                            {
                                weaponItems[i].KillsPerMinute = heroInfoModel.Weapons[i].KillsPerMinute;
                            }
                            if (weaponItems[i].DamagePerMinute != heroInfoModel.Weapons[i].DamagePerMinute)
                            {
                                weaponItems[i].DamagePerMinute = heroInfoModel.Weapons[i].DamagePerMinute;
                            }
                            if (weaponItems[i].Headshots != heroInfoModel.Weapons[i].HeadshotsD)
                            {
                                weaponItems[i].Headshots = heroInfoModel.Weapons[i].HeadshotsD;
                            }
                            if (weaponItems[i].HitVKills != heroInfoModel.Weapons[i].HitVKills)
                            {
                                weaponItems[i].HitVKills = heroInfoModel.Weapons[i].HitVKills;
                            }
                            if (weaponItems[i].ShotsHit != heroInfoModel.Weapons[i].ShotsHit)
                            {
                                weaponItems[i].ShotsHit = heroInfoModel.Weapons[i].ShotsHit;
                            }
                            if (weaponItems[i].ShotsFired != heroInfoModel.Weapons[i].ShotsFired)
                            {
                                weaponItems[i].ShotsFired = heroInfoModel.Weapons[i].ShotsFired;
                            }
                            if (weaponItems[i].Spawns != heroInfoModel.Weapons[i].Spawns)
                            {
                                weaponItems[i].Spawns = heroInfoModel.Weapons[i].Spawns;
                            }
                            if (weaponItems[i].TimeEquipped != heroInfoModel.Weapons[i].TimeEquipped)
                            {
                                weaponItems[i].TimeEquipped = heroInfoModel.Weapons[i].TimeEquipped;
                            }
                        }
                    }

                    #endregion Weapon

                    //#region Vehicle

                    //List<Vehicle> vehicles = new List<Vehicle>();
                    //vehicles = (from s in dbContext.Vehicle
                    //            select s).ToList();
                    //if (!vehicles.Any())
                    //{
                    //    foreach (var item in heroInfoModel.Vehicles)
                    //    {
                    //        Vehicle vehicle = new Vehicle
                    //        {
                    //            Type = item.Type ?? "none",
                    //            VehicleName = item.VehicleName ?? "none",
                    //            Image = item.Image ?? "none",
                    //            ID = item.Id ?? "none"
                    //        };
                    //        dbContext.Vehicle.Add(vehicle);
                    //    }
                    //}

                    //List<VehicleItem> vehicleItems = new List<VehicleItem>();
                    //vehicleItems = (from s in dbContext.VehicleItem
                    //                where s.HeroID == hero.HeroID
                    //                orderby s.VehicleID
                    //                select s).ToList();
                    //if (!vehicleItems.Any())
                    //{
                    //    foreach (var item in heroInfoModel.Vehicles)
                    //    {
                    //        VehicleItem vehicleItem = new VehicleItem
                    //        {
                    //            VehicleID = VehicleIdGet(item.VehicleName),
                    //            HeroID = hero.HeroID,
                    //            Kills = item.Kills,
                    //            Damage = item.Damage,
                    //            Roadkills = item.RoadKills,
                    //            Spawns = item.Spawns,
                    //            DriverAssists = item.DriverAssists,
                    //            PassengerAssists = item.PassengerAssists,
                    //            Multikills = item.MultiKills,
                    //            DistanceTraveled = item.DistanceTraveled,
                    //            KillsPerMinute = item.KillsPerMinute,
                    //            VehiclesDestroyedWith = item.VehiclesDestroyedWith,
                    //            Assists = item.Assists,
                    //            Callins = item.CallIns,
                    //            DamageTo = item.DamageTo,
                    //            Destroyed = item.Destroyed,
                    //            Timeln = item.TimeIn
                    //        };
                    //        dbContext.VehicleItem.Add(vehicleItem);
                    //    }
                    //}
                    //else
                    //{
                    //    for (int i = 0; i < vehicleItems.Count; i++)
                    //    {
                    //        if (vehicleItems[i].Kills != heroInfoModel.Vehicles[i].Kills)
                    //        {
                    //            vehicleItems[i].Kills = heroInfoModel.Vehicles[i].Kills;
                    //        }
                    //        if (vehicleItems[i].Damage != heroInfoModel.Vehicles[i].Damage)
                    //        {
                    //            vehicleItems[i].Damage = heroInfoModel.Vehicles[i].Damage;
                    //        }
                    //        if (vehicleItems[i].Roadkills != heroInfoModel.Vehicles[i].RoadKills)
                    //        {
                    //            vehicleItems[i].Roadkills = heroInfoModel.Vehicles[i].RoadKills;
                    //        }
                    //        if (vehicleItems[i].Spawns != heroInfoModel.Vehicles[i].Spawns)
                    //        {
                    //            vehicleItems[i].Spawns = heroInfoModel.Vehicles[i].Spawns;
                    //        }
                    //        if (vehicleItems[i].DriverAssists != heroInfoModel.Vehicles[i].DriverAssists)
                    //        {
                    //            vehicleItems[i].DriverAssists = heroInfoModel.Vehicles[i].DriverAssists;
                    //        }
                    //        if (vehicleItems[i].PassengerAssists != heroInfoModel.Vehicles[i].PassengerAssists)
                    //        {
                    //            vehicleItems[i].PassengerAssists = heroInfoModel.Vehicles[i].PassengerAssists;
                    //        }
                    //        if (vehicleItems[i].Multikills != heroInfoModel.Vehicles[i].MultiKills)
                    //        {
                    //            vehicleItems[i].Multikills = heroInfoModel.Vehicles[i].MultiKills;
                    //        }
                    //        if (vehicleItems[i].DistanceTraveled != heroInfoModel.Vehicles[i].DistanceTraveled)
                    //        {
                    //            vehicleItems[i].DistanceTraveled = heroInfoModel.Vehicles[i].DistanceTraveled;
                    //        }
                    //        if (vehicleItems[i].KillsPerMinute != heroInfoModel.Vehicles[i].KillsPerMinute)
                    //        {
                    //            vehicleItems[i].KillsPerMinute = heroInfoModel.Vehicles[i].KillsPerMinute;
                    //        }
                    //        if (vehicleItems[i].VehiclesDestroyedWith != heroInfoModel.Vehicles[i].VehiclesDestroyedWith)
                    //        {
                    //            vehicleItems[i].VehiclesDestroyedWith = heroInfoModel.Vehicles[i].VehiclesDestroyedWith;
                    //        }
                    //        if (vehicleItems[i].Assists != heroInfoModel.Vehicles[i].Assists)
                    //        {
                    //            vehicleItems[i].Assists = heroInfoModel.Vehicles[i].Assists;
                    //        }
                    //        if (vehicleItems[i].Callins != heroInfoModel.Vehicles[i].CallIns)
                    //        {
                    //            vehicleItems[i].Callins = heroInfoModel.Vehicles[i].CallIns;
                    //        }
                    //        if (vehicleItems[i].DamageTo != heroInfoModel.Vehicles[i].DamageTo)
                    //        {
                    //            vehicleItems[i].DamageTo = heroInfoModel.Vehicles[i].DamageTo;
                    //        }
                    //        if (vehicleItems[i].Destroyed != heroInfoModel.Vehicles[i].Destroyed)
                    //        {
                    //            vehicleItems[i].Destroyed = heroInfoModel.Vehicles[i].Destroyed;
                    //        }
                    //        if (vehicleItems[i].Timeln != heroInfoModel.Vehicles[i].TimeIn)
                    //        {
                    //            vehicleItems[i].Timeln = heroInfoModel.Vehicles[i].TimeIn;
                    //        }
                    //    }
                    //}

                    //#endregion Vehicle

                    //#region Gadget

                    //List<Gadget> gadgets = new List<Gadget>();
                    //gadgets = (from s in dbContext.Gadget
                    //           select s).ToList();
                    //if (!gadgets.Any())
                    //{
                    //    foreach (var item in heroInfoModel.Gadgets)
                    //    {
                    //        Gadget gadget = new Gadget
                    //        {
                    //            Type = item.Type ?? "none",
                    //            GadgetName = item.GadgetName ?? "none",
                    //            Image = item.Image ?? "none",
                    //            Id = item.Id ?? "none"
                    //        };
                    //        dbContext.Gadget.Add(gadget);
                    //    }
                    //}

                    //List<GadgetItem> gadgetItems = new List<GadgetItem>();
                    //gadgetItems = (from s in dbContext.GadgetItem
                    //               where s.HeroID == hero.HeroID
                    //               orderby s.GadgetID
                    //               select s).ToList();
                    //if (!gadgetItems.Any())
                    //{
                    //    foreach (var item in heroInfoModel.Gadgets)
                    //    {
                    //        GadgetItem gadgetItem = new GadgetItem
                    //        {
                    //            GadgetID = GadgetIdGet(item.GadgetName),
                    //            HeroID = hero.HeroID,
                    //            Kills = item.Kills,
                    //            Spawns = item.Spawns,
                    //            Damage = item.Damage,
                    //            Uses = item.Uses,
                    //            Multikills = item.MultiKills,
                    //            VehiclesDestroyedWith = item.VehiclesDestroyedWith,
                    //            KPM = item.KPM,
                    //            DPM = item.DPM,
                    //            SecondsPlayed = item.SecondsPlayed
                    //        };
                    //        dbContext.GadgetItem.Add(gadgetItem);
                    //    }
                    //}
                    //else
                    //{
                    //    for (int i = 0; i < gadgetItems.Count; i++)
                    //    {
                    //        if (gadgetItems[i].Kills != heroInfoModel.Gadgets[i].Kills)
                    //        {
                    //            gadgetItems[i].Kills = heroInfoModel.Gadgets[i].Kills;
                    //        }
                    //        if (gadgetItems[i].Spawns != heroInfoModel.Gadgets[i].Spawns)
                    //        {
                    //            gadgetItems[i].Spawns = heroInfoModel.Gadgets[i].Spawns;
                    //        }
                    //        if (gadgetItems[i].Damage != heroInfoModel.Gadgets[i].Damage)
                    //        {
                    //            gadgetItems[i].Damage = heroInfoModel.Gadgets[i].Damage;
                    //        }
                    //        if (gadgetItems[i].Uses != heroInfoModel.Gadgets[i].Uses)
                    //        {
                    //            gadgetItems[i].Uses = heroInfoModel.Gadgets[i].Uses;
                    //        }
                    //        if (gadgetItems[i].Multikills != heroInfoModel.Gadgets[i].MultiKills)
                    //        {
                    //            gadgetItems[i].Multikills = heroInfoModel.Gadgets[i].MultiKills;
                    //        }
                    //        if (gadgetItems[i].VehiclesDestroyedWith != heroInfoModel.Gadgets[i].VehiclesDestroyedWith)
                    //        {
                    //            gadgetItems[i].VehiclesDestroyedWith = heroInfoModel.Gadgets[i].VehiclesDestroyedWith;
                    //        }
                    //        if (gadgetItems[i].KPM != heroInfoModel.Gadgets[i].KPM)
                    //        {
                    //            gadgetItems[i].KPM = heroInfoModel.Gadgets[i].KPM;
                    //        }
                    //        if (gadgetItems[i].DPM != heroInfoModel.Gadgets[i].DPM)
                    //        {
                    //            gadgetItems[i].DPM = heroInfoModel.Gadgets[i].DPM;
                    //        }
                    //        if (gadgetItems[i].SecondsPlayed != heroInfoModel.Gadgets[i].SecondsPlayed)
                    //        {
                    //            gadgetItems[i].SecondsPlayed = heroInfoModel.Gadgets[i].SecondsPlayed;
                    //        }
                    //    }
                    //}

                    //#endregion Gadget

                    //#region XP

                    //XP xP = new XP();
                    //xP = (from s in dbContext.XP
                    //      where s.HeroID == hero.HeroID
                    //      select s).FirstOrDefault();

                    //if (xP == null)
                    //{
                    //    xP = new XP
                    //    {
                    //        HeroID = hero.HeroID,
                    //        Total = heroInfoModel.XP[0].Total,
                    //        Performance = heroInfoModel.XP[0].Performance
                    //    };
                    //    dbContext.XP.Add(xP);
                    //}
                    //else
                    //{
                    //    if (xP.Total != heroInfoModel.XP[0].Total)
                    //    {
                    //        xP.Total = heroInfoModel.XP[0].Total;
                    //    }
                    //    if (xP.Performance != heroInfoModel.XP[0].Performance)
                    //    {
                    //        xP.Performance = heroInfoModel.XP[0].Performance;
                    //    }
                    //}

                    //#endregion XP

                    //#region Ribbons

                    //DbScripts.Ribbon ribbon = new DbScripts.Ribbon();
                    //ribbon = (from s in dbContext.Ribbon
                    //          where s.HeroID == hero.HeroID
                    //          orderby s.RibbonID
                    //          select s).FirstOrDefault();
                    //if (ribbon == null)
                    //{
                    //    ribbon = new DbScripts.Ribbon
                    //    {
                    //        HeroID = hero.HeroID,
                    //        Total = heroInfoModel.XP[0].Ribbons.Total,
                    //        Squad = heroInfoModel.XP[0].Ribbons.Squad,
                    //        Combat = heroInfoModel.XP[0].Ribbons.Combat,
                    //        Intel = heroInfoModel.XP[0].Ribbons.Intel,
                    //        Objective = heroInfoModel.XP[0].Ribbons.Objective,
                    //        Support = heroInfoModel.XP[0].Ribbons.Support
                    //    };
                    //    dbContext.Ribbon.Add(ribbon);
                    //}
                    //else
                    //{
                    //    if (ribbon.Total != heroInfoModel.XP[0].Ribbons.Total)
                    //    {
                    //        ribbon.Total = heroInfoModel.XP[0].Ribbons.Total;
                    //    }
                    //    if (ribbon.Squad != heroInfoModel.XP[0].Ribbons.Squad)
                    //    {
                    //        ribbon.Squad = heroInfoModel.XP[0].Ribbons.Squad;
                    //    }
                    //    if (ribbon.Combat != heroInfoModel.XP[0].Ribbons.Combat)
                    //    {
                    //        ribbon.Combat = heroInfoModel.XP[0].Ribbons.Combat;
                    //    }
                    //    if (ribbon.Intel != heroInfoModel.XP[0].Ribbons.Intel)
                    //    {
                    //        ribbon.Intel = heroInfoModel.XP[0].Ribbons.Intel;
                    //    }
                    //    if (ribbon.Objective != heroInfoModel.XP[0].Ribbons.Objective)
                    //    {
                    //        ribbon.Objective = heroInfoModel.XP[0].Ribbons.Objective;
                    //    }
                    //    if (ribbon.Support != heroInfoModel.XP[0].Ribbons.Support)
                    //    {
                    //        ribbon.Support = heroInfoModel.XP[0].Ribbons.Support;
                    //    }
                    //}

                    //#endregion Ribbons

                    try
                    {
                        dbContext.SaveChanges();
                        response.IsValid = true;
                        response.ReturnText = "Database Update Success";
                    }
                    catch (DbEntityValidationException ex)
                    {
                        foreach (var entityValidationErrors in ex.EntityValidationErrors)
                        {
                            foreach (var validationError in entityValidationErrors.ValidationErrors)
                            {
                                response.AddError("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                            }
                        }
                        response.IsValid = false;
                        response.ReturnText = "Database Update Faild";
                    }
                }
            }
            else
            {
                response.IsValid = false;
                response.ReturnText = "Cache is not exsited";
            }
            return response;
        }

        public int MapIdGet(string mapName)
        {
            if (Utils.MapNamesToIds.TryGetValue(mapName, out int mapId))
            {
                return mapId;
            }
            else
            {
                return 0;
            }
        }

        public int ModeIdGet(string modeName)
        {
            if (Utils.ModeNamesToIds.TryGetValue(modeName, out int modeId))
            {
                return modeId;
            }
            else
            {
                return 0;
            }
        }

        public int SpecialistIdGet(string specialistName)
        {
            if (Utils.SpecialistNamesToIds.TryGetValue(specialistName, out int specialistId))
            {
                return specialistId;
            }
            else
            {
                return 0;
            }
        }

        public int WeaponIdGet(string weapontName)
        {
            if (Utils.WeaponNamesToIds.TryGetValue(weapontName, out int WeaponId))
            {
                return WeaponId;
            }
            else
            {
                return 0;
            }
        }

        public int VehicleIdGet(string vehicleName)
        {
            if (Utils.VehicleNamesToIds.TryGetValue(vehicleName, out int vehicleId))
            {
                return vehicleId;
            }
            else
            {
                return 0;
            }
        }

        public int GadgetIdGet(string gadgeteName)
        {
            if (Utils.GadgetNamesToIds.TryGetValue(gadgeteName, out int gadgeteId))
            {
                return gadgeteId;
            }
            else
            {
                return 0;
            }
        }

        public int RibbonIdGet(string ribbonName)
        {
            if (Utils.RibbonToIds.TryGetValue(ribbonName, out int ribbonId))
            {
                return ribbonId;
            }
            else
            {
                return 0;
            }
        }
    }
}