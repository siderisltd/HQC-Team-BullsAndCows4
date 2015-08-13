namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Interfaces;

    public class ExitGameCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            this.ExitGame();
        }

        private void ExitGame()
        {
            Environment.Exit(0);
        }
    }
}
