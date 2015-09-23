using System;

namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowScoreBoardCommand : Command, ICommand
    {
        public override void ProcessCommand(IGameEngine engine)
        {
            this.Show();
        }

        private void Show()
        {
            //pazim state na obektite predi show state 

            // davame help menu na console.clear

            // vrushtame sled nqkoi key obektite v state predi help menu to 

            Console.Clear();
            Console.WriteLine("SCOREBOARD SHOWED");
        }
    }
}
