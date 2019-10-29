using System;
using System.Linq;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput = "")
        {
            if (string.IsNullOrEmpty(userInput))
            {
                return 0;
            }

            var delimiters = new[]{",", "\n"};
            var input = userInput;

            if (input.StartsWith("//"))
            {
                var parts = input.Split("\n");
                delimiters = new[] {parts
                    .First()
                    .Replace("//", "")
                    .Replace("[", "")
                    .Replace("]", "")
                };

                input = parts.Last();
            }
            
            var numbers = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse).Where(x => x<=1000).ToArray();

            var negatives = numbers.Where(n => n < 0).ToArray();

            if (negatives.Any())
            {
                throw new Exception($"negatives not allowed: {string.Join(", ", negatives)}");
            }

            return numbers.Sum();

        }
    }
}