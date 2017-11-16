using System;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.RandomStuff
{
	/// <summary>
	/// https://medium.freecodecamp.org/learn-recursion-in-10-minutes-e3262ac08a1
	/// </summary>
	public class BinaryPrintTest : BaseTest
	{
		public BinaryPrintTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void JustPrint()
		{
			var digit = 2;
			var a = new int[2];
			PrintBinaryCombinations(a, digit);
		}
		

		private void PrintBinaryCombinations(int[] a, int i)
		{
			if (i == 0)
			{
				Console.WriteLine(string.Join("", a.Select(n => n)));
				_output.WriteLine(string.Join("", a.Select(n => n)));
				return;
			}

			a[i - 1] = 0;
			PrintBinaryCombinations(a, i - 1);
			a[i - 1] = 1;
			PrintBinaryCombinations(a, i - 1);
		}
	}
}
