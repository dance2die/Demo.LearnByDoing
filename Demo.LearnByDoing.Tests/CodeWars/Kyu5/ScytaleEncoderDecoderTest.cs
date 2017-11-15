using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu5
{
	/// <summary>
	/// https://www.codewars.com/kata/scytale-encoder-slash-decoder-ancient-spartans-cipher/train/csharp
	/// </summary>
	public class ScytaleEncoderDecoderTest
	{
		[Test]
		public void BasicEncodeTest()
		{
			var message = "HELPMEIAMUNDERATTACK";
			var expected = "HENTEIDTLAEAPMRCMUAK";
			var actual = Scytale.Encode(message, 4);

			Assert.That(actual, Is.EqualTo(expected));
		}

		[Test]
		public void BasicDecodeTest()
		{
			var message = "HENTEIDTLAEAPMRCMUAK";
			var expected = "HELPMEIAMUNDERATTACK";
			var actual = Scytale.Decode(message, 4);

			Assert.That(actual, Is.EqualTo(expected));
		}

		private static IEnumerable<TestCaseData> EncodeTestCases
		{
			get
			{
				yield return new TestCaseData("CodeWars Scytale Kata", 4).Returns("CW t aoaSaK drcla esyet");
				//yield return new TestCaseData("HELLOANDTHANKYOUFORDOINGTHISKATA", 11).Returns("CW t aoaSaK drcla esyet");
			}
		}

		//private static IEnumerable<TestCaseData> DecodeTestCases
		//{
		//	get
		//	{
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//	}
		//}

		//private static IEnumerable<TestCaseData> EncodeDecodeTestCases
		//{
		//	get
		//	{
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//		yield return new TestCaseData("aaa").Returns("bbb");
		//	}
		//}

		[Test, TestCaseSource(nameof(EncodeTestCases))]
		public string TestFailingEncodeTests(string message, int rowSize) => Scytale.Encode(message, rowSize);
		//[Test, TestCaseSource("DecodeTestCases")]
		//public string TestFailingDecodeTests(string message, int rowSize) => Scytale.Decode(message, rowSize);
		//[Test, TestCaseSource("EncodeDecodeTestCases")]
		//public string TestFailingEncodeDecodeTests(string message, int rowSize) => Scytale.Decode(Scytale.Encode(message, rowSize), rowSize);
	}

	public class Scytale
	{
		public static string Encode(string message, int colSize)
		{
			var rowSize = GetColumnSize(message, colSize);
			Console.WriteLine($"{rowSize}, {colSize} => {message}");
			var map = new string[rowSize, colSize];

			// fill the map
			int messageIndex = 0;
			for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
			{
				for (int colIndex = 0; colIndex < colSize; colIndex++)
				{
					map[rowIndex, colIndex] = messageIndex >= message.Length ? " " : message[messageIndex++].ToString();
				}
			}

			// Encode by iterating column wise
			var buffer = new StringBuilder(message.Length);
			for (int colIndex = 0; colIndex < colSize; colIndex++)
			{
				for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
				{
					buffer.Append(map[rowIndex, colIndex]);
				}
			}

			return buffer.ToString().Trim();
		}

		public static string Decode(string message, int colSize)
		{
			var rowSize = GetColumnSize(message, colSize);
			Console.WriteLine($"{rowSize}, {colSize} => {message}");
			var map = new string[rowSize, colSize];

			// fill the map
			int messageIndex = 0;
			for (int colIndex = 0; colIndex < colSize; colIndex++)
			{
				for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
				{
					map[rowIndex, colIndex] = messageIndex >= message.Length ? " " : message[messageIndex++].ToString();
				}
			}

			// Encode by iterating column wise
			var buffer = new StringBuilder(message.Length);
			for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
			{
				for (int colIndex = 0; colIndex < colSize; colIndex++)
				{
					buffer.Append(map[rowIndex, colIndex]);
				}
			}

			return buffer.ToString().Trim();
		}

		private static int GetColumnSize(string message, int colSize)
		{
			return (int) Math.Ceiling((double)message.Length / colSize);
		}
	}
}
