using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput = "")
        {
            if (string.IsNullOrEmpty(userInput))
                return 0;

            var newUserInput = userInput;
            var delimiters = new string[] {",", "\n"};
            if (userInput.StartsWith("//"))
            {
                var stringParts = userInput.Split("\n");
                delimiters = new[] {stringParts.First().Replace("//", "")};
                newUserInput = stringParts.Last();
            }

            var numbers = newUserInput.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();

            return numbers.Sum();
        }
    }
}