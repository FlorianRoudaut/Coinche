using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Game
    {
        private List<Player> Players { get; set; }

        public Game()
        {
            Players = new List<Player>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public int GetPlayersCount()
        {
            return Players.Count;
        }
    }
}
