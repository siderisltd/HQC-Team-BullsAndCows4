namespace BullsAndCowsGame.Models
{
    using System;
    using System.Text;
    using Interfaces;

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

            this.secretNumber = numberBuilder.ToString();

            return this.secretNumber;
        }

        public string EnterSecretNumber()
        {
            this.logger.LogMessageAndGoNextLine(Resources.GameMessagesResources.EnterSecretNumberMessage);
            string secretNumber = string.Empty;
            ConsoleKeyInfo key;

            do
            {
                key = this.logger.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    secretNumber += key.KeyChar;
                    this.logger.LogMessageOnSameLine("*");
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    if (secretNumber.Length > 0)
                    {
                        secretNumber = secretNumber.Substring(0, secretNumber.Length - 1);
                        this.logger.LogMessageOnSameLine("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);

            this.logger.LogMessageAndGoNextLine(string.Empty);

            var isValidSecretNumber = Validator.IsValidNumberGuess(secretNumber);
            ////Go recursive to EnterSecretNumber if the number is not correct
            if (!isValidSecretNumber)
            {
                this.EnterSecretNumber();
            }

            return secretNumber;
        }
    }
}
