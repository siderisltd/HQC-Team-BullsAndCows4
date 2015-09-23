//SimpleFactory

using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace BullsAndCowsGame
{
    using System;
    using Enumerations;
    using System.Collections.Generic;
    using BullsAndCowsGame.Models;
    using BullsAndCowsGame.Interfaces;

    internal static class PlayerFactory
    {
        private static readonly string computerName = "BullBot";

        private static IMessageLogger logger;

        internal static ICollection<IPlayer> CreatePlayers(GameType gameType, IMessageLogger messageLogger)
        {
            logger = messageLogger;
            ICollection<IPlayer> players = new List<IPlayer>();

            switch (gameType)
            {
                case GameType.SinglePlayer:
                    logger.LogMessage(Resources.GameMessagesResources.ChooseHumanPlayerName);
                    var playerName = Console.ReadLine();
                    var secretNumber = EnterSecretNumber();
                    var humanPlayer = new HumanPlayer(playerName, secretNumber);
                    logger.LogMessage(Resources.GameMessagesResources.ChooseBotPlayerName);
                    var botName = Console.ReadLine(); //TODO:  remove coupled ReadLine
                    var botSecretNumber = GenerateSecretNumber();
                    var computerPlayer = new ComputerPlayer(botName, botSecretNumber);
                    players.Add(humanPlayer);
                    players.Add(computerPlayer);
                    break;

                case GameType.MultiPlayer:
                    logger.LogMessage(Resources.GameMessagesResources.ChooseHumanPlayerName);
                    var firstPlayerName = Console.ReadLine();
                    var firstPlayerSecretNumber = EnterSecretNumber();
                    var firstPlayer = new HumanPlayer(firstPlayerName, firstPlayerSecretNumber);
                    logger.LogMessage(Resources.GameMessagesResources.ChooseHumanPlayerName);
                    var secondPlayerName = Console.ReadLine();
                    var secondPlayerSecretNumber = EnterSecretNumber();
                    var secondPlayer = new HumanPlayer(secondPlayerName, secondPlayerSecretNumber);
                    players.Add(firstPlayer);
                    players.Add(secondPlayer);
                    break;
                default:
                    throw new ArgumentException("Invalid game type");
            }

            return players;
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
            logger.LogMessage(Resources.GameMessagesResources.EnterSecretNumberMessage);
            string secretNumber = string.Empty;
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    secretNumber += key.KeyChar;
                    Console.Write("*");
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (secretNumber.Length > 0)
                    {
                        secretNumber = secretNumber.Substring(0, (secretNumber.Length - 1));
                        Console.Write("\b \b");
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

            //Go recursive to EnterSecretNumber if the number is not correct
            if (!isValidNumberGuess)
            {
                EnterSecretNumber();
            }
        }
    }
}