using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coinche.Common.Helpers.Games
{
    public static class RoundHelper
    {
        public static List<IPlayer> OrderPlayersForNewTrick(List<IPlayer> players, IPlayer taker)
        {
            var copy = players.Select(t => t).ToList();
            var newOrder = new List<IPlayer>();

            var found = false;
            foreach (var player in players)
            {
                if (found)
                {
                    newOrder.Add(player);
                    copy.Remove(player);
                }
                else
                {
                    if (player.Equals(taker))
                    {
                        found = true;
                        newOrder.Add(player);
                        copy.Remove(player);
                    }
                    else continue;
                }
            }

            foreach (var player in copy)
            {
                newOrder.Add(player);
            }
            return newOrder;
        }

    }
}
