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
        internal static ICollection<IPlayer> CreatePlayers(GameType gameType)
        {
            ICollection<IPlayer> players = new List<IPlayer>();

            switch (gameType)
            {
                case GameType.SinglePlayer:
                    var playerName = Console.ReadLine();
                    var humanPlayer = new HumanPlayer(playerName);
                    var computerPlayer = new ComputerPlayer(computerName);
                    players.Add(humanPlayer);
                    players.Add(computerPlayer);
                    break;

                case GameType.MultiPlayer:
                    var firstPlayerName = Console.ReadLine();
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