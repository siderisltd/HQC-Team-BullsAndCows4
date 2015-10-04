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
            var botName = logger.ReadMessage(); ////TODO:  remove coupled ReadLine
            var botSecretNumber = GenerateSecretNumber();
            var computerPlayer = new ComputerPlayer(botName, botSecretNumber);
            return computerPlayer;
        }

        private static IPlayer CreateHumanPlayer()
        {
            logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.ChooseHumanPlayerName);
            var playerName = logger.ReadMessage();
            var secretNumber = EnterSecretNumber();
            var humanPlayer = new HumanPlayer(playerName, secretNumber);
            return humanPlayer;
        }

        private static string GenerateSecretNumber()
        {
            var secretNumberLength = 4;
            var secretNumber = string.Empty;

            var numberBuilder = new StringBuilder();
            var random = new Random();

            for (var i = 0; i < secretNumberLength; i++)
            {
                int randomDigit = random.Next(1, 9);
                var randomDigitToString = randomDigit.ToString();

                if (!numberBuilder.ToString().Contains(randomDigitToString))
                {
                    numberBuilder.Append(randomDigit);
                }
                else
                {
                    i--;
                }
            }

            secretNumber = numberBuilder.ToString();

            return secretNumber;
        }

        private static string EnterSecretNumber()
        {
            logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.EnterSecretNumberMessage);
            string secretNumber = string.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = logger.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    secretNumber += key.KeyChar;
                    logger.LogMessageOnSameLine("*");
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (secretNumber.Length > 0)
                    {
                        secretNumber = secretNumber.Substring(0, secretNumber.Length - 1);
                        logger.LogMessageOnSameLine("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            CheckIsValidSecretNumber(secretNumber);
            return secretNumber;
        }

        private static void CheckIsValidSecretNumber(string secretNumber)
        {
            var pattern = "^[1-9]{4}$";
            Regex regex = new Regex(pattern);
            bool isValidNumberGuess = regex.IsMatch(secretNumber);

            ////Go recursive to EnterSecretNumber if the number is not correct
            if (!isValidNumberGuess)
            {
                EnterSecretNumber();
            }
        }
    }
}