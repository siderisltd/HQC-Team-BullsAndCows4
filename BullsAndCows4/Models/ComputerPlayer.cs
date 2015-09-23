﻿namespace BullsAndCowsGame.Models
{
    using BullsAndCowsGame.Interfaces;

    public class ComputerPlayer : Player, IPlayer
    {
        public ComputerPlayer(string name, string secretNumber)
            : base(name, secretNumber)
        {
        }

        public override string Name { get; set; }

        public override int Attempts { get; set; }
    }
}
