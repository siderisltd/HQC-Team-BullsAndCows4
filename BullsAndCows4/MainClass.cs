namespace BullsAndCowsGame
{
    using System;
    using BullsAndCowsGame.Models;
    using BullsAndCowsGame.ConsoleHelpers;

    public class MainClass
    {
        public static void Main()
        {
            ConsoleHelper.SetConsoleFont(5);
            Console.WindowHeight = Console.LargestWindowHeight - 1;
            Console.WindowWidth = Console.LargestWindowWidth - 4;
            ConsoleHelper.CenterConsole();
            ConsoleHelper.SplashScreen();

            var game = new BullsAndCows();
            game.Start();
        }
    }
}