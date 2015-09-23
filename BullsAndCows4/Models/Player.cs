namespace BullsAndCowsGame.Models
{
    using System;
    using BullsAndCowsGame.Interfaces;
    using System.Collections.Generic;

    public abstract class Player : IPlayer, IComparable<IPlayer>
    {
        protected Player(string name, string secretNumber)
        {
            this.Name = name;
            this.Attempts = 0;
            this.secretNumber = secretNumber;
        }

        private readonly string secretNumber;

        public string GetSecretNumber
        {
            get { return this.secretNumber; }
        }

        public ICollection<string> GuessedNumbers { get; }

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

        public void AddGuessNumber()
        {
            
        }
    }
}
