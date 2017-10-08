using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	public class CondiCipherTest
	{
		[Theory]
		[InlineData("jx", "on", "cryptogam", 10)]
		[InlineData("cytgmdfmbk", "cryptogram", "cryptogam", 0)]
		[InlineData("jx wnz xrkvz jnd l ufd vwcz.", "on the first day i got lost.", "cryptogam", 10)]
		[InlineData("n ggka cvssb bfe esz omgdyr bqqva", "i will never eat any grapes again", "superkey", 4)]
		public void TestEncoding(string expected, string key, string m, int initShift)
		{
			Assert.Equal(expected, Kata.Encode(key, m, initShift));
		}

		[Theory]
		[InlineData("on", "jx", "cryptogam", 10)]
		[InlineData("....", "....", "cryptogam", 10)]
		[InlineData("sit", "abc", "keykeykeykey", 10)]
		[InlineData(",sit", ",abc", "keykeykeykey", 10)]
		[InlineData("on the first day i got lost.", "jx wnz xrkvz jnd l ufd vwcz.", "cryptogam", 10)]
		[InlineData("i will never eat any grapes again", "n ggka cvssb bfe esz omgdyr bqqva", "superkey", 30)]
		[InlineData("zva nguhbmmgydx.s,ok se,rmafz vpedgbua", "qvf cmnxmdkjfca.p,ab mf,byokf vjhwpcyb", "nqhbfgmi", 28)]
		public void TestDecoding(string expected, string key, string m, int initShift)
		{
			Assert.Equal(expected, Kata.Decode(key, m, initShift));
		}

		[Theory]
		public void TestKeyGeneration()
		{
			
		}
	}

	public partial class Kata
	{
		public static string Encode(string key, string m, int initShift)
		{
			return m;
		}
		public static string Decode(string key, string m, int initShift)
		{
			return m;
		}
	}
}
