namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Interfaces;

    public abstract class Command : ICommand
    {
        public abstract void ProcessCommand(IGameEngine engine);
    }
}
