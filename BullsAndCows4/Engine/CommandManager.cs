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
        private IGameEngine engine;

        public CommandManager(IGameEngine engine)
        {
            this.engine = engine;
        }

        private readonly Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>
        {
                { "top", new ShowScoreBoardCommand() },
                { "help", new ShowHelpCommand() },
                { "restart", new RestartGameCommand() },
                { "exit", new ExitGameCommand() },
                {"pause", new PauseGameCommand() }
        };

        public void ProcessCommand(string userCommand)
        {
            if (!this.commands.ContainsKey(userCommand))
            {
                var isValidNumberGuess = IsValidNumberGuess(userCommand);
                throw new NotImplementedException();
            }
            string userCommandToLower = userCommand.ToLower();
            ICommand command = this.commands[userCommandToLower];
            command.ProcessCommand(engine);
        }

        private bool IsValidNumberGuess(string playerInput)
        {
            var pattern = "^[1-9]{4}";
            Regex regex = new Regex(pattern);
            bool isValidNumberGuess = regex.IsMatch(playerInput);

            return isValidNumberGuess;
        }
    }
}
