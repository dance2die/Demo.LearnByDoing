using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/recursive-string-permutations
	/// 
	/// 
	/// 
	/// Write a recursive method for generating all permutations of an input string. Return them as a set.
	/// 
	/// Don't worry about time or space complexity—if we wanted efficiency we'd write an iterative version.
	/// 
	/// To start, assume every character in the input string is unique.
	/// 
	/// Your method can have loops—it just needs to also be recursive.
	/// </summary>
	public class Question031Test
	{
		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[] { "a", new[] { "a" } };
			yield return new object[] { "ab", new[] { "ab", "ba" } };
			yield return new object[] { "abc", new[] { "abc", "acb", "bac", "bca", "cab", "cba" } };
			yield return new object[] { "abcd", new[]
			{
				"abcd","bacd","cabd","acbd",
				"bcad","cbad","cbda","bcda",
				"dcba","cdba","bdca","dbca",
				"dacb","adcb","cdab","dcab",
				"acdb","cadb","badc","abdc",
				"dbac","bdac","adbc","dabc"
			}};
		}

		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(string input, string[] expected)
		{
			var sut = new Question031();
			string[] actual = sut.GetPermutations(input);

			Assert.True(expected.OrderBy(t => t).SequenceEqual(actual.OrderBy(t => t)));
		}
	}

	public class Question031
	{
		public string[] GetPermutations(string input)
		{
			return FillPermutations(input).ToArray();
		}

		private IEnumerable<string> FillPermutations(string input)
		{
			if (input.Length == 1) yield return input;
			else if (input.Length == 2)
			{
				yield return input;
				yield return new string(new[] { input[1], input[0] });
			}
			else
			{
				for (int i = 0; i < input.Length; i++)
				{
					string prefix = input[i].ToString();
					string left = input.Substring(0, i);
					string right = input.Substring(i + 1);
					string newInput = left + right;

					foreach (var rest in FillPermutations(newInput))
					{
						yield return prefix + rest;
					}
				}
			}
		}
	}
}
