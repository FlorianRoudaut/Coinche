using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class CardSuit
    {
        private int Id { get; set; }
        private string Name { get; set; }
        private string Unicode { get; set; }

        public CardSuit() { }

        public CardSuit(int id, string name, string unicode)
        {
            Id = id;
            Name = name;
            Unicode = unicode;
        }

        override public string ToString()
        {
            return Unicode;
        }

        public override bool Equals(object obj)
        {
            var other = obj as CardSuit;
            if (other == null) return false;
            return other.Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static List<CardSuit> BuildAllSuits()
        {
            var list = new List<CardSuit>();
            var spade = new CardSuit(1,"Spade", "♠");
            list.Add(spade);
            var heart = new CardSuit(2, "Heart", "♥");
            list.Add(heart);
            var diamond = new CardSuit(3, "Diamond", "♦");
            list.Add(diamond);
            var club = new CardSuit(4, "Club", "♣");
            list.Add(club);
            return list;
        }
    }
}
