namespace BullsAndCowsGame.Models
{
    using System;
    using BullsAndCowsGame.Interfaces;
    using Exceptions;

    public class ComputerPlayer : Player, IPlayer
    {
        private string name;

        public ComputerPlayer(string name, string secretNumber)
            : base(name, secretNumber)
        {
        }

        public override string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    BullsAndCowsException.PlayersNameNullException();
                }

                this.name = value;
            }
        }

        public override int Attempts { get; set; }
    }
}
