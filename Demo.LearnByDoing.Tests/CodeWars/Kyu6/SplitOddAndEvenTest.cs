using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/t-dot-t-t-dot-17-split-odd-and-even/train/csharp
	/// </summary>
	[TestFixture]
	public class SplitOddAndEvenTest
	{
		[Test]
		public void BasicTests()
		{
			Assert.AreEqual(string.Join(", ", new long[] { 1, 2, 3 }), string.Join(", ", Kata.SplitOddAndEven(123)));
			Assert.AreEqual(string.Join(", ", new long[] { 22, 3 }), string.Join(", ", Kata.SplitOddAndEven(223)));
			Assert.AreEqual(string.Join(", ", new long[] { 111 }), string.Join(", ", Kata.SplitOddAndEven(111)));
			Assert.AreEqual(string.Join(", ", new long[] { 13579 }), string.Join(", ", Kata.SplitOddAndEven(13579)));
			Assert.AreEqual(string.Join(", ", new long[] { 135, 246 }), string.Join(", ", Kata.SplitOddAndEven(135246)));
			Assert.AreEqual(string.Join(", ", new long[] { 1, 2, 3, 4, 5, 6 }), string.Join(", ", Kata.SplitOddAndEven(123456)));
		}
	}

	public partial class Kata
	{
		public static long[] SplitOddAndEven(long number)
		{
			long prevBit = -1;
			var numberText = number.ToString();
			var result = new List<long>(numberText.Length);

			numberText
				.Select(c => long.Parse(c.ToString()))
				.Aggregate("", (acc, n) =>
				{
					long currBit = n % 1;
					if (currBit == prevBit)
					{
						acc += n;
					}
					else
					{
						result.Add(long.Parse(acc + n));
						acc = "";
					}

					prevBit = currBit;
					return acc;
				});

			return result.ToArray();
		}
	}
}
