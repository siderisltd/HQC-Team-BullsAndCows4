namespace BullsAndCowsGame.Models
{
    using System;
    using System.Text;
    using BullsAndCowsGame.Enumerations;
    using BullsAndCowsGame.Interfaces;

    public class BullsAndCows
    {
        private const string WellcomeMessage = "Welcome to “Bulls and Cows” game. " +
            "Please try to guess my secret 4-digit number." +
            "Use 'top' to view the top scoreboard, 'restart' " +
            "to start a new game and 'help' to cheat and 'exit' to quit the game.";

        private const string WrongCommandMessage = "Incorrect guess or command!";

        private const int SecretNumberLength = 4;

        private string helpPattern;

        private StringBuilder helpNumber;

        private string generatedNumber;

        private Ranking<IPlayer> rankList;

        private int attempts = 0;

        private int cheats = 0;

        private bool isGameOver = false;

        public BullsAndCows()
        {
            this.rankList = new Ranking<IPlayer>();
        }

        public void Start()
        {
            PlayerCommand enteredCommand;

            this.PrintMessageOnConsole(WellcomeMessage);
            this.GenerateComputerPlayerSecretNumber();
            this.helpNumber = new StringBuilder("XXXX");
            this.helpPattern = string.Empty;

            while (!this.isGameOver)
            {
                Console.Write("Enter your guess or command: ");
                var playerInput = Console.ReadLine();
                enteredCommand = this.InputToCommand(playerInput);
                this.ExecutePlayerCommand(enteredCommand);

                if (enteredCommand == PlayerCommand.Other)
                {
                    if (this.IsValidInput(playerInput))
                    {
                        this.attempts++;
                        var bullsCount = this.CalculateBullsCount(playerInput, this.generatedNumber);
                        var cowsCount = this.CalculateCowsCount(playerInput, this.generatedNumber);

                        if (bullsCount == SecretNumberLength)
                        {
                            this.PrintWinningMessage(this.attempts, this.cheats);
                            this.FinishGame(this.attempts, this.cheats);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
                        }
                    }
                    else
                    {
                        this.PrintMessageOnConsole(WrongCommandMessage);
                    }
                }

                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private void GenerateComputerPlayerSecretNumber()
        {
            var secretNumberLength = 4;
            var secretNumber = string.Empty;

            var numberBuilder = new StringBuilder();
            var random = new Random();

            for (var i = 0; i < secretNumberLength; i++)
            {
                int randomDigit = random.Next(1, 9);
                var randomDigitToString = randomDigit.ToString();

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

            // return secretNumber;
            this.generatedNumber = numberBuilder.ToString();
        }

        private PlayerCommand InputToCommand(string input)
        {
            var command = new PlayerCommand();
            switch (input.ToLower())
            {
                case "top":
                    command = PlayerCommand.TopScores;
                    break;
                case "help":
                    command = PlayerCommand.Help;
                    break;
                case "restart":
                    command = PlayerCommand.Restart;
                    break;
                case "exit":
                    command = PlayerCommand.Exit;
                    break;
                default:
                    command = PlayerCommand.Other;
                    break;
            }

            return command;
        }  // Refactored

        private void ExecutePlayerCommand(PlayerCommand command)
        {
            switch (command)
            {
                case PlayerCommand.TopScores:
                    this.PrintScoreboard();
                    break;
                case PlayerCommand.Help:
                    this.cheats = this.ShowHelpMenu(this.cheats);
                    break;
                case PlayerCommand.Restart:
                    this.RestartGame();
                    break;
                case PlayerCommand.Exit:
                    this.ExitGame();
                    break;
                case PlayerCommand.Other:
                    break;
                default:
                    throw new ArgumentException("PlayerCommand has more values than predicted");
                    break;
            }
        }

        private void ExitGame()
        {
            this.isGameOver = true;
        }

        private void RestartGame()
        {
            Console.Clear();
            var game = new BullsAndCows();
            game.Start();
        }

        private void PrintMessageOnConsole(string messageToPrint)
        {
            Console.WriteLine(messageToPrint);
        }

        private void PrintWinningMessage(int attempts, int cheats)
        {
            Console.Write("Congratulations! You guessed the secret number in {0} attempts", attempts);
            if (cheats == 0)
            {
                Console.WriteLine(".");
            }
            else
            {
                Console.WriteLine(" and {0} cheats.", cheats);
            }
        }

        private int ShowHelpMenu(int cheats)
        {
            if (cheats < 4)
            {
                this.RevealDigit(cheats);
                cheats++;
                Console.WriteLine("The number looks like {0}.", this.helpNumber);
            }
            else
            {
                Console.WriteLine("You are not allowed to ask for more help!");
            }

            return cheats;
        }

        private void PrintScoreboard()
        {
            if (this.rankList.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 1;
                foreach (var player in this.rankList)
                {
                    Console.WriteLine("{0}. {1} --> {2} guess" + ((player.Attempts == 1) ? string.Empty : "es"), i++, player.Name, player.Attempts);
                }
            }
        }

        private void RevealDigit(int cheats)
        {
            if (this.helpPattern == null)
            {
                this.GenerateHelpPattern();
            }

            int digitToReveal = this.helpPattern[cheats] - '0';
            this.helpNumber[digitToReveal - 1] = this.generatedNumber[digitToReveal - 1];
        }

        private void GenerateHelpPattern()
        {
            string[] helpPaterns = 
            {
                "1234", "1243", "1324", "1342", "1432", "1423",
                "2134", "2143", "2314", "2341", "2431", "2413",
                "3214", "3241", "3124", "3142", "3412", "3421",
                "4231", "4213", "4321", "4312", "4132", "4123"
            };

            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);
            int randomPaternNumber = randomNumberGenerator.Next(helpPaterns.Length - 1);
            this.helpPattern = helpPaterns[randomPaternNumber];
        }

        private int CalculateBullsCount(string playerInput, string generatedNumber)
        {
            int bulls = 0;

            for (var i = 0; i < SecretNumberLength; i++)
            {
                if (playerInput[i] == generatedNumber[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }

        private object CalculateCowsCount(string playerInput, string generatedNumber)
        {
            var cows = 0;

            for (var i = 0; i < SecretNumberLength; i++)
            {
                var currentDigitOfPlayerInputToString = playerInput[i].ToString();
                if (generatedNumber.Contains(currentDigitOfPlayerInputToString)
                   && (generatedNumber[i] != playerInput[i]))
                {
                    cows++;
                }
            }

            return cows;
        }

        private bool IsValidInput(string playerInput)
        {
            if (playerInput == string.Empty || playerInput.Length != SecretNumberLength)
            {
                return false;
            }

            for (int i = 0; i < playerInput.Length; i++)
            {
                char currentChar = playerInput[i];
                if (!char.IsDigit(currentChar))
                {
                    return false;
                }
            }

            return true;
        }

        private void FinishGame(int attempts, int cheats)
        {
            if (cheats == 0)
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string playerName = Console.ReadLine();
                this.AddPlayerToScoreboard(playerName, attempts);
                this.PrintScoreboard();
                this.isGameOver = true;
            }
            else
            {
                Console.WriteLine("You are not allowed to enter the top scoreboard.");
            }
        }

        private void AddPlayerToScoreboard(string playerName, int attempts)
        {
            IPlayer player = new Player(playerName, attempts);
            this.rankList.Add(player);
        }
    }
}
