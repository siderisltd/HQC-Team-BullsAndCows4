namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowHelpCommand : ICommand, IHelpMenu
    {
        public void ProcessCommand(IGameEngine engine)
        {
            this.Show();
        }

        public void Show()
        {
            throw new System.NotImplementedException();
        }
    }
}
