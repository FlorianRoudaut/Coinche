using System;

namespace Coinche.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu.OpenMenu();

            Console.WriteLine(Consts.Line + " Enter any key to leave the Coinche Game " + Consts.Line);
            Console.ReadLine();
        }
    }
}
