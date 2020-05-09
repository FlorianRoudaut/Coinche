using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public class CardSuit
    {
        public const string Spade = "Spade";
        public const string Heart = "Heart";
        public const string Diamond = "Diamond";
        public const string Club = "Club";

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


    }
}
