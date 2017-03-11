using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.LearnByDoing.General
{
    public class ParsingNumbersPerDigitProgram
    {
        public static void Main(string[] args)
        {
            //int val = 192837465;
            int val = 123456789;
            List<int> digits = GetDigits(val);

            digits.ForEach(Console.WriteLine);

            Console.ReadKey();
        }

        private static List<int> GetDigits(int val)
        {
            Stack<int> stack = new Stack<int>();

            int number = val;
            while (number > 0)
            {
                var digit = number % 10;
                stack.Push(digit);

                number /= 10;
            }

            return stack.ToList();
        }
    }
}
