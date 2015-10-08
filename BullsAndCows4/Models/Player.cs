namespace BullsAndCowsGame.Models
{
    using System;
    using System.Collections.Generic;
    using BullsAndCowsGame.Interfaces;

    public abstract class Player : IPlayer, IComparable<IPlayer>
    {
        private readonly string secretNumber;

        protected Player(string name, string secretNumber)
        {
            this.Name = name;
            this.Attempts = 0;
            this.secretNumber = secretNumber;
        }

        public string GetSecretNumber
        {
            get { return this.secretNumber; }
        }

        public ICollection<string> GuessedNumbers { get; set; }

        public abstract string Name { get; set; }

        public abstract int Attempts { get; set; }

        public string GuessNumber { get; set; }

        public bool IsOnTurn { get; set; }

        public virtual int CompareTo(IPlayer other)
        {
            if (other == null)
            {
                return 1;
            }

            return other.Attempts - this.Attempts;
        }

        public void AddGuessNumber(string guessNumber)
        {
            this.GuessedNumbers.Add(guessNumber);
        }
    }
}
