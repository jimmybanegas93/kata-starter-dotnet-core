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

            var numbers = userInput.Split(",");

            if (numbers.Length == 1)
            {
                return Parse(userInput);
            }

            var n1 = Parse(numbers[0]);
            var n2 = Parse(numbers[1]);

            return n1 + n2;

//            return numbers.Select(n => Parse(n)).Sum();

        }
    }
}