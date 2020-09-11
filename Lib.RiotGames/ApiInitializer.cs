using Lib.RiotGames.Core.Entities;
using Lib.RiotGames.Core.Entities.RequestModels;
using Newtonsoft.Json;
using Shared.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RiotGames.Riot
{
    public static class ApiInitializer
    {

        public static async Task<(RiotSummonerRequestModel, RiotAccountRequestModel, string)> InitializeRiotApi(string apiKey)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Riot-Token", apiKey);
           var resultAccount = await httpClient.GetAsync("https://europe.api.riotgames.com/riot/account/v1/accounts/by-puuid/8OvBFEtIP3IvXa6gJCN-39kP197LJQsUI15sKbT-LBp8Jz4sJ9nlMwXdy2wJym0eiOm-etnLAOcpcA");
            var contentAccount = await resultAccount.Content.ReadAsStringAsync();
            var initializedSummonerModel = JsonConvert.DeserializeObject<RiotAccountRequestModel>(contentAccount);

            return (new RiotSummonerRequestModel(), initializedSummonerModel, apiKey);
        }
        
       public static async Task InitializeBlizzardApi(string apiKey)
        {

        }
       
    }
}
