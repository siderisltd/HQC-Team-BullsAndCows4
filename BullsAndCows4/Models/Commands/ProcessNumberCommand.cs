using System;
using BullsAndCowsGame.Interfaces;

namespace BullsAndCowsGame.Models.Commands
{
    internal class ProcessNumberCommand : Command, ICommand
    {
        public override void ProcessCommand(IPlayer player, IGameEngine engine)
        {
            this.ProcessPlayerNumberGuess(player);
        }

        private void ProcessPlayerNumberGuess(IPlayer player)
        {
            var guessNumber = player.GuessNumber;

            //TODO Configure otherPlayer
            var otherPlayerSecretNumber = "1234";

            Console.WriteLine("ImplementPlayerGuess");

            var bullsCount = this.CalculateBullsCount(guessNumber, otherPlayerSecretNumber);
            var cowsCount = this.CalculateCowsCount(guessNumber, otherPlayerSecretNumber);

            Console.WriteLine("{0} bulls    {1} cows", bullsCount, cowsCount);;

        }


        private int CalculateBullsCount(string guessNumber, string otherPlayerSecretNumber)
        {
            int bulls = 0;
            int length = otherPlayerSecretNumber.Length;

            for (var i = 0; i < length; i++)
            {
                if (guessNumber[i] == otherPlayerSecretNumber[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }

        private int CalculateCowsCount(string guessNumber, string otherPlayerSecretNumber)
        {
            var cows = 0;
            int length = otherPlayerSecretNumber.Length;

            for (var i = 0; i < length; i++)
            {
                var currentDigitOfPlayerInputToString = guessNumber[i].ToString();

                if (otherPlayerSecretNumber.Contains(currentDigitOfPlayerInputToString)
                   && (otherPlayerSecretNumber[i] != guessNumber[i]))
                {
                    cows++;
                }
            }

            return cows;
        }



    }
}
