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
        private IPlayer LastTrickWinner {get;set;}

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

        public void Play()
        {
            Trump = SuitHelper.GetSuit("Heart");
            var trick = new Trick(Players, Trump);
            for (int i = 0; i < BelotteRules.TrickNumber; i++)
            {
                trick.Play(CardsHeldByPlayers, CardsPlayedByPlayers);

                var newPlayersOrder = RoundHelper.OrderPlayersForNewTrick(Players, trick.GetTaker());
                LastTrickWinner = trick.GetTaker();
                trick = new Trick(newPlayersOrder, Trump);
            }
        }

        public void CountPlayersPoints()
        {
            var firstTeam = true;
            foreach (var player in Players)
            {
                var playedCards = CardsPlayedByPlayers[player];
                var playerPoints = BelotteRules.ComputePoints(Trump, playedCards);
                if (player.Equals(LastTrickWinner)) playerPoints += 10;

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

        public Bid Auction()
        {
            var agreedPlayer = new List<IPlayer>();
            var allBids = new List<Bid>();

            int playersIndex = 0;
            while(agreedPlayer.Count!=Players.Count)
            {
                var player = Players[playersIndex];
                playersIndex++;
                if (playersIndex == Players.Count) playersIndex = 0;
                var cards = CardsHeldByPlayers[player];
                var playerBid = player.MakeBid(cards, allBids);
                if (playerBid.IsPass())
                {
                    agreedPlayer.Add(player);
                }
                else
                {
                    allBids.Add(playerBid);
                    agreedPlayer.Clear();
                }
            }

            if (allBids.Any())
                return allBids.Last();
            else
                return null;
        }

    }
}
