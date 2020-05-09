using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Helpers.Games
{
    public static class SuitHelper
    {
        public static List<CardSuit> BuildAllSuits()
        {
            var list = new List<CardSuit>();
            var spade = new CardSuit(1, CardSuit.Spade, "♠");
            list.Add(spade);
            var heart = new CardSuit(2, CardSuit.Heart, "♥");
            list.Add(heart);
            var diamond = new CardSuit(3, CardSuit.Diamond, "♦");
            list.Add(diamond);
            var club = new CardSuit(4, CardSuit.Club, "♣");
            list.Add(club);
            return list;
        }

        public static CardSuit GetSuit(string name)
        {
            if (name == CardSuit.Spade)
            {
                return new CardSuit(1, CardSuit.Spade, "♠");
            }
            else if (name == CardSuit.Heart)
            {
                return new CardSuit(2, CardSuit.Heart, "♥");
            }
            else if (name == CardSuit.Diamond)
            {
                return new CardSuit(3, CardSuit.Diamond, "♦");
            }
            else if (name == CardSuit.Club)
            {
                return new CardSuit(4, CardSuit.Club, "♣");
            }
            return null;
        }
    }
}
