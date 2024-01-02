using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
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
    }   

}