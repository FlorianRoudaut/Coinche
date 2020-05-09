using Coinche.Common.Helpers.Games;
using Coinche.Common.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Round
    {
        private int RoundNumber { get; set; }
        private List<IPlayer> Players { get; set; }
        private CardSuit Trump { get; set; }
        private Dictionary<IPlayer, List<Card>> CardsHeldByPlayers { get; set; }
        private Dictionary<IPlayer, List<Card>> CardsPlayedByPlayers { get; set; }

        private int FirstTeamPoints { get; set; }
        private int SecondTeamPoints { get; set; }

        public Round()
        {
            CardsHeldByPlayers = new Dictionary<IPlayer, List<Card>>();
            CardsPlayedByPlayers = new Dictionary<IPlayer, List<Card>>();
        }


        public Round(List<IPlayer> players, int roundNumber)
        {
            Players = players;
            CardsHeldByPlayers = new Dictionary<IPlayer, List<Card>>();
            CardsPlayedByPlayers = new Dictionary<IPlayer, List<Card>>();
            RoundNumber = roundNumber;
        }

        public int GetRoundNumber()
        {
            return RoundNumber;
        }

        public int GetFirstTeamPoints()
        {
            return FirstTeamPoints;
        }

        public int GetSecondTeamPoints()
        {
            return SecondTeamPoints;
        }

        public void ShuffleAndDeal()
        {
            var pack = PackHelper.BuildPiquetPack();
            var shuffledPack = PackHelper.Shuffle(pack);
            foreach (var player in Players)
            {
                CardsHeldByPlayers[player] = new List<Card>();
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsHeldByPlayers[player].Add(shuffledPack.Pop());
                CardsPlayedByPlayers[player] = new List<Card>();
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
                trick.Play(CardsHeldByPlayers, CardsPlayedByPlayers);

                var newPlayersOrder = RoundHelper.OrderPlayersForNewTrick(Players, trick.GetTaker());
                trick = new Trick(newPlayersOrder, Trump);
            }
            AddPlayersPoints();
        }

        public void AddPlayersPoints()
        {
            var firstTeam = true;
            foreach (var player in Players)
            {
                var playedCards = CardsPlayedByPlayers[player];
                var playerPoints = BelotteRules.ComputePoints(Trump, playedCards);
                if (firstTeam)
                {
                    firstTeam = false;
                    FirstTeamPoints += playerPoints;
                }
                else
                {
                    firstTeam = true;
                    SecondTeamPoints += playerPoints;
                }
            }
        }

    }
}
