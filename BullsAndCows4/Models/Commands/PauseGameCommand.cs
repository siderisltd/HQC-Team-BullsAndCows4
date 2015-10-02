namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Engine;
    using BullsAndCowsGame.Interfaces;

    public class PauseGameCommand : Command, ICommand
    {
        public override void ProcessCommand(IGameEngine engine)
        {
            this.PauseGame(engine);
        }

        private void PauseGame(IGameEngine engine)
        {
            var engineAsConcreteEngine = engine as GameEngine;
            engineAsConcreteEngine.Logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.UnpauseMessage);

            var keyPressed = Console.ReadKey();
            while (keyPressed.Key != ConsoleKey.Escape)
            {
                engineAsConcreteEngine.Logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.UnpauseMessage);
                keyPressed = Console.ReadKey();
            }
        }
    }
}
