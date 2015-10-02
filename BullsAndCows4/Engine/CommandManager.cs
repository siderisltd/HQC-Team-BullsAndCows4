namespace BullsAndCowsGame.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text.RegularExpressions;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Models.Commands;

    public class CommandManager : ICommandManager
    {
        private readonly IMessageLogger logger;

        private readonly IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>
                                                                   {
                                                                        { "top", new ShowScoreBoardCommand() },
                                                                        { "help", new ShowHelpCommand() },
                                                                        { "restart", new RestartGameCommand() },
                                                                        { "exit", new ExitGameCommand() },
                                                                        { "pause", new PauseGameCommand() },
                                                                        { "processnumber", new ProcessNumberCommand() }
                                                                   };

        public CommandManager(IMessageLogger logger)
        {
            this.logger = logger;
        }

        public IGameEngine Engine { get; set; }

        public void ProcessCommand(string userCommand, IPlayer player)
        {
            var isValidNumberGuess = this.IsValidNumberGuess(userCommand);

            if (isValidNumberGuess)
            {
                player.GuessNumber = userCommand;
                userCommand = "processNumber";
            }

            string userCommandToLower = userCommand.ToLower();

            var isValidCommand = this.commands.ContainsKey(userCommandToLower);

            if (isValidCommand)
            {
                ICommand command = this.commands[userCommandToLower];
                command.ProcessCommand(this.Engine);
            }
            else
            {
                this.logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.InvalidCommand);
                this.logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.EnterInputNumberOrCommand);
                var newCommand = Console.ReadLine();
                this.ProcessCommand(newCommand, player);
            }
        }

        public void SetGameEngine(IGameEngine gameEngine)
        {
            this.Engine = gameEngine;
        }

        private bool IsValidNumberGuess(string playerInput)
        {
            var pattern = "^[1-9]{4}$";
            Regex regex = new Regex(pattern);
            bool isValidNumberGuess = regex.IsMatch(playerInput);
            ////TODO make non repeatable numbers pattern
            return isValidNumberGuess;
        }
    }
}
