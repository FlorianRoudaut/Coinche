using Coinche.Common.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Round
    {
        private int RoundNumber { get; set; }
        private List<IPlayer> Players { get; set; }
        private CardSuit Trump { get; set; }
        private Dictionary<IPlayer, List<Card>> CardsHeldByPlayers { get; set; }

        public Round()
        {
            CardsHeldByPlayers = new Dictionary<IPlayer, List<Card>>();
        }


        public Round(List<IPlayer> players, int roundNumber)
        {
            Players = players;
            CardsHeldByPlayers = new Dictionary<IPlayer, List<Card>>();
            RoundNumber = roundNumber;
        }

        public int GetRoundNumber()
        {
            return RoundNumber;
        }

        public void ShuffleAndDeal()
        {
            var pack = Pack.BuildPiquetPack();
            var shuffledPack = Pack.Shuffle(pack);
            foreach (var player in Players)
            {
                CardsHeldByPlayers[player] = new List<Card>();
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
            }

            foreach (var player in Players)
            {
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
            }

            foreach (var player in Players)
            {
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
            }
        }

        public List<Card> GetPlayerCards(IPlayer player)
        {
            return CardsHeldByPlayers[player];
        }

        public void StartPlaying()
        {
            var trick = new Trick(Players, Trump);
            for (int i = 0; i < BelotteRules.TrickNumber; i++)
            {
                trick.Play(CardsHeldByPlayers);
            }
        }
    }
}
