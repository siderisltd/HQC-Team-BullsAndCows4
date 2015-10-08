namespace BullsAndCowsGame.Models
{
    using System.Text.RegularExpressions;

    public static class Validator
    {
        public static bool IsValidNumberGuess(string playerInput)
        {
            var pattern = "^[1-9]{4}$";
            var patternForRepeatingChars = "(.)\\1";

            Regex regex = new Regex(pattern);
            Regex regRepeatingChars = new Regex(patternForRepeatingChars);

            bool isValidNumberGuess = regex.IsMatch(playerInput) && !regRepeatingChars.IsMatch(playerInput);

            return isValidNumberGuess;
        }


    }
}
