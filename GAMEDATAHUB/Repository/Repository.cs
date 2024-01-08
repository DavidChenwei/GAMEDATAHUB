using GAMEDATAHUB.Models;
using GAMEDATAHUB.Models.BF2042Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace GAMEDATAHUB.Repository
{
    public class Repository
    {
        private MemoryCache cache = MemoryCache.Default;

        public async Task<OverviewModel> HeroInfoGet(string name, string platform)
        {
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            heroInfoModel.PlatForm = platform;
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
                                vehicle.VehicleName == "KORD HMG"||
                                vehicle.VehicleName == "4x4 Utility" ||
                                vehicle.VehicleName == "9M133 Kornet"||
                                vehicle.VehicleName == "Tuk-Tuk" ||
                                vehicle.VehicleName == "M220 TOW Launcher" ||
                                vehicle.VehicleName == "Polaris RZR" ||
                                vehicle.VehicleName == "Polaris Sportsman"||
                                vehicle.VehicleName == "UAV-1" ||
                                vehicle.VehicleName == "Flak 38" ||
                                vehicle.VehicleName == "HMG" ||
                                vehicle.VehicleName == "Centurion C-RAM" ||
                                vehicle.VehicleName == "Polaris RZR" ||
                                vehicle.VehicleName == "Polaris RZR" ||
                                vehicle.VehicleName == "Polaris RZR");

                        }
                        else
                        {
                            Console.WriteLine($"HTTP Request Failed，Code: {response.StatusCode}");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error Message: {ex.Message}");
                    }
                }
            }
            overView = OverviewDataGenerate(heroInfoModel, overView);

            #region Database Operaion

            //GameDataHubEntitiy dbContext = new GameDataHubEntitiy();

            //#region Hero
            //Hero hero = (from s in dbContext.Hero
            //             where s.UserID == heroInfoModel.UserId
            //             select s).FirstOrDefault();
            //if (hero == null)
            //{
            //    hero.UserID = heroInfoModel.UserId ?? "";
            //    hero.Avatar = heroInfoModel.Avatar ?? "";
            //    hero.UserName = heroInfoModel.UserName ?? "";
            //    hero.Id = heroInfoModel.Id ?? "";
            //    dbContext.Hero.Add(hero);
            //    dbContext.SaveChanges();
            //}
            //else
            //{
            //    if (hero.UserID != heroInfoModel.UserId && heroInfoModel.UserId != "")
            //    {
            //        hero.UserID = heroInfoModel.UserId;
            //    }
            //    if (hero.Avatar != heroInfoModel.Avatar && heroInfoModel.Avatar != "")
            //    {
            //        hero.Avatar = heroInfoModel.Avatar;
            //    }
            //    if (hero.UserName != heroInfoModel.UserName && heroInfoModel.UserName != "")
            //    {
            //        hero.UserName = heroInfoModel.UserName;
            //    }
            //    if (hero.Id != heroInfoModel.Id && heroInfoModel.Id != "")
            //    {
            //        hero.Id = heroInfoModel.Id;
            //    }
            //}
            //#endregion

            //#region HeroInfoOverview
            ////HeroOverView heroOverView = (from s in dbContext.HeroOverView
            ////                             where s.HeroId == hero.HeroID
            ////                             select s).FirstOrDefault();
            ////if (heroOverView == null) {
            ////    heroOverView.BestClass = heroInfoModel.BestClass;

            ////    if (decimal.TryParse(heroInfoModel.HumanPrecentage, out decimal HumanPrecentage))
            ////    {
            ////        heroOverView.HumanPercentage = HumanPrecentage;
            ////    }
            ////    else {
            ////        error.AddError("Failed to convert string to decimal: HumanPercentage");
            ////    }

            ////    if (int.TryParse(heroInfoModel.Kills, out int Kills))
            ////    {
            ////        heroOverView.Kills = Kills;
            ////    }
            ////    else
            ////    {
            ////        error.AddError("Failed to convert string to int: Kills");
            ////    }

            ////    if (int.TryParse(heroInfoModel.Deaths, out int Deaths))
            ////    {
            ////        heroOverView.Deaths = Deaths;
            ////    }
            ////    else
            ////    {
            ////        error.AddError("Failed to convert string to int: Deaths");
            ////    }

            ////    if (int.TryParse(heroInfoModel.Wins, out int Wins))
            ////    {
            ////        heroOverView.Wins = Wins;
            ////    }
            ////    else
            ////    {
            ////        error.AddError("Failed to convert string to int: Wins");
            ////    }

            ////    if (int.TryParse(heroInfoModel.Losses, out int Losses))
            ////    {
            ////        heroOverView.Losses = Losses;
            ////    }
            ////    else
            ////    {
            ////        error.AddError("Failed to convert string to int: Losses");
            ////    }

            ////    if (decimal.TryParse(heroInfoModel.KillsPerMinute, out decimal KillsPerMinute))
            ////    {
            ////        heroOverView.KillsPerMinute = KillsPerMinute;
            ////    }
            ////    else
            ////    {
            ////        error.AddError("Failed to convert string to decimal: KillsPerMinute");
            ////    }

            ////    if (decimal.TryParse(heroInfoModel.DamagePerMinute, out decimal DamagePerMinute))
            ////    {
            ////        heroOverView.DamagePerMinute = DamagePerMinute;
            ////    }
            ////    else
            ////    {
            ////        error.AddError("Failed to convert string to decimal: DamagePerMinute");
            ////    }

            ////}
            //#endregion
            //foreach (var weapon in heroInfoModel.Weapons)
            //{
            //}

            #endregion Database Operaion

            return overView;
        }

        public void dbtest()
        {
            int number = 1610672;
            string formattedNumber = number.ToString("N0");

            GameDataHubEntitiy dbContext = new GameDataHubEntitiy();
            var weapon = dbContext.Weapon.FirstOrDefault(w => w.WeaponID == 1);
            if (weapon == null)
            {
                Console.WriteLine("Successful");
            }
        }

        public OverviewModel OverviewInfoGet(string name, string platform) {
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

        public OverviewModel OverviewDataGenerate(HeroInfoModel heroInfoModel, OverviewModel overView) {
            ErrorModel error = new ErrorModel();

            #region show OverView Date First

            overView.UserName = heroInfoModel.UserName;
            overView.Avatar = heroInfoModel.Avatar;
            overView.MatchesPlayed = heroInfoModel.MatchesPlayed;
            overView.DamagePerMinute = heroInfoModel.DamagePerMinute;
            overView.KillDeath = heroInfoModel.KillDeath;
            overView.HeadShotRate = heroInfoModel.HeadShotRate;
            overView.WinPercent = heroInfoModel.WinPercent;
            if (decimal.TryParse(heroInfoModel.HumanPrecentage.Replace("%", ""), out decimal HumanPrecentage))
            {
                overView.HumanKD = Math.Round(overView.KillDeath * HumanPrecentage / 100, 2);
            }
            else
            {
                error.AddError("Failed to convert string to decimal: heroInfoModel.HumanPrecentage");
            }
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
                vehiclesOverView.DPM = Math.Round(vehcile.Damage / ((decimal)vehcile.TimeIn / 60), 2);
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
            #endregion
            return overView;
        }

        public HeroInfoModel MapsInfoGet(string HeroName, string PlatForm, string SortMethod, string HeaderIndex)
        {
            MapModel mapModel = new MapModel();
            ErrorModel error = new ErrorModel();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            if (cache.Contains("MarineChen"))
            {
                heroInfoModel = (HeroInfoModel)cache.Get("MarineChen");
                heroInfoModel.SortMethod = SortMethod;
                heroInfoModel.HeaderIndex = HeaderIndex;
                for (int i = 0; i < heroInfoModel.Maps.Count; i++)
                {
                    if (decimal.TryParse(heroInfoModel.Maps[i].WinPercent.Replace("%", ""), out decimal WinPercent))
                    {
                        heroInfoModel.Maps[i].WinPercentD = WinPercent;
                    }
                    else
                    {
                        error.AddError("Failed to convert string to decimal: HumanPercentage");
                    }
                }
                if (HeaderIndex == "header1")
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

                if (HeaderIndex == "header2")
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

                if (HeaderIndex == "header3")
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

                if (HeaderIndex == "header4")
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

                if (HeaderIndex == "header5")
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
            }
            else
            {
                //To do: read from database
            }
            return heroInfoModel;
        }

        public GameModeView GameModeInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            GameModeView gameModeView = new GameModeView();
            ErrorModel error = new ErrorModel();
            if (cache.Contains("MarineChen"))
            {
                heroInfoModel = (HeroInfoModel)cache.Get("MarineChen");
            }
            else
            {
                //To do: Read from Database
            }

            for (int i = 0; i < heroInfoModel.Gamemodes.Count; i++)
            {
                if (decimal.TryParse(heroInfoModel.Gamemodes[i].WinPercent.Replace("%", ""), out decimal WinPercent))
                {
                    heroInfoModel.Gamemodes[i].WinPercentD = WinPercent;
                }
                else
                {
                    error.AddError("Failed to convert string to decimal: HumanPercentage");
                }
                heroInfoModel.Gamemodes[i].HoursPlayed = heroInfoModel.Gamemodes[i].SecondsPlayed / 3600;
                heroInfoModel.Gamemodes[i].ObjetiveHours = heroInfoModel.Gamemodes[i].ObjetiveTime / 3600;
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
            ErrorModel error = new ErrorModel();
            GameModeView gameModeView = new GameModeView();
            if (cache.Contains("MarineChen"))
            {
                heroInfoModel = (HeroInfoModel)cache.Get("MarineChen");
            }
            else
            {
                //To do: Read from Database
            }

            for (int i = 0; i < heroInfoModel.Gamemodes.Count; i++)
            {
                if (decimal.TryParse(heroInfoModel.Gamemodes[i].WinPercent.Replace("%", ""), out decimal WinPercent))
                {
                    heroInfoModel.Gamemodes[i].WinPercentD = WinPercent;
                }
                else
                {
                    error.AddError("Failed to convert string to decimal: WinPercent");
                }
                heroInfoModel.Gamemodes[i].HoursPlayed = heroInfoModel.Gamemodes[i].SecondsPlayed / 3600;
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

        public SpecialistModelView SpecialistInfoGet(string HeroName, string PlatForm, string SortMethod, string HeaderName) {
            SpecialistModelView specialistModelView = new SpecialistModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ErrorModel error = new ErrorModel();
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
            ErrorModel error = new ErrorModel();
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
            ErrorModel error = new ErrorModel();
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
                if (decimal.TryParse(heroInfoModel.Weapons[i].Headshots.Replace("%", ""), out decimal Headshots))
                {
                    heroInfoModel.Weapons[i].HeadshotsD = Headshots;
                }
                else
                {
                    error.AddError("Failed to convert string to decimal: Headshots");
                }

                if (decimal.TryParse(heroInfoModel.Weapons[i].Accuracy.Replace("%", ""), out decimal Accuracy))
                {
                    heroInfoModel.Weapons[i].AccuracyD = Accuracy;
                }
                else
                {
                    error.AddError("Failed to convert string to decimal: Accuracy");
                }

                heroInfoModel.Classes[i].HoursPlayed = heroInfoModel.Classes[i].SecondsPlayed / 3600;
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
            ErrorModel error = new ErrorModel();
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
                if (decimal.TryParse(heroInfoModel.Weapons[i].Headshots.Replace("%", ""), out decimal Headshots))
                {
                    heroInfoModel.Weapons[i].HeadshotsD = Headshots;
                }
                else
                {
                    error.AddError("Failed to convert string to decimal: Headshots");
                }

                if (decimal.TryParse(heroInfoModel.Weapons[i].Accuracy.Replace("%", ""), out decimal Accuracy))
                {
                    heroInfoModel.Weapons[i].AccuracyD = Accuracy;
                }
                else
                {
                    error.AddError("Failed to convert string to decimal: Accuracy");
                }

                heroInfoModel.Classes[i].HoursPlayed = heroInfoModel.Classes[i].SecondsPlayed / 3600;
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
            ErrorModel error = new ErrorModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            for (int i = 0; i < heroInfoModel.Gadgets.Count; i++)
            {
                heroInfoModel.Gadgets[i].HoursPlayed = heroInfoModel.Gadgets[i].SecondsPlayed / 3600;
            }

            gadgetModelView.MaxDPM = heroInfoModel.Gadgets.Max(m => m.DPM);
            gadgetModelView.MaxKills = heroInfoModel.Gadgets.Max(m => m.Kills);
            gadgetModelView.MaxKPM = heroInfoModel.Gadgets.Max(m => m.KPM);
            gadgetModelView.MaxUses = heroInfoModel.Gadgets.Max(m => m.Uses);
            gadgetModelView.UserName = heroInfoModel.UserName;
            gadgetModelView.Avatar = heroInfoModel.Avatar;
            gadgetModelView.PlatForm = heroInfoModel.PlatForm;

            heroInfoModel.Weapons = heroInfoModel.Weapons.OrderByDescending(w => w.Kills).ToList();

            gadgetModelView.Gadgets = heroInfoModel.Gadgets;


            return gadgetModelView;
        }

        public GadgetModelView GadgetInfoUpdate(string SortMethod, string HeaderName, string HeroName, string PlatForm)
        {
            GadgetModelView gadgetModelView = new GadgetModelView();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            ErrorModel error = new ErrorModel();
            if (cache.Contains(HeroName))
            {
                heroInfoModel = (HeroInfoModel)cache.Get(HeroName);
            }
            else
            {
                //To do: Read from Database
            }

            for (int i = 0; i < heroInfoModel.Gadgets.Count; i++)
            {
                heroInfoModel.Gadgets[i].HoursPlayed = heroInfoModel.Gadgets[i].SecondsPlayed / 3600;
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
            ErrorModel error = new ErrorModel();
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
            ErrorModel error = new ErrorModel();
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
    }
}
