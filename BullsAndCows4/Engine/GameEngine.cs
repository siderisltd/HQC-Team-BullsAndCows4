using BullsAndCowsGame.Enumerations;

namespace BullsAndCowsGame.Engine
{
    using System;
    using System.Collections.Generic;
    using BullsAndCowsGame.Interfaces;

    public sealed class GameEngine : IGameEngine
    {
        private IEnumerable<IPlayer> players;

        private readonly ICommandManager commandManager;

        private readonly IMessageLogger logger;

        public GameEngine(IEnumerable<IPlayer> players, ICommandManager commandManager, GameType mode, IMessageLogger logger)
        {
            this.commandManager = commandManager;
            this.players = players;
            this.Mode = mode;
            this.logger = logger;
        }

        public GameType Mode { get; }

        public void StartGame()
        {
            Console.Clear();
            //TODO: implement differentBehaviours on game modes...
            while (true)
            {
                foreach (var player in players)
                {
                    Console.Write("Enter input number or command :");
                    var userInput = Console.ReadLine();
                    commandManager.ProcessCommand(userInput, player);
                }
            }
        }
    }
}
