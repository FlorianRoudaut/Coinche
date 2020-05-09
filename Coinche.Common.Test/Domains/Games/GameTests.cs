using Coinche.Common.AI;
using Coinche.Common.Domains.Games;
using Coinche.Common.Test.Setup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Test.Domains.Games
{
    public class GameTests
    {
        private Game InitGame()
        {
            var game = new Game();
            var players = PlayersSetup.BuildFourAIPlayers();
            foreach(var player in players)
            {
                game.AddPlayer(player);
            }
            return game;
        }

        [Test]
        public void AddPlayersTest()
        {
            var game = InitGame();
            Assert.AreEqual(4, game.GetPlayersCount());
        }

        [Test]
        public void StartGameTest()
        {
            var game = InitGame();

            game.Start();
            Assert.AreEqual(1, game.GetCurrentRoundNumber());
        }

        [Test]
        public void IsValidGameTest()
        {
            var game = new Game();
            Assert.AreEqual(false, game.IsValidGame());

            game = InitGame();
            Assert.AreEqual(true, game.IsValidGame());
        }
    }
}
