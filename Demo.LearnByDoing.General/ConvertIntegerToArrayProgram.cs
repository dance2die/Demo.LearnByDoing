using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.LearnByDoing.General
{
	/// <summary>
	/// https://www.mindmeister.com/871561963
	/// 
	/// Write a method that, given an integer, will return it as an   array. E.g., given 1234, return [1, 2, 3, 4].
	/// </summary>
	public class ConvertIntegerToArrayProgram
	{
		public static void Main(string[] args)
		{
			int value = 1234567890;
			int[] a1 = GetArray1(value);
			Console.WriteLine(a1);

			//int[] a2 = GetArray2(value);
			//Console.WriteLine(a2);
		}

		private static int[] GetArray1(int value)
		{
			int currentValue = value;
			Stack<int> digits = new Stack<int>();
			while (currentValue > 0)
			{
				int digit = currentValue % 10;
				digits.Push(digit);
				currentValue /= 10;
			}

			return digits.ToArray();
		}
	}
}
