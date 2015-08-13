namespace BullsAndCowsGame.Interfaces
{
    public interface IGameEngine
    {
        void StartGame();

        void PauseGame();

        void ShowHelpMenu();

        void ShowScoreBoard();

        void RestartGame();

        void ExitGame();
    }
}
