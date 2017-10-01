using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/who-likes-it/train/csharp
	/// </summary>
	public class WhoLikesItTest
	{
		[Theory]
		[InlineData("no one likes this", new string[0])]
		[InlineData("Peter likes this", new string[] { "Peter" })]
		[InlineData("Jacob and Alex like this", new string[] { "Jacob", "Alex" })]
		[InlineData("Max, John and Mark like this", new string[] { "Max", "John", "Mark" })]
		[InlineData("Alex, Jacob and 2 others like this", new string[] { "Alex", "Jacob", "Mark", "Max" })]
		public void SampleTestCases(string expected, string[] input)
		{
			var actual = Kata.Likes(input);
			Assert.Equal(expected, actual);
		}
	}

	public static partial class Kata
	{
		public static string Likes(string[] name)
		{
			if (name == null || name.Length == 0) return "no one likes this";
			if (name.Length == 1) return $"{name[0]} likes this";
			if (name.Length == 2) return $"{name[0]} and {name[1]} like this";
			if (name.Length == 3) return $"{name[0]}, {name[1]} and {name[2]} like this";

			throw new Exception("You shouldn't get here!");
		}
	}
}
