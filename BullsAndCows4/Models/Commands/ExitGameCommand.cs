namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Interfaces;

    public class ExitGameCommand : Command, ICommand
    {
        public override void ProcessCommand(IPlayer player, IGameEngine engine)
        {
            this.ExitGame();
        }

        private void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
