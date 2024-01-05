using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using GAMEDATAHUB.Models.BF2042Model;
using GAMEDATAHUB.Models;
using System.Runtime.Caching;

namespace GAMEDATAHUB.Repository
{
    public class Repository
    {
        MemoryCache cache = MemoryCache.Default;
        public async Task<OverviewModel> HeroInfoGet(string name, string platform)
        {
            
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            heroInfoModel.PlatForm = platform;
            OverviewModel overView = new OverviewModel();
            overView.PlatForm = platform;
            if (cache.Contains(name))
            {
                heroInfoModel = (HeroInfoModel)cache.Get("name");
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
            #endregion
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

        public HeroInfoModel MapsInfoGet() {
            MapModel mapModel = new MapModel();
            ErrorModel error = new ErrorModel();
            HeroInfoModel heroInfoModel = new HeroInfoModel();
            if (cache.Contains("MarineChen"))
            {
                heroInfoModel = (HeroInfoModel)cache.Get("MarineChen");
                for (int i = 0; i < heroInfoModel.Maps.Count; i++) {
                    if (decimal.TryParse(heroInfoModel.Maps[i].WinPercent.Replace("%", ""), out decimal WinPercent))
                    {
                        heroInfoModel.Maps[i].WinPercentD = WinPercent;
                    }
                    else
                    {
                        error.AddError("Failed to convert string to decimal: HumanPercentage");
                    }
                }
                heroInfoModel.Maps = heroInfoModel.Maps.OrderByDescending(w => w.Wins).ToList();

            }
            else { 
                //To do: read from database
            }
            return heroInfoModel;
        }
    }

}