using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public static string Decode(string message, int cylinderSides)
		{
			// TODO: implement me
			return message;
		}

		public static string Encode(string message, int cylinderSides)
		{
			// TODO: implement me

			return message;
		}
	}
}
