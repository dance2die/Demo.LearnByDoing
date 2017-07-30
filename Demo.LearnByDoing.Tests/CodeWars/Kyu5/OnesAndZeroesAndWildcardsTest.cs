using System.Collections.Generic;
using System.Linq;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	public class OnesAndZeroesAndWildcardsTest : BaseTest
	{
		public OnesAndZeroesAndWildcardsTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void Basic1()
		{
			var list = new List<string> { "1001", "1011" };
			Assert.Equal(new Kata().Possibilities("10?1").OrderBy(t => t), list.OrderBy(t => t));
		}

		[Fact]
		public void Basic2()
		{
			var list = new List<string> { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
			Assert.Equal(new Kata().Possibilities("????").OrderBy(t => t), list.OrderBy(t => t));
		}

		[Fact]
		public void Basic3()
		{
			var list = new List<string> { "1010", "1110", "1011", "1111" };
			Assert.Equal(new Kata().Possibilities("1?1?").OrderBy(t => t), list.OrderBy(t => t));
		}
	}

	public partial class Kata
	{
		public List<string> Possibilities(string input)
		{
			return new List<string>();
		}
	}
}
