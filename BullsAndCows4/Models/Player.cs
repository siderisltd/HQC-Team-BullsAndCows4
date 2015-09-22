namespace BullsAndCowsGame.Models
{
    using System;
    using BullsAndCowsGame.Interfaces;
    using System.Collections.Generic;

    public abstract class Player : IPlayer, IComparable<IPlayer>
    {
        protected Player(string name)
        {
            this.Name = name;
            this.Attempts = 0;
        }

        public ICollection<string> GuessedNumbers { get; }

        public abstract string Name { get; set; }

        public abstract int Attempts { get; set; }

        public string GuessNumber { get; set; }

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
