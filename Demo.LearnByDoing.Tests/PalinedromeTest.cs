using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests
{
	public class PalinedromeTest : BaseTest
	{
		private readonly PalinedromeChecker _sut = new PalinedromeChecker();

		public PalinedromeTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[ClassData(typeof(PalinedromeTestData))]
		public void TestPalindrome(string word, bool expected)
		{
			bool actual = _sut.IsPalindrome(word);
			Assert.Equal(expected, actual);
		}
	}

	public class PalinedromeChecker
	{
		public bool IsPalindrome(string word)
		{
			if (string.IsNullOrEmpty(word) || word.Length <= 1) return false;

			int start = 0;
			int end = word.Length - 1;
			int mid = end / 2;

			for (int i = start; i <= mid; i++)
			{
				if (word[start] != word[end]) return false;

				start++;
				end--;
			}

			return true;
		}
	}

	public class PalinedromeTestData : TestDataBase
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[] {"ahbcbha", true},
			new object[] {"aba", true},
			new object[] {"aa", true},
			new object[] {"a", false},
			new object[] {"word", false},
			new object[] {"wordw", false},
			new object[] {"", false},
			new object[] {null, false},
		};
	}
}
