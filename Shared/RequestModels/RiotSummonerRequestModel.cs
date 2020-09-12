using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.RequestModels
{
    public class RiotSummonerRequestModel
    {
        public string SummonerId { get; set; }
        public string accountId { get; set; }
        public string Puuid{ get; set; }
        public string Name{ get; set; }
        public int ProfileIconId{ get; set; }
        public string RevisionDate{ get; set; }
        public int SummonerLevel{ get; set; }
    }
}
