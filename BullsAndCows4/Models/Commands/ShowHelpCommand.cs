using System;

namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowHelpCommand : Command, ICommand
    {
        public override void ProcessCommand(IGameEngine engine)
        {
            this.ShowHelpMenu();
        }

        private void ShowHelpMenu()
        {
            //pazim state na obektite predi show state 

            // davame help menu na console.clear

            // vrushtame sled nqkoi key obektite v state predi help menu to 
            Console.WriteLine("Showing help menu");
        }
    }
}
