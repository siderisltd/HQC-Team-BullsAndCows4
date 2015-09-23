namespace BullsAndCowsGame.Interfaces
{
    public interface ICommand
    {
        void ProcessCommand(IGameEngine engine);
    }
}
