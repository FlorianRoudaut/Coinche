using Coinche.Common.Domains.Games;
using Coinche.Common.Test.Setup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Test.Domains.Games
{
    public class RoundTests
    {
        [Test]
        public void DealRandomTest()
        {
            var players = PlayersSetup.BuildFourAIPlayers();
            var round = new Round(players, 1);
            
            round.ShuffleAndDeal();

            foreach(var player in players)
            {
                var playerCards = round.GetPlayerCards(player);
                Assert.AreEqual(8, playerCards.Count);
            }
        }
    }
}
