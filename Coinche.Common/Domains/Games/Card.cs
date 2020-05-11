using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Card
    {
        private CardRank Rank { get; set; }
        private CardSuit Suit { get; set; }

        public Card() { }

        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        override public string ToString()
        {
            return Rank.ToString() + Suit.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Card;
            if (other == null) return false;
            if (!other.Rank.Equals(Rank)) return false;
            return other.Suit.Equals(Suit);
        }

        public override int GetHashCode()
        {
            return Rank.GetHashCode() ^ Suit.GetHashCode();
        }

        public bool IsHigherThan(Card otherCard)
        {
            if (otherCard.Rank.Id > Rank.Id) return false;
            return true;
        }

        public bool IsSameSuit(CardSuit suit)
        {
            if (Suit.Equals(suit)) return true;
            return false;
        }

        public bool IsSameSuit(Card otherCard)
        {
            if (Suit.Equals(otherCard.Suit)) return true;
            return false;
        }

        public int GetRankId()
        {
            return Rank.Id;
        }

        public CardSuit GetSuit()
        {
            return Suit;
        }
    }
}
