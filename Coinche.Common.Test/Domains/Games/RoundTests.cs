﻿using Coinche.Common.Domains.Games;
using Coinche.Common.Test.Setup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
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

            foreach (var player in players)
            {
                var playerCards = round.GetPlayerCards(player);
                Assert.AreEqual(8, playerCards.Count);
            }
        }

        [Test]
        public void OrderPlayersTest()
        {
            var players = PlayersSetup.BuildFourAIPlayers();

            var first = players[0];
            var second = players[1];
            var third = players[2];
            var fourth = players[3];

            var afterFirst = Round.OrderPlayersForNewTrick(players, first);
            var newOrder = string.Join("|", afterFirst.Select(t => t.PlayerNumber));
            Assert.AreEqual("0|1|2|3", newOrder);

            var afterSecond = Round.OrderPlayersForNewTrick(players, second);
            newOrder = string.Join("|", afterSecond.Select(t => t.PlayerNumber));
            Assert.AreEqual("1|2|3|0", newOrder);

            var afterThird = Round.OrderPlayersForNewTrick(players, third);
            newOrder = string.Join("|", afterThird.Select(t => t.PlayerNumber));
            Assert.AreEqual("2|3|0|1", newOrder);

            var afterFourth = Round.OrderPlayersForNewTrick(players, fourth);
            newOrder = string.Join("|", afterFourth.Select(t => t.PlayerNumber));
            Assert.AreEqual("3|0|1|2", newOrder);
        }
    }
}
