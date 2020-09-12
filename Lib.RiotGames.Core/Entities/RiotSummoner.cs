using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class RiotSummoner
    {
        public string SummonerId { get; set; }
        public string AccountId { get; set; }
        public string GameName { get; set; }
        public string TagName { get; set; }
        public int ProfileIconId { get; set; }
        public string RevisionDate { get; set; }
        public int SummonerLevel { get; set; }
        public enum SummonerRegion
        {
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
    }
}
