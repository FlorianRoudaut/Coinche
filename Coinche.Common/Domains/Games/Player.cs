using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class Player
    {
        public string Name { get; set; }

        public Player() { }

        public Player(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
