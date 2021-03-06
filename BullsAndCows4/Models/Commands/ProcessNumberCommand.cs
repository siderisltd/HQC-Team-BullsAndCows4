﻿namespace BullsAndCowsGame.Models.Commands
{
    using System;
    using System.Linq;
    using BullsAndCowsGame.Engine;
    using BullsAndCowsGame.Interfaces;

    internal class ProcessNumberCommand : Command, ICommand
    {
        public override void ProcessCommand(IGameEngine engine)
        {
            this.ProcessPlayerNumberGuess(engine);
        }

        private void ProcessPlayerNumberGuess(IGameEngine engine)
        {
            var currentPlayer = engine.Players.AsQueryable().Where(x => x.IsOnTurn == true).FirstOrDefault();
            var guessNumber = currentPlayer.GuessNumber;

            IPlayer enemyPlayer = engine.Players.AsQueryable().Where(x => x.IsOnTurn == false).FirstOrDefault();

            var otherPlayerSecretNumber = enemyPlayer.GetSecretNumber;

            var bullsCount = this.CalculateBullsCount(guessNumber, otherPlayerSecretNumber);
            var cowsCount = this.CalculateCowsCount(guessNumber, otherPlayerSecretNumber);

            var bullsAndCowsGameAnswer = bullsCount + " " + Resources.GameMessagesResources.Bulls + " " +
                                         cowsCount + " " + Resources.GameMessagesResources.Cows;

            engine.Logger.LogMessageAndGoNextLine(bullsAndCowsGameAnswer);

            if (bullsCount == 4)
            {
                engine.IsGameFinished = true;
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
