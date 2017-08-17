using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.LearnByDoing.Core;
using Xunit;
using Xunit.Abstractions;

namespace Demo.LearnByDoing.Tests.CodeWars.Beta
{
	/// <summary>
	/// https://www.codewars.com/kata/kanakonverter-i/train/csharp
	/// </summary>
	public class KanaKonverterTest : BaseTest
	{
		public KanaKonverterTest(ITestOutputHelper output) : base(output)
		{
		}

		[Fact]
		public void romajiToHira()
		{ Assert.Equal("あえいおう", KanaKonverter.vowels("aeiou", "hiragana")); }
		[Fact]
		public void romajiToKata()
		{ Assert.Equal("アエイオウ", KanaKonverter.vowels("aeiou", "katakana")); }
		[Fact]
		public void romajiToRomaji()
		{ Assert.Equal("aeiou", KanaKonverter.vowels("aeiou", "romaji")); }

		[Fact]
		public void hiraToHira()
		{ Assert.Equal("あえいおう", KanaKonverter.vowels("あえいおう", "hiragana")); }
		[Fact]
		public void hiraToKata()
		{ Assert.Equal("アエイオウ", KanaKonverter.vowels("あえいおう", "katakana")); }
		[Fact]
		public void hiraToRomaji()
		{ Assert.Equal("aeiou", KanaKonverter.vowels("あえいおう", "romaji")); }

		[Fact]
		public void kataToHira()
		{ Assert.Equal("あえいおう", KanaKonverter.vowels("アエイオウ", "hiragana")); }
		[Fact]
		public void kataToKata()
		{ Assert.Equal("アエイオウ", KanaKonverter.vowels("アエイオウ", "katakana")); }
		[Fact]
		public void kataToRomaji()
		{ Assert.Equal("aeiou", KanaKonverter.vowels("アエイオウ", "romaji")); }

		[Fact]
		public void noInput()
		{ Assert.Equal("", KanaKonverter.vowels("", "romaji")); }
		[Fact]
		public void emptyParameters()
		{ Assert.Equal("", KanaKonverter.vowels("", "")); }

		[Fact]
		public void Uppercase()
		{ Assert.Equal("aAeEoOUu", KanaKonverter.vowels("aAeEoOUu", "romaji")); }
	}

	public class KanaKonverter
	{
		public static string vowels(string input, string output)
		{
			string romajiDictLow = "aeiou";
			string romajiDictUp = "AEIOU";
			string hiraDict = "あえいおう";
			string kataDict = "アエイオウ";

			//todo

			return "";
		}
	}
}
