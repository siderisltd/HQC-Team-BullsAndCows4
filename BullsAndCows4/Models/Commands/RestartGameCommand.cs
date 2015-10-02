namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using BullsAndCowsGame.Engine;
    using BullsAndCowsGame.Interfaces;

    public class RestartGameCommand : Command, ICommand
    {
        public override void ProcessCommand(IGameEngine engine)
        {
            this.RestartGame(engine);
        }

        private void RestartGame(IGameEngine engine)
        {
            engine.Dispose();
            var engineAsGameEngine = engine as GameEngine;
            engineAsGameEngine.Logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.StartingNewGame);
            engine.StartGame();

            ////pri restart trqbva da se napravi prototypePattern i s observer da se zakachim 
            //// i da trigger- nem eventa koito shte vzeme predishniq state /v nachaloto na igrata na obektite
            //// i shte zapochne s tqh 
        }
    }
}
