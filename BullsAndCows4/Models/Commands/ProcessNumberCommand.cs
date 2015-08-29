using System;
using BullsAndCowsGame.Interfaces;

namespace BullsAndCowsGame.Models.Commands
{
    internal class ProcessNumberCommand : ICommand
    {
        public void ProcessCommand(IGameEngine engine)
        {
            //command processed
        }

        public void ProcessCommand(IPlayer player,  int playerGuessNumber)
        {
            this.ProcessPlayerNumberGuess(player, playerGuessNumber);
        }

        private string ProcessPlayerNumberGuess(IPlayer player, int playerGuessNumber)
        {
            //logic for processing command
            return "command suxess";
        }
    }
}
