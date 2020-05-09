using Coinche.Common.Domains.Games;
using Coinche.Common.Test.Setup;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Test.Domains.Games
{
    public class TrickTests
    {
        [Test]
        public void PlayWithRankTest()
        {
            var players = PlayersSetup.BuildFourAIPlayers();
            var secondPlayer = players[1];

            var cardsHeldByPlayer = new Dictionary<IPlayer, List<Card>>();
            var heart = CardSuit.GetSuit(CardSuit.Heart);
            var spade = CardSuit.GetSuit(CardSuit.Spade);

            cardsHeldByPlayer[players[0]] = new List<Card> {
                new Card(CardRank.GetRank("7") ,heart)};
            cardsHeldByPlayer[players[1]] = new List<Card> {
                new Card(CardRank.GetRank("A") ,heart)};
            cardsHeldByPlayer[players[2]] = new List<Card> {
                new Card(CardRank.GetRank("8") ,heart)};
            cardsHeldByPlayer[players[3]] = new List<Card> {
                new Card(CardRank.GetRank("9") ,heart)};

            var trick = new Trick(players, spade);
            trick.Play(cardsHeldByPlayer);
            var winner = trick.GetTaker();
            Assert.AreEqual(secondPlayer, winner);

            var playedCards = trick.GetPlayedCards();
            Assert.IsNotNull(playedCards);
            Assert.AreEqual(4, playedCards.Count);
        }

        [Test]
        public void PlayMultipleSuitsWithTrumpTest()
        {
            var players = PlayersSetup.BuildFourAIPlayers();
            var thirdPlayer = players[2];

            var cardsHeldByPlayer = new Dictionary<IPlayer, List<Card>>();
            var heart = CardSuit.GetSuit(CardSuit.Heart);
            var spade = CardSuit.GetSuit(CardSuit.Spade);

            cardsHeldByPlayer[players[0]] = new List<Card> {
                new Card(CardRank.GetRank("7") ,heart)};
            cardsHeldByPlayer[players[1]] = new List<Card> {
                new Card(CardRank.GetRank("A") ,heart)};
            cardsHeldByPlayer[players[2]] = new List<Card> {
                new Card(CardRank.GetRank("8") ,spade)};
            cardsHeldByPlayer[players[3]] = new List<Card> {
                new Card(CardRank.GetRank("9") ,heart)};

            var trick = new Trick(players, spade);
            trick.Play(cardsHeldByPlayer);
            var winner = trick.GetTaker();
            Assert.AreEqual(thirdPlayer, winner);
        }

        [Test]
        public void PlayTrumpOrderTest()
        {
            var players = PlayersSetup.BuildFourAIPlayers();
            var fourthPlayer = players[3];

            var cardsHeldByPlayer = new Dictionary<IPlayer, List<Card>>();
            var heart = CardSuit.GetSuit(CardSuit.Heart);

            cardsHeldByPlayer[players[0]] = new List<Card> {
                new Card(CardRank.GetRank("7") ,heart)};
            cardsHeldByPlayer[players[1]] = new List<Card> {
                new Card(CardRank.GetRank("A") ,heart)};
            cardsHeldByPlayer[players[2]] = new List<Card> {
                new Card(CardRank.GetRank("8") ,heart)};
            cardsHeldByPlayer[players[3]] = new List<Card> {
                new Card(CardRank.GetRank("9") ,heart)};

            var trick = new Trick(players, heart);
            trick.Play(cardsHeldByPlayer);
            var winner = trick.GetTaker();
            Assert.AreEqual(fourthPlayer, winner);
        }

        [Test]
        public void PlayMultipleColors()
        {
            var players = PlayersSetup.BuildFourAIPlayers();
            var firstPlayer = players[0];

            var cardsHeldByPlayer = new Dictionary<IPlayer, List<Card>>();
            var heart = CardSuit.GetSuit(CardSuit.Heart);
            var spade = CardSuit.GetSuit(CardSuit.Spade);
            var club = CardSuit.GetSuit(CardSuit.Club);

            cardsHeldByPlayer[players[0]] = new List<Card> {
                new Card(CardRank.GetRank("7") ,heart)};
            cardsHeldByPlayer[players[1]] = new List<Card> {
                new Card(CardRank.GetRank("A") ,club)};
            cardsHeldByPlayer[players[2]] = new List<Card> {
                new Card(CardRank.GetRank("8") ,club)};
            cardsHeldByPlayer[players[3]] = new List<Card> {
                new Card(CardRank.GetRank("9") ,club)};

            var trick = new Trick(players, spade);
            trick.Play(cardsHeldByPlayer);
            var winner = trick.GetTaker();
            Assert.AreEqual(firstPlayer, winner);
        }
    }
}
