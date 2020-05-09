using Coinche.Common.Domains.Games;
using Coinche.Common.Helpers.Games;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Coinche.Common.Test.Domains.Games
{
    public class CardRankTests
    {
        [Test]
        public void BuildAllRanksTest()
        {
            var allRanks =  RankHelper.BuildAllRanks();
            Assert.AreEqual(8, allRanks.Count);
            var allRanksName = string.Join("|", allRanks.Select(t => t.ToString()));
            Assert.AreEqual("7|8|9|10|J|Q|K|A", allRanksName);
        }

        [Test]
        public void GetRankTest()
        {
            var rank = RankHelper.GetRank("A");
            Assert.IsNotNull(rank);
            Assert.AreEqual(14, rank.Id);
            Assert.AreEqual("A", rank.Letter);
            Assert.AreEqual("Ace", rank.Name);
        }
    }
}
