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

        public void SetCard(int index, Card card)
        {
            Cards[index] = card;
        }

        public List<Card> GetAllCards()
        {
            return Cards.Select(t => t.Value).ToList();
        }
    }
}
