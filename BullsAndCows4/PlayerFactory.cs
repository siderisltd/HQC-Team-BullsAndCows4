//SimpleFactory
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

        private static readonly IMessageLogger logger;

        internal static ICollection<IPlayer> CreatePlayers(GameType gameType, IMessageLogger logger)
        {
            ICollection<IPlayer> players = new List<IPlayer>();

            switch (gameType)
            {
                case GameType.SinglePlayer:
                    logger.LogMessage(Resources.GameMessagesResources.ChooseHumanPlayerName);
                    var playerName = Console.ReadLine();
                    var humanPlayer = new HumanPlayer(playerName);
                    logger.LogMessage(Resources.GameMessagesResources.ChooseBotPlayerName);
                    var botName = Console.ReadLine(); //TODO:  remove coupled ReadLine
                    var computerPlayer = new ComputerPlayer(botName);
                    players.Add(humanPlayer);
                    players.Add(computerPlayer);
                    break;

                case GameType.MultiPlayer:
                    logger.LogMessage(Resources.GameMessagesResources.ChooseHumanPlayerName);
                    var firstPlayerName = Console.ReadLine();
                    logger.LogMessage(Resources.GameMessagesResources.ChooseHumanPlayerName);
                    var secondPlayerName = Console.ReadLine();
                    var firstPlayer = new HumanPlayer(firstPlayerName);
                    var secondPlayer = new HumanPlayer(secondPlayerName);
                    players.Add(firstPlayer);
                    players.Add(secondPlayer);
                    break;
                default:
                    throw new ArgumentException("Invalid game type");
            }

            return players;
        }
    }
}