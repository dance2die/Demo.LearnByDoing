using System.Collections.Generic;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.Algorithms
{
	public class MakePalindromeTest : BaseTest
	{
		private readonly MakePalindrome _sut = new MakePalindrome();

		public MakePalindromeTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[InlineData("BAAABAAB", "AAAB")]
		[InlineData("abxabacab", "axba")]
		[InlineData("ABB", "A")]
		public void TestForwardLoopResult(string word, string expected)
		{
			string actual = _sut.GetForwardPrefix(word);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData("BAAABAAB", "AAABAAB")]
		[InlineData("abxabacab", "bxabacab")]
		[InlineData("ABB", "BB")]
		public void TestBackwardLoopResult(string word, string expected)
		{
			string actual = _sut.GetBackwardPrefix(word);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[ClassData(typeof(AddMinCharToMakePalindromeTest_Data))]
		public void AddMinCharToMakePalindrome(string word, string expected)
		{
			
		}
	}

	public class MakePalindrome
	{
		public string GetForwardPrefix(string word)
		{
			var potential = new List<string>();
			var notMatched = new Stack<string>();

			int lastIndex = word.Length - 1;
			int j = lastIndex;

			for (int i = 0; i < word.Length; i++)
			{
				if (word[i] == word[j])
				{
					potential.Add(word[i].ToString());
					j--;
					if (j <= i) break;
				}
				else
				{
					PushRange(notMatched, potential);
					notMatched.Push(word[i].ToString());
					potential.Clear();
					j = lastIndex;
				}
			}

			return string.Join("", notMatched);
		}

		public string GetBackwardPrefix(string word)
		{
			var potential = new List<string>();
			var notMatched = new Stack<string>();

			int firstIndex = 0;
			int j = firstIndex;

			for (int i = word.Length - 1; i >= 0; i--)
			{
				if (word[i] == word[j])
				{
					potential.Add(word[i].ToString());
					j++;
					if (j >= i) break;
				}
				else
				{
					PushRange(notMatched, potential);
					notMatched.Push(word[i].ToString());
					potential.Clear();
					j = firstIndex;
				}
			}

			return string.Join("", notMatched);
		}

		private void PushRange<T>(Stack<T> source, IEnumerable<T> collection)
		{
			foreach (var item in collection)
				source.Push(item);
		}
	}

	public class AddMinCharToMakePalindromeTest_Data : TestDataBase
	{
		public override List<object[]> Data { get; set; } = new List<object[]>
		{
			new object[]{"BAAABAAB", "BAABAAABAAB" }
		};
	}
}
