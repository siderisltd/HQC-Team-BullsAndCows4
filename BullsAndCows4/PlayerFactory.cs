////SimpleFactory
namespace BullsAndCowsGame
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Models;
    using Enumerations;
    using Exceptions;

    internal static class PlayerFactory
    {
        private static IMessageLogger logger;

        internal static ICollection<IPlayer> CreatePlayers(GameType gameType, IMessageLogger messageLogger)
        {
            logger = messageLogger;
            ICollection<IPlayer> players = new List<IPlayer>();

            switch (gameType)
            {
                case GameType.SinglePlayer:
                    var humanPlayer = CreateHumanPlayer();
                    var computerPlayer = CreateComputerPlayer();
                    players.Add(humanPlayer);
                    players.Add(computerPlayer);
                    break;

                case GameType.MultiPlayer:
                    var firstPlayer = CreateHumanPlayer();
                    var secondPlayer = CreateHumanPlayer();
                    players.Add(firstPlayer);
                    players.Add(secondPlayer);
                    break;
                default:
                    //throw new ArgumentException("Invalid game type");
                    BullsAndCowsException.GameTypeException();
                    break;
            }

            return players;
        }

        private static IPlayer CreateComputerPlayer()
        {
            logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.ChooseBotPlayerName);
            var botName = logger.ReadMessage();
            var secretNumber = new SecretNumber(logger);
            var botSecretNumber = secretNumber.GenerateSecretNumber();
            var computerPlayer = new ComputerPlayer(botName, botSecretNumber);
            return computerPlayer;
        }

        private static IPlayer CreateHumanPlayer()
        {
            logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.ChooseHumanPlayerName);
            var playerName = logger.ReadMessage();
            var secretNumber = new SecretNumber(logger);
            var humanSecretNumber = secretNumber.EnterSecretNumber();
            var humanPlayer = new HumanPlayer(playerName, humanSecretNumber);
            return humanPlayer;
        }
    }
}