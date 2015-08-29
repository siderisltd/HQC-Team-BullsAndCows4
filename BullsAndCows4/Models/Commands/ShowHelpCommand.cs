using System;

namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowHelpCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            this.ShowHelpMenu();
        }

        private void ShowHelpMenu()
        {
            Console.WriteLine("Showing help menu");
        }
    }
}
