using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Pack
    {
        private SortedDictionary<int,Card> Cards { get; set; }

        public Pack()
        {
            Cards = new SortedDictionary<int, Card>();
        }

        public override string ToString()
        {
            return string.Join("|",Cards.Values.Select(t => t.ToString()));
        }

        public int GetCardsCount()
        {
            return Cards.Count;
        }

        public Card Pop()
        {
            var kvp = Cards.First();
            Cards.Remove(kvp.Key);
            return kvp.Value;
        }

        public static Pack BuildPiquetPack()
        {
            var pack = new Pack();
            var ranks = CardRank.BuildAllRanks();
            var suits = CardSuit.BuildAllSuits();

            var index = 0;
            foreach(var rank in ranks)
            {
                foreach(var suit in suits)
                {
                    var card = new Card(rank, suit);
                    pack.Cards[index] = card;
                    index++;
                }
            }
            return pack;
        }

        public static Pack Shuffle(Pack pack)
        {
            var shuffledPack = new Pack();
            var random = new Random();
            var allCards = pack.Cards.Select(t=>t.Value).ToList();
            var n = allCards.Count();
            var i = 0;
            while(n > 0)
            {
                var num = random.Next(0,n);
                var card = allCards[num];
                shuffledPack.Cards[i] = card;
                allCards.RemoveAt(num);
                n--;
                i++;
            }

            return shuffledPack;
        }
    }
}
