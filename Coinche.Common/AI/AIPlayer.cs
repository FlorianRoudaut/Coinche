using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.AI
{
    public class AIPlayer : IPlayer
    {
        public int PlayerNumber { get; set; }
        public string Name { get; set; }

        public AIPlayer(int number, string name)
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
            return cards[0];
        }
    }
}
