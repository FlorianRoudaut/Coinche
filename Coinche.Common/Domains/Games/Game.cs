using Coinche.Common.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Game
    {
        private List<IPlayer> Players { get; set; }

        private Round CurrentRound { get; set; }

        public Game()
        {
            Players = new List<IPlayer>();
            CurrentRound = new Round();
        }

        public bool IsValidGame()
        {
            return Players.Count == BelotteRules.PlayersNumber;
        }

        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
        }

        public int GetPlayersCount()
        {
            return Players.Count;
        }

        public int GetCurrentRoundNumber()
        {
            return CurrentRound.GetRoundNumber();
        }

        public void Start()
        {
            CurrentRound = new Round(Players, 1);
            CurrentRound.ShuffleAndDeal();
            CurrentRound.Play();
            CurrentRound.CountPlayersPoints();
        }
    }
}
