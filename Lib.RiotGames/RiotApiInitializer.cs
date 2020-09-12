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
        private static readonly RiotAccountRequestModel _riotAccountRequestModel;
        private static readonly RiotSummonerRequestModel riotSummonerRequestModel;

        public static string ApiKey
        {
            set { _apiKey = value; }
        }

        public static async Task<RiotApiInitializerResponseModel> InitializeRiotApiByTagName(ApiRegion apiRegion, string gameName, string tagName)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _apiKey);
           var resultAccount = await httpClient.GetAsync($"https://{apiRegion}.api.riotgames.com/riot/account/v1/accounts/by-puuid/8OvBFEtIP3IvXa6gJCN-39kP197LJQsUI15sKbT-LBp8Jz4sJ9nlMwXdy2wJym0eiOm-etnLAOcpcA");
            var contentAccount = await resultAccount.Content.ReadAsStringAsync();
            var initializedSummonerModel = JsonConvert.DeserializeObject<RiotAccountRequestModel>(contentAccount);
            return new RiotApiInitializerResponseModel();
        }
        public static async Task<RiotApiInitializerResponseModel> InitializeRiotApiBySummonerName(SummonerRegion summonerRegion, string summonerName)
        {
            return new RiotApiInitializerResponseModel();
        }
        private static async Task<RiotAccountRequestModel> InitializeRiotAccount()  
        {
            return new RiotAccountRequestModel();
        }
        private static async Task<RiotSummonerRequestModel> InitializeRiotSummoner()
        {
            return new RiotSummonerRequestModel();
        }

       public static async Task InitializeBlizzardApi(string apiKey)
        {

        }
       
    }
}
