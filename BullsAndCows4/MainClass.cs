namespace BullsAndCowsGame
{
    using System;
    using System.Collections.Generic;
    using BullsAndCowsGame.Engine;
    using BullsAndCowsGame.Enumerations;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Models;
    using ConsoleUtills;
    using Exceptions;

    internal static class MainClass
    {
        internal static void Main()
        {
            byte fontSize = 5;

            ////TODO: Extract in web.config with add
            var splashScreenPath = @"..//..//Files/BullsAndCowsSplashScreen.txt";

            ////builder pattern TODO: 
            ConsoleHelper.Instance.SetConsoleFont(fontSize);
            ConsoleHelper.Instance.SetMaxWidth();
            ConsoleHelper.Instance.SetMaxHeight();
            ConsoleHelper.Instance.CenterConsole();
            ConsoleDrawEngine.DrawSplashScreen(splashScreenPath);

            IMessageLogger messageLogger = new ConsoleLogger();
            ////simple factory pattern to select players

            messageLogger.LogMessageAndGoNextLine(Resources.GameMessagesResources.SinglePlayerGame);
            messageLogger.LogMessageAndGoNextLine(Resources.GameMessagesResources.MultiplayerGame);

            string userInput = messageLogger.ReadMessage();
            int userInputAsInteger = 0;
            
            if (!string.IsNullOrEmpty(userInput))
            {
                int.TryParse(userInput, out userInputAsInteger);
                if(!Enum.IsDefined(typeof(GameType), userInputAsInteger))
                {
                    //throw new ArgumentException("Incorrect input");
                    BullsAndCowsException.GameInputException();
                }
            }

            var gameType = (GameType)userInputAsInteger;

            ICollection<IPlayer> players = PlayerFactory.CreatePlayers(gameType, messageLogger);
            ICommandManager commandManager = new CommandManager(messageLogger);

            IGameEngine engine = new GameEngine(players, commandManager, gameType, messageLogger);
            engine.StartGame();

            ////This will be replaced with the Engine/Engine
            ////var game = new BullsAndCows();
            //// game.Start();
        }
    }
}