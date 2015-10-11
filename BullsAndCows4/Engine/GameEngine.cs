namespace BullsAndCowsGame.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BullsAndCowsGame.Enumerations;
    using BullsAndCowsGame.Interfaces;
    using Exceptions;

    public sealed class GameEngine : IGameEngine, IDisposable
    {
        private const int PlayersCount = 2;
        private readonly ICommandManager commandManager;

        private IMessageLogger logger;
        private IEnumerable<IPlayer> players;

        public GameEngine(IEnumerable<IPlayer> players, ICommandManager commandManager, GameType mode, IMessageLogger logger)
        {
            commandManager.SetGameEngine(this);
            this.commandManager = commandManager;
            this.Players = players;
            this.Mode = mode;
            this.Logger = logger;
        }

        public IMessageLogger Logger
        {
            get
            {
                return this.logger;
            }

            private set
            {
                this.logger = value;
            }
        }

        public IEnumerable<IPlayer> Players
        {
            get
            {
                return this.players;
            }

            private set
            {
                this.ValidatePlayersCount(value);
                this.players = value;
            }
        }

        public GameType Mode { get; set; }

        public bool IsGameFinished { get; set; }

        public void StartGame()
        {
           this.Logger.ClearAllPreviousMessages();
            int playerNumber = 0;
            ////TODO: implement differentBehaviours on game modes...

            while (!this.IsGameFinished)
            {
                IPlayer player = this.GetPlayerOnTurn(this.Players, playerNumber);

                this.Logger.LogMessageAndGoNextLine(player.Name + Resources.GameMessagesResources.PlayerTurnMessage);
                this.Logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.InstructionsForCommands);
                this.Logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.EnterInputNumberOrCommand);

                var userInput = this.Logger.ReadMessage();

                this.commandManager.ProcessCommand(userInput, player);

                if (this.Mode == GameType.MultiPlayer)
                {
                    playerNumber++;
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private IPlayer GetPlayerOnTurn(IEnumerable<IPlayer> players, int playerNumber)
        {
            IEnumerator<IPlayer> enumerator = players.GetEnumerator();
            if (playerNumber % 2 == 1)
            {
                enumerator.MoveNext();
                enumerator.Current.IsOnTurn = false;
            }

            enumerator.MoveNext();
            IPlayer player = enumerator.Current;
            player.IsOnTurn = true;
            return player;
        }

        private void ValidatePlayersCount(IEnumerable<IPlayer> players)
        {
            var count = players.Count();

            if (count != PlayersCount)
            {
                BullsAndCowsException.PlayerCountException(PlayersCount);
            }
        }
    }
}
