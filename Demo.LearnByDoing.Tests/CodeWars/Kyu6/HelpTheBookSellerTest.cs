using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Demo.LearnByDoing.Tests.CodeWars.Kyu6
{
	/// <summary>
	/// https://www.codewars.com/kata/help-the-bookseller/train/csharp
	/// </summary>
	public class HelpTheBookSellerTest
	{
		[Test]
		public void Test1()
		{
			string[] art = { "ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600" };
			String[] cd = { "A", "B" };
			Assert.AreEqual("(A : 200) - (B : 1140)", StockList.stockSummary(art, cd));
		}

		[Test]
		public void Test2()
		{
			string[] art = { "ABART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60" };
			String[] cd = { "A", "B", "C", "W" };
			Assert.AreEqual("(A : 20) - (B : 114) - (C : 50) - (W : 0)", StockList.stockSummary(art, cd));
		}
	}

	public static class StockList
	{
		public static string stockSummary(string[] arts, string[] cds)
		{
			var inCd = arts
				.Where(art => cds.Contains(art.Substring(0, 1)))
				.Select(art => new {Key = art[0].ToString(), Value = int.Parse(art.Split()[1])})
				.GroupBy(o => o.Key);
				//.OrderBy(o => o.Key)
				//.Select(g => $"({g.Key} : {g.Sum(o => o.Value)})").ToList();
			var notInCd = cds.Where(cd => !arts.Select(art => art[0].ToString()).Contains(cd));

			return string.Join(" - ", grouped);
		}
	}
}
