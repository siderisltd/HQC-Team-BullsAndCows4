using System;
using BullsAndCowsGame.Engine;
using BullsAndCowsGame.Interfaces;
using System.Linq;

namespace BullsAndCowsGame.Models.Commands
{
    internal class ProcessNumberCommand : Command, ICommand
    {
        public override void ProcessCommand(IPlayer player, IGameEngine engine)
        {
            this.ProcessPlayerNumberGuess(player, engine);
        }

        private void ProcessPlayerNumberGuess(IPlayer player, IGameEngine engine)
        {
            var asConcreteEngine = engine as GameEngine;
            var guessNumber = player.GuessNumber;

            IPlayer enemyPlayer = asConcreteEngine.Players.AsQueryable().Where(x => x.IsOnTurn == false).FirstOrDefault();


            var otherPlayerSecretNumber = enemyPlayer.GetSecretNumber;

            var bullsCount = this.CalculateBullsCount(guessNumber, otherPlayerSecretNumber);
            var cowsCount = this.CalculateCowsCount(guessNumber, otherPlayerSecretNumber);

            Console.WriteLine("{0} bulls    {1} cows", bullsCount, cowsCount);

            if (bullsCount == 4)
            {
                asConcreteEngine.IsGameFinished = true;
            }
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
