using System;
using System.Linq;
using static System.Int32;

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

            var delimiters = new[] {",", "\n" };
            var input = userInput;

            if (userInput.StartsWith("//"))
            {
                var parts = userInput.Split('\n');
                delimiters = new[] { parts.First().Replace("//", "") };
                input = parts.Last();

            }
            
            var numbers = input.Split(delimiters, StringSplitOptions.None).Select(int.Parse).ToArray();

            var negative = numbers.Where(n => n < 0).ToArray();

            if (negative.Count() > 0)
            {
                throw  new Exception($"negatives not allowed: {negative[0]}");
            }
          
            
            
            return numbers.Sum();

        }
    }
}