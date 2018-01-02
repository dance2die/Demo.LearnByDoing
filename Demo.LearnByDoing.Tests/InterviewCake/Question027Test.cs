using System.Collections.Generic;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	/// <summary>
	/// https://www.interviewcake.com/question/csharp/reverse-words
	/// 
	///   You're working on a secret team solving coded transmissions.
	/// 
	/// Your team is scrambling to decipher a recent message, worried it's a plot to break into a major European National Cake Vault. The message has been mostly deciphered, but all the words are backwards! Your colleagues have handed off the last step to you.
	/// 
	/// Write a method ReverseWords() that takes a string message and reverses the order of the words in-place. ↴
	/// 
	/// Since strings in C# are immutable ↴ , we'll first convert the string into an array of characters, do the in-place word reversal on that array, and re-join that array into a string before returning it. This isn't technically "in-place" and the array of characters will cost O(n)O(n)O(n) additional space, but it's a reasonable way to stay within the spirit of the challenge. If you're comfortable coding in a language with mutable strings, that'd be even better!
	/// 
	/// For example:
	/// 
	/// var message = "find you will pain only go you recordings security the into if";
	/// 
	/// // Returns: "if into the security recordings you go only pain will you find"
	/// var result = ReverseWords(message);
	/// 
	/// When writing your method, assume the message contains only letters and spaces, and all words are separated by one space. 
	/// </summary>
	public class Question027Test
	{
		[Theory]
		[MemberData(nameof(GetSampleCases))]
		public void TestSampleCases(string expected, string sentence)
		{
			var sut = new SentenceReverser();
			var actual = sut.ReverseWords(sentence);

			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetSampleCases()
		{
			yield return new object[]
			{
				"if into the security recordings you go only pain will you find",
				"find you will pain only go you recordings security the into if"
			};

			yield return new object[] {"whatever you do", "do you whatever"};
			yield return new object[] {"abc", "abc"};
			yield return new object[] {"", ""};
			yield return new object[] {"abc def", "def abc"};
		}

		class SentenceReverser
		{
			public string ReverseWords(string sentence)
			{
				string[] words = sentence.Split(' ');
				if (words.Length <= 1) return sentence;

				int startIndex = 0;
				int endIndex = words.Length - 1;

				while (startIndex < endIndex)
				{
					var tempWord = words[startIndex];
					words[startIndex] = words[endIndex];
					words[endIndex] = tempWord;

					startIndex++;
					endIndex--;
				}

				return string.Join(" ", words);
			}
		}
	}
}
