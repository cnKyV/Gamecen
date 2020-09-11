using Lib.RiotGames.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lib.RiotGames.Riot
{
    public class ApiInitializer
    {
        private readonly string _apiKey;

        private async Task InitializeRiotAccount()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Riot-Token", _apiKey);
            await httpClient.GetAsync("https://europe.api.riotgames.com/riot/account/v1/accounts/by-puuid/8OvBFEtIP3IvXa6gJCN-39kP197LJQsUI15sKbT-LBp8Jz4sJ9nlMwXdy2wJym0eiOm-etnLAOcpcA");
        
        }
        public Account RiotAccount { get; set; }
        public ApiInitializer(string ApiKey)
        {
            _apiKey = ApiKey;
        }
       

    }
}
