using System;
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
	}

	public class Scytale
	{
		public static string Encode(string message, int rowSize)
		{
			var colSize = GetColumnSize(message, rowSize);
			var map = new string[rowSize, colSize];

			// fill the map
			int messageIndex = 0;
			for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
			{
				for (int colIndex = 0; colIndex < colSize; colIndex++)
				{
					map[rowIndex, colIndex] = message[messageIndex++].ToString();
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

			return buffer.ToString();
		}

		public static string Decode(string message, int rowSize)
		{
			var colSize = GetColumnSize(message, rowSize);
			var map = new string[rowSize, colSize];

			// fill the map
			int messageIndex = 0;
			for (int colIndex = 0; colIndex < colSize; colIndex++)
			{
				for (int rowIndex = 0; rowIndex < rowSize; rowIndex++)
				{
					map[rowIndex, colIndex] = message[messageIndex++].ToString();
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

			return buffer.ToString();
		}

		private static int GetColumnSize(string message, int rowSize)
		{
			return (int) Math.Ceiling((double)message.Length / rowSize);
		}
	}
}
