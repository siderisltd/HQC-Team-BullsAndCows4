namespace BullsAndCowsGame.Models
{
    using Interfaces;
    using System;
    using System.Text;

    public class SecretNumber
    {
        private const int SecretNumberLength = 4;

        private string secretNumber;

        private IMessageLogger logger;

        public SecretNumber(IMessageLogger logger)
        {
            this.logger = logger;
            this.secretNumber = string.Empty;
        }

        public string GenerateSecretNumber()
        {
            var numberBuilder = new StringBuilder();
            var random = new Random();

            for (var i = 0; i < SecretNumberLength; i++)
            {
                int randomDigit = random.Next(1, 10);
                string randomDigitToString = randomDigit.ToString();

                if (!numberBuilder.ToString().Contains(randomDigitToString))
                {
                    numberBuilder.Append(randomDigit);
                }
                else
                {
                    i--;
                }
            }

            secretNumber = numberBuilder.ToString();

            return secretNumber;
        }

        public string EnterSecretNumber()
        {
            logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.EnterSecretNumberMessage);
            string secretNumber = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = logger.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    secretNumber += key.KeyChar;
                    logger.LogMessageOnSameLine("*");
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (secretNumber.Length > 0)
                    {
                        secretNumber = secretNumber.Substring(0, secretNumber.Length - 1);
                        logger.LogMessageOnSameLine("\b \b");
                    }
                }
            }

            while (key.Key != ConsoleKey.Enter);

            logger.LogMessageAndGoNextLine(string.Empty);

            var isValidSecretNumber = Validator.IsValidNumberGuess(secretNumber);
            ////Go recursive to EnterSecretNumber if the number is not correct
            if (!isValidSecretNumber)
            {
                EnterSecretNumber();
            }

            return secretNumber;
        }
    }
}
