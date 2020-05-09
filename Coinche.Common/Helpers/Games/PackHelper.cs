using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Helpers.Games
{
    public static class PackHelper
    {
        public static Pack BuildPiquetPack()
        {
            var pack = new Pack();
            var ranks = RankHelper.BuildAllRanks();
            var suits = SuitHelper.BuildAllSuits();

            var index = 0;
            foreach (var rank in ranks)
            {
                foreach (var suit in suits)
                {
                    var card = new Card(rank, suit);
                    pack.SetCard(index, card);
                    index++;
                }
            }
            return pack;
        }

        public static Pack Shuffle(Pack pack)
        {
            var shuffledPack = new Pack();
            var random = new Random();
            var allCards = pack.GetAllCards();
            var n = allCards.Count;
            var i = 0;
            while (n > 0)
            {
                var num = random.Next(0, n);
                var card = allCards[num];
                shuffledPack.SetCard(i,card);
                allCards.RemoveAt(num);
                n--;
                i++;
            }

            return shuffledPack;
        }
    }
}
