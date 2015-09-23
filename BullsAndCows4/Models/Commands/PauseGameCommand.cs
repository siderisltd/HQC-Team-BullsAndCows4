namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Interfaces;
    using BullsAndCowsGame.Engine;

    public class PauseGameCommand : Command, ICommand
    {

        public override void ProcessCommand(IGameEngine engine)
        {
            this.PauseGame(engine);
        }

        private void PauseGame(IGameEngine engine)
        {
            var engineAsConcreteEngine = engine as GameEngine;
            engineAsConcreteEngine.logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.UnpauseMessage);

            var keyPressed = Console.ReadKey();
            while (keyPressed.Key != ConsoleKey.Escape)
            {
                engineAsConcreteEngine.logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.UnpauseMessage);
                keyPressed = Console.ReadKey();
            }
        }
    }
}
