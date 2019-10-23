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
                
                delimiters = new string[]{ splitted.First().Replace("//", "")};

                newInput = splitted.Last();
            }
            
            var numbers = newInput
                .Split(delimiters, StringSplitOptions.None)
                .Select(int.Parse)
                .ToArray();

            return numbers.Sum();
        }
    }
}