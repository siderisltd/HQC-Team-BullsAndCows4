using System;

namespace BullsAndCowsGame.Interfaces
{
    public interface IMessageLogger
    {
        void LogMessageAndGoNextLine(string message);

        void LogMessageOnSameLine(string message);

        string ReadMessage();

        ConsoleKeyInfo ReadKey(bool intercept);
    }
}
