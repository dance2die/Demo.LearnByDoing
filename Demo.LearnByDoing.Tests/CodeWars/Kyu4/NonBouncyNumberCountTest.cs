using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/total-increasing-or-decreasing-numbers-up-to-a-power-of-10/train/csharp
	/// </summary>
	public class NonBouncyNumberCountTest : BaseTest
	{
		public NonBouncyNumberCountTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetNumbers))]
		public void TestTotalIncDecCount(int power, string expected)
		{
			BigInteger actual = TotalIncreasingOrDecreasingNumbers.TotalIncDec(power);
			Assert.Equal(BigInteger.Parse(expected), actual);
		}

		public static IEnumerable<object[]> GetNumbers()
		{
			yield return new object[] { 0, "1" };
			yield return new object[] { 1, "10" };
			yield return new object[] { 2, "100" };
			yield return new object[] { 3, "457" };
			yield return new object[] { 4, "1675" };
			yield return new object[] { 5, "4954" };
			yield return new object[] { 6, "12952" };
		}
	}

	public class TotalIncreasingOrDecreasingNumbers
	{
		public static BigInteger TotalIncDec(int power)
		{
			BigInteger total = BigInteger.Zero;
			BigInteger upto = BigInteger.Pow(10, power);

			if (upto <= 100) return upto;

			for (BigInteger i = 1; i < upto; i++)
			{
				if (!IsBouncyNumber(i))
					total++;
			}

			return total;
		}

		private static bool IsBouncyNumber(BigInteger number)
		{
			if (number <= 99) return false;

			var digits = GetDigits(number).ToList();
			var prev = digits.FirstOrDefault();

			var isDecreasing = false;
			var isIncreasing = false;

			for (int i = 1; i < digits.Count; i++)
			{
				var next = digits[i];

				// is Decreasing
				if (prev >= next)
					isDecreasing = true;

				// is Increasing
				if (prev <= next)
					isIncreasing = true;

				if (isDecreasing && isIncreasing)
					return true;
			}

			return false;
		}

		private static IEnumerable<int> GetDigits(BigInteger number)
		{
			foreach (char c in number.ToString())
			{
				yield return c - '0';
			}
		}
	}
}
