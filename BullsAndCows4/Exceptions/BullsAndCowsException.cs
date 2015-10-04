namespace BullsAndCowsGame.Exceptions
{
    using System;

    public static class BullsAndCowsException
    {
        public static void GameInputException()
        {
            throw new ArgumentException("Incorrent input!");
        }

        public static void GameTypeException()
        {
            throw new ArgumentException("Invalid game type!");
        }

        public static void PlayerCountException(int count)
        {
            throw new ArgumentException(string.Format("Players must be exactly {0}!", count));
        }

        public static void PlayerCommandException()
        {
            throw new ArgumentException("Player's command has more values than was predicted!");
        }

        public static void PlayersNameNullException()
        {
            throw new ArgumentNullException("Player's name cannot be null!");
        }
    }
}
