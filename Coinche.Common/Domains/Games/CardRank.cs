using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class CardRank
    {
        public int Id { get; set; }
        public string Letter { get; set; }
        public string Name { get; set; }

        public CardRank() { }

        public CardRank(int id, string letter, string name)
        {
            Id = id;
            Letter = letter;
            Name = name;
        }

        override public string ToString()
        {
            return Letter;
        }

        public override bool Equals(object obj)
        {
            var other = obj as CardRank;
            if (other == null) return false;
            return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

    }
}
