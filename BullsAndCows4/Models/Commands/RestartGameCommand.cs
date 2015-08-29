namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Interfaces;

    public class RestartGameCommand : ICommand
    {
        public RestartGameCommand()
        {
        }

        //private IGameEngine engine;

        public void ProcessCommand(IGameEngine engine)
        {
            this.RestartGame(engine);
        }

        private void RestartGame(IGameEngine engine)
        {
            Console.Clear();
            engine.StartGame();
        }
    }
}
