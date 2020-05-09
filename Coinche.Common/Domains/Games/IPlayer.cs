using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.Common.Domains.Games
{
    public interface IPlayer
    {
        int PlayerNumber { get; set; }
        string Name { get; set; }
        Card Play(List<Card> cards);
    }
}
