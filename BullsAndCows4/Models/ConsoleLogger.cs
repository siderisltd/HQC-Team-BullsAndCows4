using System;

namespace BullsAndCowsGame.Models
{
    using BullsAndCowsGame.Interfaces;

    internal class ConsoleLogger : IMessageLogger
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
