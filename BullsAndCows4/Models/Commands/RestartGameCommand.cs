namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class RestartGameCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            engine.RestartGame();
        }
    }
}
