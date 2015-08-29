namespace BullsAndCowsGame.Interfaces
{
    public interface IGameEngine
    {
        void StartGame();

        object Clone();
    }
}
