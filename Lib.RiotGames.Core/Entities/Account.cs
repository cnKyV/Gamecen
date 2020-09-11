using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.RiotGames.Core.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Puuid { get; set; }
        public string GameName { get; set; }
        public string TagName { get; set; }
        public enum Region {europe, americas, asia}
    }
}
