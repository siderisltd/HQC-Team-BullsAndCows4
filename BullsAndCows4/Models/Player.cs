﻿namespace BullsAndCowsGame.Models
{
    using System;
    using BullsAndCowsGame.Interfaces;

    public class Player : IPlayer, IComparable<IPlayer>
    {
        public Player(string name, int attempts)
        {
            this.Name = name;
            this.Attempts = attempts;
        }

        public string Name { get; set; }

        public int Attempts { get; set; }

        public int CompareTo(IPlayer other)
        {
            if (other == null)
            {
                return 1;
            }

            return other.Attempts - this.Attempts;
        }
    }
}
