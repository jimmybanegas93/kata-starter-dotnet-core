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
            var delimiters = new[] {",", "\n"};

            if (userInput.StartsWith("//"))
            {
                var splittedParts = userInput.Split("\n");
                delimiters = new string[] {splittedParts.First().Replace("//", "")};

                newUserInput = splittedParts.Last();
            }


            var numbers = newUserInput.Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            return numbers.Sum();
        }
    }
}