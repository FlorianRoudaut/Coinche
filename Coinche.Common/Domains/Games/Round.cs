using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Round
    {
        private Dictionary<int,Player> Players { get; set; }

        public Round() 
        {
            Players = new Dictionary<int, Player>();
        }
    }
}
