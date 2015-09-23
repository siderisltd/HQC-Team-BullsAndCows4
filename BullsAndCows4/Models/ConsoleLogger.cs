using System;

namespace BullsAndCowsGame.Models
{
    using BullsAndCowsGame.Interfaces;

    internal class ConsoleLogger : IMessageLogger
    {
        public void LogMessageAndGoNextLine(string message)
        {
            Console.WriteLine(message);
        }

        public void LogMessageOnSameLine(string message)
        {
            Console.Write(message);
        }

        public string ReadMessage()
        {
            return Console.ReadLine();
        }

        public ConsoleKeyInfo ReadKey(bool intercept)
        {
            return Console.ReadKey(intercept);
        }
    }
}
