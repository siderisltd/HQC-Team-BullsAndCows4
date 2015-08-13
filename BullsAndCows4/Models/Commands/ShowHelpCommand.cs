namespace BullsAndCowsGame.Models.Commands
{
    using BullsAndCowsGame.Interfaces;

    public class ShowHelpCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            engine.ShowHelpMenu();
        }
    }
}
