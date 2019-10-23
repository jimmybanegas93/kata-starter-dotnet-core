using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput)
        {
            if(string.IsNullOrEmpty(userInput))
                return 0;

            var newInput = userInput;

            var delimiters = new[] {",", "\n"};


            if (userInput.StartsWith("//"))
            {
                var splitted = userInput.Split("\n");
                
                delimiters = splitted.First()
                    .Replace("//", "")
                    .Replace("[", "")
                    .Split("]");

                newInput = splitted.Last();
            }

            var numbers = newInput
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n <= 1000)
                .ToArray();

            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return numbers.Sum();
        }
    }
}