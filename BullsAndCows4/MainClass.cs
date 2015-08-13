namespace BullsAndCowsGame
{
    using System;
    using BullsAndCowsGame.Models;
    using ConsoleUtills;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Engine;

    public class MainClass
    {
        public static void Main()
        {
            uint fontSize = 5;
            var splashScreenPath = @"..//..//Files/BullsAndCowsSplashScreen.txt";

            ConsoleHelper.SetConsoleFont(fontSize);
            ConsoleHelper.SetMaxWidth();
            ConsoleHelper.SetMaxHeight();
            ConsoleHelper.CenterConsole();

            ConsoleDrawEngine.DrawSplashScreen(splashScreenPath);

            //This will be replaced with the Engine/Engine
            var game = new BullsAndCows();
            game.Start();
        }
    }
}