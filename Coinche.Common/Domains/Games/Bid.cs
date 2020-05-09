using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Bid
    {
        private int Target { get; set; }
        private CardSuit Suit { get; set; }

        public Bid() { }

        public Bid(int target, CardSuit suit)
        {
            Target = target;
            Suit = suit;
        }

        override public string ToString()
        {
            return Target.ToString() + Suit.ToString();
        }

        public override bool Equals(object obj)
        {
            var other = obj as Bid;
            if (other == null) return false;
            if (!other.Target.Equals(Target)) return false;
            return other.Suit.Equals(Suit);
        }

        public override int GetHashCode()
        {
            return Target.GetHashCode() ^ Suit.GetHashCode();
        }
    }
}
