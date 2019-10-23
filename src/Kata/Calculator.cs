using System;

namespace Kata
{
    public class Calculator
    {
        public int Add(string userInput)
        {
            if(string.IsNullOrEmpty(userInput))
                return 0;
            
            return  Int32.Parse(userInput);
        }
    }
}