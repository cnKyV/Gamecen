using Lib.RiotGames.Core.Entities;
using Lib.RiotGames.Core.Entities.RequestModels;
using Newtonsoft.Json;
using Shared.RequestModels;
using Shared.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RiotGames.Riot
{
    public static class RiotApiInitializer
    {
        
        public enum ApiRegion { europe, americas, asia }
        public enum SummonerRegion { 
        tr1,
        ru,
        euw1,
        eun1,
        jp1,
        kr,
        br1,
        na1,
        oc1,
        la1,
        la2
        }
        private static string _apiKey;
        public static string ApiKey
        {
            set { _apiKey = value; }
        }

        public static async IAsyncEnumerable<RiotApiInitializerResponseModel> InitializeRiotApiByTagName(ApiRegion apiRegion, string gameName, string tagName)
        {
            var riotAccountModel = await InitializeRiotAccount(apiRegion, gameName, tagName);
            await foreach (var riotSummoner in InitializeRiotSummoner(riotAccountModel))
            {
                
            }
                
            
        }
        public static async Task<RiotApiInitializerResponseModel> InitializeRiotApiBySummonerName(SummonerRegion summonerRegion, string summonerName)
        {
            var riotAccountModel = await InitializeRiotAccount(summonerName, summonerRegion);
            return new RiotApiInitializerResponseModel();
        }
        private static async Task<RiotAccountRequestModel> InitializeRiotAccount(ApiRegion apiRegion, string gameName, string tagName)  
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _apiKey);
            var resultAccount = await httpClient.GetAsync($"https://{apiRegion}.api.riotgames.com/riot/account/v1/accounts/by-riot-id/{gameName}/{tagName}");
            var contentAccount = await resultAccount.Content.ReadAsStringAsync();
            var initializedSummonerModel = JsonConvert.DeserializeObject<RiotAccountRequestModel>(contentAccount);
            return initializedSummonerModel;
        }        
        private static async Task<RiotSummonerRequestModel> InitializeRiotAccount(string summonerName,SummonerRegion summonerRegion)  
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _apiKey);
            var resultAccount = await httpClient.GetAsync($"https://{summonerRegion}.api.riotgames.com/lol/summoner/v4/summoners/{summonerName}/");
            var contentAccount = await resultAccount.Content.ReadAsStringAsync();
            var initializedSummonerModel = JsonConvert.DeserializeObject<RiotSummonerRequestModel>(contentAccount);
            return initializedSummonerModel;
        }   
        private static async IAsyncEnumerable<RiotSummonerRequestModel> InitializeRiotSummoner(RiotAccountRequestModel riotAccount)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _apiKey);
            foreach (var region in Enum.GetValues(typeof(SummonerRegion)))
            {
                var resultAccount = await httpClient.GetAsync($"https://{region}.api.riotgames.com/lol/summoner/v4/summoners/by-puuid/{riotAccount.Puuid}/");
                var contentAccount = await resultAccount.Content.ReadAsStringAsync();
                var initializedSummonerModel = JsonConvert.DeserializeObject<RiotSummonerRequestModel>(contentAccount);
                yield return initializedSummonerModel;
            }           
        }

       
    }
}
