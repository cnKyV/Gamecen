using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.RiotGames.Core.Entities
{
    public class RiotAccount
    {
        public string Puuid { get; set; }
        public enum Region { europe, americas, asia }
        public IEnumerable<RiotSummoner> Summoners { get; set; }
    }


}
