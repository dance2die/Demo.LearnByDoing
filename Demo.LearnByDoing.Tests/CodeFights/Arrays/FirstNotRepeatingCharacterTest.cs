﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeFights.Arrays
{
	/// <summary>
	/// https://codefights.com/interview-practice/task/uX5iLwhc6L5ckSyNC
	/// </summary>
	public class FirstNotRepeatingCharacterTest
	{
		[Theory]
		[InlineData('c', "bcb")]
		[InlineData('c', "abacabad")]
		//[InlineData('_', "abacabaabacaba")]
		//[InlineData('z', "z")]
		//[InlineData('_', "bcccccccb")]
		//[InlineData('d', "abcdefghijklmnopqrstuvwxyziflskecznslkjfabe")]
		//[InlineData('_', "zzz")]
		//[InlineData('y', "bcccccccccccccyb")]
		//[InlineData('d', "xdnxxlvupzuwgigeqjggosgljuhliybkjpibyatofcjbfxwtalc")]
		//[InlineData('g', "ngrhhqbhnsipkcoqjyviikvxbxyphsnjpdxkhtadltsuxbfbrkof")]
		public void SampleTests(char expected, string input)
		{
			char actual = firstNotRepeatingCharacter(input);
			Assert.Equal(expected, actual);
		}

		char firstNotRepeatingCharacter(string s)
		{
			//int result = s.Aggregate((int)s[0], (acc, next) => acc ^ next);
			//return (char) result;

			if (string.IsNullOrWhiteSpace(s)) return '_';

			int result = 0;
			foreach (char c in s)
			{
				result ^= c;
			}

			return (char) result;
		}
	}
}
