using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo.LearnByDoing.Tests.InterviewCake
{
	public class Question013Test
	{
		[Fact]
		public void TestEdgeCases()
		{
			const int expected = 0;
			var sut = new Question013();

			int actual = sut.GetRotationIndex(null);
			Assert.Equal(expected, actual);

			actual = sut.GetRotationIndex(new string[]{});
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestSample()
		{
			var words = new string[]
			{
				"ptolemaic",
				"retrograde",
				"supplant",
				"undulate",
				"xenoepist",
				"asymptote",  // <-- rotates here!
				"babka",
				"banoffee",
				"engender",
				"karpatka",
				"othellolagkage",
			};

			const int expected = 5;
			int actual = new Question013().GetRotationIndex(words);
			Assert.Equal(expected, actual);
		}
	}

	public class Question013
	{
		public int GetRotationIndex(string[] words)
		{
			if (words == null || words.Length == 0) return 0;

			return 0;
		}
	}
}
