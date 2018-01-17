using System;
using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/which-appears-twice
	/// 
	/// 
	/// I have an array of n + 1 numbers. Every number in the range 1..n appears once except for one number that appears twice.
	/// 
	/// Write a method for finding the number that appears twice.
	/// 
	/// </summary>
	public class Question033Test
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestHashVersion(int expected, int[] input)
		{
			int actual = FindDupeUsingHash(input);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] {3, new[] { 1, 2, 3, 4, 3, 5, 6, 7 } };
		}

		private int FindDupeUsingHash(int[] input)
		{
			var isSeen = new HashSet<int>();
			foreach (int number in input)
			{
				if (isSeen.Contains(number)) return number;
				isSeen.Add(number);
			}

			throw new ArgumentException();
		}
	}
}
