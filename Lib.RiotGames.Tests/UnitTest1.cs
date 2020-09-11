using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Lib.RiotGames.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Riot-Token", "RGAPI-77c21187-faec-488f-a124-3d4ab734d270");
            var result = httpClient.GetAsync("https://europe.api.riotgames.com/riot/account/v1/accounts/by-puuid/8OvBFEtIP3IvXa6gJCN-39kP197LJQsUI15sKbT-LBp8Jz4sJ9nlMwXdy2wJym0eiOm-etnLAOcpcA");
            Assert.AreEqual(result.Result.StatusCode, System.Net.HttpStatusCode.OK);
        }
    }
}
