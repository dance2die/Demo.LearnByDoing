using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/scramblies/train/csharp
	/// </summary>
	public class ScrambliesTest : BaseTest
	{
		public ScrambliesTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public static void Test1()
		{
			Assert.Equal(Scramblies.Scramble("rkqodlw", "world"), true);
			Assert.Equal(Scramblies.Scramble("cedewaraaossoqqyt", "codewars"), true);
			Assert.Equal(Scramblies.Scramble("katas", "steak"), false);
			Assert.Equal(Scramblies.Scramble("scriptjavx", "javascript"), false);
			Assert.Equal(Scramblies.Scramble("scriptingjava", "javascript"), true);
			Assert.Equal(Scramblies.Scramble("scriptsjava", "javascripts"), true);
			Assert.Equal(Scramblies.Scramble("javscripts", "javascript"), false);
			Assert.Equal(Scramblies.Scramble("aabbcamaomsccdd", "commas"), true);
			Assert.Equal(Scramblies.Scramble("commas", "commas"), true);
			Assert.Equal(Scramblies.Scramble("sammoc", "commas"), true);
		}
	}

	public class Scramblies
	{
		public static bool Scramble(string str1, string str2)
		{
			return false;
		}
	}
}
