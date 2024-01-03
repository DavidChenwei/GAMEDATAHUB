using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using GAMEDATAHUB.Models.BF2042Model;
using GAMEDATAHUB.Models;

namespace GAMEDATAHUB.Repository
{
    public class Repository
    {
        public string Test()
        {
            return "test";
        }
        public async Task HeroInfoGet(string name, string platform) {

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
                        HeroInfoModel heroInfoModel = new HeroInfoModel();
                        heroInfoModel = JsonConvert.DeserializeObject<HeroInfoModel>(responseBody);

                        //show over view data first


                        GameDataHubEntitiy dbContext = new GameDataHubEntitiy();
                        ErrorModel error = new ErrorModel();

                        #region Hero
                        Hero hero = (from s in dbContext.Hero
                                     where s.UserID == heroInfoModel.UserId
                                     select s).FirstOrDefault();
                        if (hero == null)
                        {
                            hero.UserID = heroInfoModel.UserId ?? "";
                            hero.Avatar = heroInfoModel.Avatar ?? "";
                            hero.UserName = heroInfoModel.UserName ?? "";
                            hero.Id = heroInfoModel.Id ?? "";
                            dbContext.Hero.Add(hero);
                            dbContext.SaveChanges(); 
                        }
                        else {
                            if (hero.UserID != heroInfoModel.UserId && heroInfoModel.UserId!="") {
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
                        }
                        #endregion

                        #region HeroInfoOverview
                        //HeroOverView heroOverView = (from s in dbContext.HeroOverView
                        //                             where s.HeroId == hero.HeroID
                        //                             select s).FirstOrDefault();
                        //if (heroOverView == null) {
                        //    heroOverView.BestClass = heroInfoModel.BestClass;

                        //    if (decimal.TryParse(heroInfoModel.HumanPrecentage, out decimal HumanPrecentage))
                        //    {
                        //        heroOverView.HumanPercentage = HumanPrecentage;
                        //    }
                        //    else {
                        //        error.AddError("Failed to convert string to decimal: HumanPercentage");
                        //    }

                        //    if (int.TryParse(heroInfoModel.Kills, out int Kills))
                        //    {
                        //        heroOverView.Kills = Kills;
                        //    }
                        //    else
                        //    {
                        //        error.AddError("Failed to convert string to int: Kills");
                        //    }

                        //    if (int.TryParse(heroInfoModel.Deaths, out int Deaths))
                        //    {
                        //        heroOverView.Deaths = Deaths;
                        //    }
                        //    else
                        //    {
                        //        error.AddError("Failed to convert string to int: Deaths");
                        //    }

                        //    if (int.TryParse(heroInfoModel.Wins, out int Wins))
                        //    {
                        //        heroOverView.Wins = Wins;
                        //    }
                        //    else
                        //    {
                        //        error.AddError("Failed to convert string to int: Wins");
                        //    }

                        //    if (int.TryParse(heroInfoModel.Losses, out int Losses))
                        //    {
                        //        heroOverView.Losses = Losses;
                        //    }
                        //    else
                        //    {
                        //        error.AddError("Failed to convert string to int: Losses");
                        //    }

                        //    if (decimal.TryParse(heroInfoModel.KillsPerMinute, out decimal KillsPerMinute))
                        //    {
                        //        heroOverView.KillsPerMinute = KillsPerMinute;
                        //    }
                        //    else
                        //    {
                        //        error.AddError("Failed to convert string to decimal: KillsPerMinute");
                        //    }

                        //    if (decimal.TryParse(heroInfoModel.DamagePerMinute, out decimal DamagePerMinute))
                        //    {
                        //        heroOverView.DamagePerMinute = DamagePerMinute;
                        //    }
                        //    else
                        //    {
                        //        error.AddError("Failed to convert string to decimal: DamagePerMinute");
                        //    }


                        //}
                        #endregion
                        foreach (var weapon in heroInfoModel.Weapons)
                        {

                        }
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

        public void dbtest() {
            GameDataHubEntitiy dbContext = new GameDataHubEntitiy();
            var weapon = dbContext.Weapon.FirstOrDefault(w => w.WeaponID == 1);
            if (weapon == null) {
                Console.WriteLine("Successful");
            }
        }
    }   

}