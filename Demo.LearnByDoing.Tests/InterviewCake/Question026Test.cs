using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/reverse-string-in-place
	/// 
	/// Write a method to reverse a string in-place. ↴
	/// 
	/// Since strings in C# are immutable ↴ , first convert the string into an array of characters, do the in-place reversal on that array, and re-join that array into a string before returning it. This isn't technically "in-place" and the array of characters will cost O(n)O(n)O(n) additional space, but it's a reasonable way to stay within the spirit of the challenge. If you're comfortable coding in a language with mutable strings, that'd be even better!
	/// </summary>
	public class Question026Test
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(string expected, string input)
		{
			var sut = new StringReverser();
			var actual = sut.ReverseInPlace(input);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[]{"fedcba", "abcdef" };
			yield return new object[]{"edcba", "abcde" };
		}

		public class StringReverser
		{
			public string ReverseInPlace(string input)
			{
				return string.Empty;
			}
		}
	}
}
