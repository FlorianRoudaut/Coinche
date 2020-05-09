using Coinche.Common.Domains.Games;
using Coinche.Common.Helpers.Games;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.Test.Domains.Games
{
    public class PackTests
    {
        [Test]
        public void BuildPiquetPackTest()
        {
            var piquetPack = PackHelper.BuildPiquetPack();
            Assert.AreEqual(32, piquetPack.GetCardsCount());
            var allCards = piquetPack.ToString();
            Assert.AreEqual("7♠|7♥|7♦|7♣|8♠|8♥|8♦|8♣|9♠|9♥|9♦|9♣|10♠|10♥|10♦|10♣|J♠|J♥|J♦|J♣|Q♠|Q♥|Q♦|Q♣|K♠|K♥|K♦|K♣|A♠|"+
                "A♥|A♦|A♣", allCards);
        }

        [Test]
        public void ShufflePackTest()
        {
            var piquetPack = PackHelper.BuildPiquetPack();
            var shuffledPack = PackHelper.Shuffle(piquetPack);

            Assert.AreEqual(32, shuffledPack.GetCardsCount());
            Assert.AreNotEqual(piquetPack.ToString(), shuffledPack.ToString());

            var shuffledAgainPack = PackHelper.Shuffle(shuffledPack);
            Assert.AreNotEqual(shuffledPack.ToString(), shuffledAgainPack.ToString());

        }
    }
}
