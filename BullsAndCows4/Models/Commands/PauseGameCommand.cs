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
            engine.Logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.UnpauseMessage);

            var keyPressed = engine.Logger.ReadKey(true);
            while (keyPressed.Key != ConsoleKey.Escape)
            {
                engine.Logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.UnpauseMessage);
                keyPressed = engine.Logger.ReadKey(true);
            }
        }
    }
}
