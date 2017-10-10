using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeFights.Arrays
{
	/// <summary>
	/// https://codefights.com/interview-practice/task/pMvymcahZ8dY4g75q
	/// </summary>
	public class FirstDuplicateTest
	{
		[Theory]
		[InlineData(3, new[] { 2, 3, 3, 1, 5, 2 })]
		[InlineData(-1, new[] { 2, 4, 3, 5, 1 })]
		public void TestSampleData(int expected, int[] input)
		{
			var actual = firstDuplicate(input);
			Assert.Equal(expected, actual);
		}

		int firstDuplicate(int[] a)
		{
			return -100;
		}
	}
}
