namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowScoreBoardCommand : ICommand, IScoreBoard
    {
        public void ProcessCommand(IGameEngine engine)
        {
            this.Show();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
