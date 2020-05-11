using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.ConsoleClient
{
    public class ConsolePlayer : IPlayer
    {
        public int PlayerNumber { get; set; }
        public string Name { get; set; }

        public ConsolePlayer(int number, string name)
        {
            PlayerNumber = number;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }

        public Card Play(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        public Bid MakeBid(List<Card> cards, List<Bid> previousBids)
        {
            var cardsString = string.Join("|",cards.Select(t=>t.ToString()));
            Console.WriteLine("Received cards "+cardsString);

            Console.WriteLine("------ Please make a bid");
            return new Bid(true);
        }
    }
}
