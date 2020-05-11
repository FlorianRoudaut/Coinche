using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.AI
{
    public class AIPlayer : IPlayer
    {
        public int PlayerNumber { get; set; }
        public string Name { get; set; }

        public AIPlayer(int number, string name)
        {
            PlayerNumber = number;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public Card Play(List<Card> cards)
        {
            return cards[0];
        }

        public Bid MakeBid(List<Card> cards, List<Bid> previousBids)
        {
            var sortedCards = SortCardsBySuit(cards);
            var maxPotential = 0;
            var maxPotentialSuit = new CardSuit();
            foreach (var kvp in sortedCards)
            {
                var suit = kvp.Key;
                var suitCards = kvp.Value;
                var potential = EstimateSuitAsTrump(suitCards);
                foreach (var kvp2 in sortedCards)
                {
                    var otherSuit = kvp2.Key;
                    if (otherSuit.Equals(suit)) continue;
                    if (kvp2.Value.Any(t => t.GetRankId() == 14)) potential = potential + 10;
                }

                if (potential > maxPotential)
                {
                    maxPotential = potential;
                    maxPotentialSuit = suit;
                }
            }

            if (maxPotential >= 80)
            {
                if (previousBids.Any())
                {
                    var currentBid = previousBids.Last();
                    if (maxPotential > currentBid.GetTarget())
                    {
                        return new Bid(maxPotential, maxPotentialSuit);
                    }
                    else
                    {
                        return new Bid(true);
                    }
                }
                else
                {
                    return new Bid(maxPotential, maxPotentialSuit);
                }
            }
            else return new Bid(true);
        }

        public Dictionary<CardSuit, List<Card>> SortCardsBySuit(List<Card> cards)
        {
            var sortedCards = new Dictionary<CardSuit, List<Card>>();
            foreach (var card in cards)
            {
                var suit = card.GetSuit();
                if (sortedCards.ContainsKey(suit))
                {
                    sortedCards[suit].Add(card);
                }
                else
                {
                    sortedCards[suit] = new List<Card> { card };
                }
            }
            return sortedCards;
        }

        public int EstimateSuitAsTrump(List<Card> cards)
        {
            var hasJack = cards.Any(t => t.GetRankId() == 11);
            var hasNine = cards.Any(t => t.GetRankId() == 9);

            if (hasJack && hasNine)
            {
                return 40 + (cards.Count - 1) * 20;
            }
            else if (hasJack && cards.Count > 2)
            {
                return 40 + (cards.Count -1) * 20;
            }
            else if (cards.Count >= 5)
            {
                return cards.Count * 20;
            }
            return 0;
        }
    }
}
