using System;

namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowScoreBoardCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            this.Show();
        }

        private void Show()
        {
            Console.WriteLine("Showing scoreboard");
        }

        private void Clear()
        {
            Console.WriteLine("Hiding scoreboard");
        }
    }
}
