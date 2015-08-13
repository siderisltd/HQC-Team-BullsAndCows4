namespace BullsAndCowsGame.Engine
{
    using System;
    using System.Collections.Generic;
    using BullsAndCowsGame.Interfaces;

    public sealed class GameEngine : IGameEngine
    {
        private IEnumerable<IPlayer> players;

        private ICommandManager commandManager;

        public GameEngine(ICommandManager commandManager, IEnumerable<IPlayer> players)
        {
            this.commandManager = commandManager;
            this.players = players;
        }

        public void StartGame()
        {
            while (true)
            {
                var userInput = Console.ReadLine();
                commandManager.ProcessCommand(userInput);
            }
        }
    }
}
