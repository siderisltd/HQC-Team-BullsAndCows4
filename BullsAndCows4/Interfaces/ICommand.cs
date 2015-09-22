namespace BullsAndCowsGame.Interfaces
{
    public interface ICommand
    {
        void ProcessCommand(IPlayer player, IGameEngine engine);
    }
}
