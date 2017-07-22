using System;
using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/5659c6d896bc135c4c00021e/train/csharp
	/// </summary>
	public class NextSmallerNumberWithTheSameDigitsTest : BaseTest
	{
		public NextSmallerNumberWithTheSameDigitsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData(9, -1)]
		[InlineData(111, -1)]
		[InlineData(135, -1)]
		[InlineData(21, 12)]
		[InlineData(907, 970)]
		[InlineData(531, 513)]
		[InlineData(2071, 2017)]
		[InlineData(2017, 1720)]
		[InlineData(1027, -1)]
		[InlineData(441, 414)]
		[InlineData(123456798, 123456789)]
		public void FixedTests(long number, long expected)
		{
			long actual = Kata.NextSmaller(number);
			Assert.Equal(expected, actual);
		}
	}

	public partial class Kata
	{
		public static long NextSmaller(long number)
		{
			var digits = GetDigits(number).ToList();
			int from = digits.Count - 1;
			int foundAt = -1;

			// Move the least significant digit to the left most

			// 2nd iteration: From found lo

			do
			{
				for (int i = from; i >= foundAt + 1; i--)
				{
					for (int j = i - 1; j >= foundAt + 1; j--)
					{
						if (i == from && digits[i] < digits[j])
						{
							foundAt = j;
							digits = Swap(digits, i, j);
						}
						else if (i < from && digits[i] > digits[j])
						{
							foundAt = j;
							digits = Swap(digits, i, j);
						}
					}
				}
			} while (foundAt > 0);

			const int notFound = -1;
			var smallerCandidate = ToLong(digits);
			return smallerCandidate >= number ? notFound : smallerCandidate;
		}

		private static List<int> Swap(List<int> digits, int i, int j)
		{
			var temp = digits[i];
			digits[i] = digits[j];
			digits[j] = temp;
			return digits;
		}

		private static long ToLong(List<int> digits)
		{
			return long.Parse(string.Join("", digits.Select(digit => digit.ToString())));
		}

		private static IEnumerable<int> GetDigits(long number)
		{
			foreach (char c in number.ToString())
			{
				yield return c - '0';
			}
		}

	}
}
