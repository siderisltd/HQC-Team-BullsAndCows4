namespace BullsAndCowsGame
{
    using System;
    using System.Text;

    public class BullsAndCows
    {
        private const string WellcomeMessage = "Welcome to “Bulls and Cows” game. " +
            "Please try to guess my secret 4-digit number." +
            "Use 'top' to view the top scoreboard, 'restart' " +
            "to start a new game and 'help' to cheat and 'exit' to quit the game.";

        private const string WrongCommandMessage = "Incorrect guess or command!";

        private const int NumberLength = 4;

        private string helpPattern;

        private StringBuilder helpNumber;

        private string generatedNumber;

        private Ranking<Player> klasirane;

        public BullsAndCows()
        {
            this.klasirane = new Ranking<Player>();
        }

        private enum PlayerCommand
        {
            Top,
            Restart,
            Help,
            Exit,
            Other
        }

        public static void Main()
        {
            BullsAndCows game = new BullsAndCows();
            game.Start();
        }

        public void Start()
        {
            PlayerCommand enteredCommand;
            do
            {
                this.PrintWelcomeMessage();
                this.GenerateNumber();
                int attempts = 0;
                int cheats = 0;
                this.helpNumber = new StringBuilder("XXXX");
                this.helpPattern = null;
                do
                {
                    Console.Write("Enter your guess or command: ");
                    string playerInput = Console.ReadLine();
                    enteredCommand = this.PlayerInputToPlayerCommand(playerInput);

                    if (enteredCommand == PlayerCommand.Top)
                    {
                        this.PrintScoreboard();
                    }
                    else if (enteredCommand == PlayerCommand.Help)
                    {
                        cheats = this.PokajiHelp(cheats);
                    }
                    else
                    {
                        if (this.IsValidInput(playerInput))
                        {
                            attempts++;
                            int bullsCount;
                            int cowsCount;
                            this.CalculateBullsAndCowsCount(playerInput, this.generatedNumber, out bullsCount, out cowsCount);
                            if (bullsCount == NumberLength)
                            {
                                this.PrintCongratulateMessage(attempts, cheats);
                                this.FinishGame(attempts, cheats);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Wrong number! Bulls: {0}, Cows: {1}", bullsCount, cowsCount);
                            }
                        }
                        else
                        {
                            if (enteredCommand != PlayerCommand.Restart && enteredCommand != PlayerCommand.Exit)
                            {
                                this.PrintWrongCommandMessage();
                            }
                        }
                    }
                }
                while (enteredCommand != PlayerCommand.Exit && enteredCommand != PlayerCommand.Restart);

                Console.WriteLine();
            }
            while (enteredCommand != PlayerCommand.Exit);

            Console.WriteLine("Good bye!");
        }

        private void GenerateNumber()
        {
            StringBuilder num = new StringBuilder(4);
            Random randomNumberGenerator = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < NumberLength; i++)
            {
                int randomDigit = randomNumberGenerator.Next(9);
                num.Append(randomDigit);
            }

            this.generatedNumber = num.ToString();
        }

        private PlayerCommand PlayerInputToPlayerCommand(string playerInput)
        {
            if (playerInput.ToLower() == "top")
            {
                return PlayerCommand.Top;
            }
            else if (playerInput.ToLower() == "restart")
            {
                return PlayerCommand.Restart;
            }
            else if (playerInput.ToLower() == "help")
            {
                return PlayerCommand.Help;
            }
            else if (playerInput.ToLower() == "exit")
            {
                return PlayerCommand.Exit;
            }
            else
            {
                return PlayerCommand.Other;
            }
        }

        private void PrintWelcomeMessage()
        {
            Console.WriteLine(WellcomeMessage);
        }

        private void PrintWrongCommandMessage()
        {
            Console.WriteLine(WrongCommandMessage);
        }

        private void PrintCongratulateMessage(int attempts, int cheats)
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

        private int PokajiHelp(int cheats)
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

        private void CalculateBullsAndCowsCount(string playerInput, string generatedNumber, out int bullsCount, out int cowsCount)
        {
            bullsCount = 0;
            cowsCount = 0;
            StringBuilder playerNumber = new StringBuilder(playerInput);
            StringBuilder number = new StringBuilder(generatedNumber);
            for (int i = 0; i < playerNumber.Length; i++)
            {
                if (playerNumber[i] == number[i])
                {
                    bullsCount++;
                    playerNumber.Remove(i, 1);
                    number.Remove(i, 1);
                    i--;
                }
            }

            for (int i = 0; i < playerNumber.Length; i++)
            {
                for (int j = 0; j < number.Length; j++)
                {
                    if (playerNumber[i] == number[j])
                    {
                        cowsCount++;
                        playerNumber.Remove(i, 1);
                        number.Remove(j, 1);
                        j--;
                        i--;
                        break;
                    }
                }
            }
        }

        private bool IsValidInput(string playerInput)
        {
            if (playerInput == string.Empty || playerInput.Length != NumberLength)
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
            }
            else
            {
                Console.WriteLine("You are not allowed to enter the top scoreboard.");
            }
        }

        private void AddPlayerToScoreboard(string playerName, int attempts)
        {
            Player player = new Player(playerName, attempts);
            this.klasirane.Add(player);
        }

        private void PrintScoreboard()
        {
            if (this.klasirane.Count == 0)
            {
                Console.WriteLine("Top scoreboard is empty.");
            }
            else
            {
                Console.WriteLine("Scoreboard:");
                int i = 1;
                foreach (Player p in this.klasirane)
                {
                    Console.WriteLine("{0}. {1} --> {2} guess" + ((p.Attempts == 1) ? string.Empty : "es"), i++, p.Name, p.Attempts);
                }
            }
        }
    }
}
