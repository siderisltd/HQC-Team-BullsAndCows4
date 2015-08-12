namespace BullsAndCowsGame
{
    using BullsAndCowsGame.Models;

    public class MainClass
    {
        public static void Main()
        {
            var game = new BullsAndCows();
            game.Start();
        }
    }
}