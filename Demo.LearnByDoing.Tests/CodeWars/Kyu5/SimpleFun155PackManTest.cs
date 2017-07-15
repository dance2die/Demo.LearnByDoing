using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/simple-fun-number-155-pac-man
	/// </summary>
	public class SimpleFun155PackManTest : BaseTest
	{
		private readonly Kata _sut = new Kata();
		public SimpleFun155PackManTest(ITestOutputHelper output) : base(output)
		{
		}

		[Theory]
		[MemberData(nameof(GetBasicMembers))]
		public void BasicTests(int expected, int N, int[] PM, int[][] enemies)
		{
			int actual = _sut.PacMan(N, PM, enemies);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> GetBasicMembers()
		{
			yield return new object[] { 0, 1,   new [] { 0, 0 },   new int[][] { } };
			yield return new object[] { 3, 2,   new [] { 0, 0 },   new int[][] { } };
			yield return new object[] { 8, 3,   new [] { 0, 0 },   new int[][] { } };
			yield return new object[] { 8, 3,   new [] { 0, 0 },   new int[][] { } };
			yield return new object[] { 0, 2,   new [] { 0, 0 },   new int[][] { new [] { 1, 1 } } };
			yield return new object[] { 0, 3,   new [] { 2, 0 },   new int[][] { new [] { 1, 1 } } };
			yield return new object[] { 3, 3,   new [] { 2, 0 },   new int[][] { new [] { 0, 2 } } };
			yield return new object[] { 15, 10, new [] { 4, 6 },   new int[][] { new [] { 0, 2 }, new int[] { 5, 2 }, new int[] { 5, 5 } } };
			yield return new object[] { 19, 8,  new [] { 1, 1 },   new int[][] { new [] { 5, 4 } } };
			yield return new object[] { 14, 8,  new [] { 1, 5 },   new int[][] { new [] { 5, 4 } } };
			yield return new object[] { 17, 8,  new [] { 6, 1 },   new int[][] { new [] { 5, 4 } } };
		}
	}

	partial class Kata
	{
		public int PacMan(int N, int[] PM, int[][] enemies)
		{
			//coding and coding..


		}
	}
}
