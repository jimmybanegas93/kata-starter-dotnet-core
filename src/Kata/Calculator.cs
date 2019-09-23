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

            var separator = new[] {",", "\n"};
            var input = userInput;

            if (input.StartsWith("//"))
            {
                var parts = input.Split('\n');

                separator =
                    parts
                        .First()
                        .Replace("//", "")
                        .Replace("[", "")
                        .Split("]");
                ;

                input = parts.Last();
            }


            var numbers = input
                .Split(separator, StringSplitOptions.None)
                .Select(int.Parse)
                .Where(n => n < 1000)
                .ToArray();

            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any()) throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");

            return numbers.Sum();
        }
    }
}