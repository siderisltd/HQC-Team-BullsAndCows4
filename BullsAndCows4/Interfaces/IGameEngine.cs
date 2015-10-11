namespace BullsAndCowsGame.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface IGameEngine : IDisposable
    {
        IMessageLogger Logger { get; }

        bool IsGameFinished { get; set; }

        IEnumerable<IPlayer> Players { get; }

        void StartGame();
    }
}
