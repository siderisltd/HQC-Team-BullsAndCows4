namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowScoreBoardCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            engine.ShowScoreBoard();
        }
    }
}
