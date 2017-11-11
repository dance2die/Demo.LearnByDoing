using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/556deca17c58da83c00002db/train/csharp
	/// </summary>
	[TestFixture]
	public class TribonacciSequenceTest
	{
		private Xbonacci variabonacci;

		[SetUp]
		public void SetUp()
		{
			variabonacci = new Xbonacci();
		}

		[TearDown]
		public void TearDown()
		{
			variabonacci = null;
		}

		[Test]
		public void Tests()
		{
			Assert.AreEqual(new double[] { 1, 1, 1, 3, 5, 9, 17, 31, 57, 105 }, variabonacci.Tribonacci(new double[] { 1, 1, 1 }, 10));
			Assert.AreEqual(new double[] { 0, 0, 1, 1, 2, 4, 7, 13, 24, 44 }, variabonacci.Tribonacci(new double[] { 0, 0, 1 }, 10));
			Assert.AreEqual(new double[] { 0, 1, 1, 2, 4, 7, 13, 24, 44, 81 }, variabonacci.Tribonacci(new double[] { 0, 1, 1 }, 10));
		}
	}

	public class Xbonacci
	{
		public double[] Tribonacci(double[] signature, int n)
		{
			return null;
		}
	}
}
