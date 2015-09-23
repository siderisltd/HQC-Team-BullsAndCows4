using System.Runtime.CompilerServices;

namespace BullsAndCowsGame.Engine
{
    using System;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Models.Commands;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class CommandManager : ICommandManager
    {
        private readonly IMessageLogger logger;

        public IGameEngine engine { get; set; }

        public CommandManager(IMessageLogger logger)
        {
            this.logger = logger;
        }



        private readonly IDictionary<string, ICommand> commands = new Dictionary<string, ICommand>
                                                                   {
                                                                        { "top", new ShowScoreBoardCommand() },
                                                                        { "help", new ShowHelpCommand() },
                                                                        { "restart", new RestartGameCommand() },
                                                                        { "exit", new ExitGameCommand() },
                                                                        { "pause", new PauseGameCommand() },
                                                                        { "processnumber", new ProcessNumberCommand() }
                                                                   };

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
                command.ProcessCommand(player, this.engine);
            }
            else
            {
                logger.LogMessage(Resources.GameMessagesResources.InvalidCommand);
                logger.LogMessage(Resources.GameMessagesResources.EnterInputNumberOrCommand);
                var newCommand = Console.ReadLine();
                this.ProcessCommand(newCommand, player);
            }

        }

        private bool IsValidNumberGuess(string playerInput)
        {
            var pattern = "^[1-9]{4}$";
            Regex regex = new Regex(pattern);
            bool isValidNumberGuess = regex.IsMatch(playerInput);

            return isValidNumberGuess;
        }

        public void SetGameEngine(IGameEngine gameEngine)
        {
            this.engine = gameEngine;
        }
    }
}
