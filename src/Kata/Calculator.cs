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

            var numbers = userInput.Split(",").Select(int.Parse).ToArray();
            return numbers.Sum();

        }
    }
}