namespace BullsAndCowsGame.Engine
{
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Models.Commands;
    using System.Collections.Generic;

    public class CommandManager : ICommandManager
    {
        private readonly Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>
        {
                { "top", new ShowScoreBoardCommand() },
                { "help", new ShowHelpCommand() },
                { "restart", new RestartGameCommand() },
                { "exit", new ExitGameCommand() }
        };

        public void ProcessCommand(string userCommand)
        {
            string userCommandToLower = userCommand.ToLower();
            ICommand command = this.commands[userCommandToLower];
            command.ProcessCommand();
        }
    }
}
