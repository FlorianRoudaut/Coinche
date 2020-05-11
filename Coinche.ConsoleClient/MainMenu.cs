using Coinche.Common.AI;
using Coinche.Common.Domains.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coinche.ConsoleClient
{
    public class MainMenu
    {
        public static void OpenMenu()
        {
            Console.WriteLine(Consts.Line + " Welcome to the Coinche Game " + Consts.Line);
            Console.WriteLine();
            Console.WriteLine(" Enter your name to start playing");
            var name = Console.ReadLine();

            var game = new Game();
            var playerOne = new ConsolePlayer(0, name);
            game.AddPlayer(playerOne);
            var two = new AIPlayer(1, "Two");
            game.AddPlayer(two); 
            var three = new AIPlayer(2, "Three");
            game.AddPlayer(three); 
            var four = new AIPlayer(3, "Four");
            game.AddPlayer(four);
            game.Start();
        }
    }
}
