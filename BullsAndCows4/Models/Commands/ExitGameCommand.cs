namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Interfaces;

    public class ExitGameCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            engine.ExitGame();
        }
    }
}
