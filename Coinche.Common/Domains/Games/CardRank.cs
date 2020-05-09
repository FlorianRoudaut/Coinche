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

        public static List<CardRank> BuildAllRanks()
        {
            var list = new List<CardRank>();
            var seven = new CardRank(7, "7", "Seven");
            list.Add(seven);
            var eight = new CardRank(8, "8", "Eight");
            list.Add(eight);
            var nine = new CardRank(9, "9", "Nine");
            list.Add(nine);
            var ten = new CardRank(10, "10", "Ten");
            list.Add(ten);

            var jack = new CardRank(11, "J", "Jack");
            list.Add(jack);
            var queen = new CardRank(12, "Q", "Queen");
            list.Add(queen);
            var king = new CardRank(13, "K", "King");
            list.Add(king);
            var ace = new CardRank(14, "A", "Ace");
            list.Add(ace);
            return list;
        }

        public static CardRank GetRank(string letter)
        {
            if (letter == "7")
            {
                return new CardRank(7, "7", "Seven");
            }
            else if (letter == "8")
            {
                return new CardRank(8, "8", "Eight");
            }
            else if (letter == "9")
            {
                return new CardRank(9, "9", "Nine");
            }
            else if (letter == "10")
            {
                return new CardRank(10, "10", "Ten");
            }
            else if (letter == "J")
            {
                return new CardRank(11, "J", "Jack");
            }
            else if (letter == "Q")
            {
                return new CardRank(12, "Q", "Queen");
            }
            else if (letter == "K")
            {
                return new CardRank(13, "K", "King");
            }
            else if (letter == "A")
            {
                return new CardRank(14, "A", "Ace");
            }
            return null;
        }
    }
}
