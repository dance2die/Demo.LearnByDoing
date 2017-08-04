using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu4
{
	/// <summary>
	/// https://www.codewars.com/kata/58d06bfbc43d20767e000074/train/csharp
	/// </summary>
	public class BattleShipsSunkDamagedOrNotTouchedTest : BaseTest
	{
		public BattleShipsSunkDamagedOrNotTouchedTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void BasicTest1()
		{
			var kata = new Kata();
			int[,] board = { 
				{ 0, 0, 1, 0 },
				{ 0, 0, 1, 0 },
				{ 0, 0, 1, 0 } };
			int[,] attacks = { { 3, 1 }, { 3, 2 }, { 3, 3 } };
			var result = Kata.damagedOrSunk(board, attacks);
			Console.WriteLine("Test 1 - sunk = 1, damaged = 0, notTouched = 0, points = 1");
			Assert.Equal(1, result["sunk"]);
			Assert.Equal(0, result["damaged"]);
			Assert.Equal(0, result["notTouched"]);
			Assert.Equal(1, result["points"]);
		}

		[Fact]
		public void BasicTest2()
		{
			var kata = new Kata();
			int[,] board = { 
				{ 3, 0, 1 },
				{ 3, 0, 1 },
				{ 0, 2, 1 },
				{ 0, 2, 0 } };
			int[,] attacks = { { 2, 1 }, { 2, 2 }, { 3, 2 }, { 3, 3 } };
			var result = Kata.damagedOrSunk(board, attacks);
			Console.WriteLine("Test 2 - sunk = 1, damaged = 1, notTouched = 1, points = 0.5");
			Assert.Equal(1, result["sunk"]);
			Assert.Equal(1, result["damaged"]);
			Assert.Equal(1, result["notTouched"]);
			Assert.Equal(0.5, result["points"]);
		}
	}

	partial class Kata
	{
		public static Dictionary<string, double> damagedOrSunk(int[,] board, int[,] attacks)
		{
			Dictionary<string, double> result = new Dictionary<string, double>
			{
				{ "sunk",  0 },
				{ "damaged", 0 },
				{ "notTouched",  0 },
				{ "points", 0 },
			};

			var ships = GetShips(board);

			


			return result;
		}
	}
}
