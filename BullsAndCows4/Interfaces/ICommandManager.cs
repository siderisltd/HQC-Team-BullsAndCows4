﻿namespace BullsAndCowsGame.Interfaces
{
    public interface ICommandManager
    {
        void ProcessCommand(string commandLine, IPlayer player);

        void SetGameEngine(IGameEngine engine);
    }
}
