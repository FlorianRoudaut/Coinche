using Coinche.Common.Domains.Games;
using Coinche.Common.Helpers.Games;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.Test.Domains.Games
{
    public class CardSuitsTests
    {
        [Test]
        public void BuildAllSuitsTest()
        {
            var allSuits = SuitHelper.BuildAllSuits();
            Assert.AreEqual(4, allSuits.Count);
            var allSuitsName = string.Join("|", allSuits.Select(t=>t.ToString()));
            Assert.AreEqual("♠|♥|♦|♣", allSuitsName);
        }

        [Test]
        public void GetSuitTest()
        {
            var rank = SuitHelper.GetSuit(CardSuit.Heart);
            Assert.IsNotNull(rank);
        }
    }
}
