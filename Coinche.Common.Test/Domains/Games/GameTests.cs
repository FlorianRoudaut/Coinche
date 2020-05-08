using Coinche.Common.Domains.Games;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Test.Domains.Games
{
    public class GameTests
    {
        [Test]
        public void AddPlayersTest()
        {
            var game = new Game();
            var players = new List<Player>();
            var player1 = new Player("One");
            players.Add(player1);
            var player2 = new Player("Two");
            players.Add(player2);
            var player3 = new Player("Three");
            players.Add(player3);
            var player4 = new Player("Four");
            players.Add(player4);

            foreach (var player in players)
            {
                game.AddPlayer(player);
            }

            Assert.AreEqual(4, game.GetPlayersCount());
        }
    }
}
