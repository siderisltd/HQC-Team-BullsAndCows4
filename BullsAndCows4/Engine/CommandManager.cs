using System.Runtime.CompilerServices;

namespace BullsAndCowsGame.Engine
{
    using System;
    using System.Globalization;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Models.Commands;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CommandManager : ICommandManager
    {

        public CommandManager(IGameEngine gameEngine)
        {
            this.engine = gameEngine;
        }

        private IGameEngine engine;

        private readonly IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>
                                                                   {
                                                                        { "top", new ShowScoreBoardCommand() },
                                                                        { "help", new ShowHelpCommand() },
                                                                        { "restart", new RestartGameCommand() },
                                                                        { "exit", new ExitGameCommand() },
                                                                        { "pause", new PauseGameCommand() },
                                                                        { "processNumber", new ProcessNumberCommand() }
                                                                   };

        public void ProcessCommand(string userCommand, IPlayer player)
        {
            if (!this.commands.ContainsKey(userCommand))
            {
                this.IsValidNumberGuess(userCommand);
                var playerGuessNumber = int.Parse(userCommand);
                userCommand = "processNumber";
            }
            string userCommandToLower = userCommand.ToLower();
            ICommand command = this.commands[userCommandToLower];
            command.ProcessCommand(engine);

        }

        private void IsValidNumberGuess(string playerInput)
        {
            var pattern = "^[1-9]{4}";
            Regex regex = new Regex(pattern);
            bool isValidNumberGuess = regex.IsMatch(playerInput);

            if (!isValidNumberGuess)
            {
                throw new ArgumentException("Invalid number guess should be handled");
            }
        }
    }
}
