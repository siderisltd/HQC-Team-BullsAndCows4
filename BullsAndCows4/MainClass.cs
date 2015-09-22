using System;
using System.Collections.Generic;
using BullsAndCowsGame.Engine;
using BullsAndCowsGame.Enumerations;
using BullsAndCowsGame.Interfaces;

namespace BullsAndCowsGame
{
    using BullsAndCowsGame.Models;
    using ConsoleUtills;


    public class MainClass
    {
        public static void Main()
        {
            byte fontSize = 5;
            var splashScreenPath = @"..//..//Files/BullsAndCowsSplashScreen.txt";

            //builder pattern TODO: 
            ConsoleHelper.Instance.SetConsoleFont(fontSize);
            ConsoleHelper.Instance.SetMaxWidth();
            ConsoleHelper.Instance.SetMaxHeight();
            ConsoleHelper.Instance.CenterConsole();
            ConsoleDrawEngine.DrawSplashScreen(splashScreenPath);



            //simple factory pattern to select players
            Console.WriteLine("0. Single player");
            Console.WriteLine("1. Multi player");


            string userInput = Console.ReadLine();
            int userInputAsInteger = 0;
            
            if (!string.IsNullOrEmpty(userInput))
            {
                int.TryParse(userInput, out userInputAsInteger);
            }

            IMessageLogger messageLogger = new ConsoleLogger();
            var gameType = (GameType)userInputAsInteger;
            ICollection<IPlayer> players = PlayerFactory.CreatePlayers(gameType, messageLogger);
            ICommandManager commandManager = new CommandManager(messageLogger);

            IGameEngine engine = new GameEngine(players, commandManager, gameType, messageLogger);
            engine.StartGame();

    
            //This will be replaced with the Engine/Engine
            //var game = new BullsAndCows();
           // game.Start();
        }
    }
}