namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Interfaces;

    public class PauseGameCommand : ICommand
    {

        public void ProcessCommand(IGameEngine engine)
        {
            this.PauseGame();
        }

        private void PauseGame()
        {
            Console.WriteLine("Game is paused press [esc] to unpause");
            var keyPressed = Console.ReadKey();
            while (keyPressed.Key != ConsoleKey.Escape)
            {
                keyPressed = Console.ReadKey();
            }
        }
    }
}
