﻿using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.Rules
{
    public static class BelotteRules
    {
        public const int PlayersNumber = 4;
        public const int TrickNumber = 8;

        public static IPlayer ComputeTaker(CardSuit trump, Dictionary<IPlayer, Card> cardsPlayed)
        {
            var trumpCards = new Dictionary<IPlayer, Card>();
            foreach (var kvp in cardsPlayed)
            {
                var card = kvp.Value;
                if (card.IsSameSuit(trump))
                {
                    trumpCards[kvp.Key] = kvp.Value;
                }
            }

            var firstCard = cardsPlayed.First().Value;
            var sameSuitAsFirst = new Dictionary<IPlayer, Card>();
            foreach (var kvp in cardsPlayed)
            {
                var card = kvp.Value;
                if (card.IsSameSuit(firstCard))
                {
                    sameSuitAsFirst[kvp.Key] = kvp.Value;
                }
            }

            if (trumpCards.Any())
            {
                return GetHighestCardWithTrumpOrder(trumpCards);
            }
            else
            {
                return GetHighestCardPlayer(sameSuitAsFirst);
            }
        }

        private static IPlayer GetHighestCardPlayer(Dictionary<IPlayer, Card> cardsPlayed)
        {
            var first = cardsPlayed.First();
            var maxPlayer = first.Key;
            var maxCard = first.Value;

            foreach (var kvp in cardsPlayed)
            {
                var card = kvp.Value;
                if (card.IsHigherThan(maxCard))
                {
                    maxPlayer = kvp.Key;
                    maxCard = card;
                }
            }

            return maxPlayer;
        }

        private static IPlayer GetHighestCardWithTrumpOrder(Dictionary<IPlayer, Card> cardsPlayed)
        {
            var first = cardsPlayed.First();
            var maxPlayer = first.Key;
            var maxCard = GetTrumpRank(first.Value.GetRankId());

            foreach (var kvp in cardsPlayed)
            {
                var card = kvp.Value;
                var trumpRank = GetTrumpRank(card.GetRankId());

                if (trumpRank > maxCard)
                {
                    maxPlayer = kvp.Key;
                    maxCard = trumpRank;
                }
            }

            return maxPlayer;
        }

        private static int GetTrumpRank(int rankId)
        {
            if (rankId == 7) return 7;
            if (rankId == 8) return 8;
            if (rankId == 10) return 10;
            if (rankId == 12) return 11;
            if (rankId == 13) return 12;
            if (rankId == 14) return 13;
            if (rankId == 9) return 14;
            if (rankId == 11) return 15;
            return 0;
        }
    }
}
