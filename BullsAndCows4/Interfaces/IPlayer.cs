namespace BullsAndCowsGame.Interfaces
{
    using System;

    public interface IPlayer : IComparable<IPlayer>
    {
        string Name { get; set; }

        int Attempts { get; set; }

        string GuessNumber { get; set; }

        bool IsOnTurn { get; set; }

        string GetSecretNumber { get; }
    }
}
