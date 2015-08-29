namespace BullsAndCowsGame.Engine
{
    using System;
    using System.Collections.Generic;
    using BullsAndCowsGame.Interfaces;

    public sealed class GameEngine : IGameEngine, ICloneable
    {
        private IEnumerable<IPlayer> players;

        private readonly ICommandManager commandManager;

        public GameEngine(IEnumerable<IPlayer> players)
        {
            this.commandManager = new CommandManager(this);
            this.players = players;
        }

        public void StartGame()
        {
            while (true)
            {
                foreach (var player in players)
                {
                    var userInput = Console.ReadLine();
                    commandManager.ProcessCommand(userInput, player);
                }
            }
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
