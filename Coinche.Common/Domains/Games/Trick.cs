﻿using Coinche.Common.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Trick
    {
        private List<IPlayer> PlayersOrdered { get; set; }
        private CardSuit Trump { get; set; }

        private Dictionary<IPlayer, Card> PlayedCards { get; set; }
        private IPlayer Taker { get; set; }

        public Trick(List<IPlayer> players, CardSuit trump)
        {
            Trump = trump;
            PlayersOrdered = players;
            PlayedCards = new Dictionary<IPlayer, Card>();
        }

        public void Play(Dictionary<IPlayer, List<Card>> cardsByPlayers)
        {
            if (!cardsByPlayers.Any()) return;

            PlayedCards = new Dictionary<IPlayer, Card>();
            foreach(var player in PlayersOrdered)
            {
                var playerCards = cardsByPlayers[player];
                var playedCard = player.Play(playerCards);
                PlayedCards[player] = playedCard;
                cardsByPlayers[player].Remove(playedCard);
            }
            Taker = BelotteRules.ComputeTaker(Trump, PlayedCards);
        }

        public IPlayer GetTaker()
        {
            return Taker;
        }

        public Dictionary<IPlayer, Card> GetPlayedCards()
        {
            return PlayedCards;
        }
    }
}
