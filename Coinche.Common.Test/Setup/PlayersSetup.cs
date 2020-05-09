using Coinche.Common.AI;
using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Test.Setup
{
    public static class PlayersSetup
    {
        public static List<IPlayer> BuildFourAIPlayers()
        {
            var list = new List<IPlayer>();
            var player1 = new AIPlayer(0, "One");
            list.Add(player1);
            var player2 = new AIPlayer(1, "Two");
            list.Add(player2);
            var player3 = new AIPlayer(2, "Three");
            list.Add(player3);
            var player4 = new AIPlayer(3, "Four");
            list.Add(player4);
            return list;
        }
    }
}
