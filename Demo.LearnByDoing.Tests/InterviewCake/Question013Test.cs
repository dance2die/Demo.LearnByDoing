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

			actual = sut.GetRotationIndex(new[]{"first"});
			Assert.Equal(expected, actual);
		}

		[Fact]
		public void TestSample()
		{
			var words = new []
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
			if (words == null || words.Length <= 1) return 0;

			// Get previous word.
			var prev = words[0];

			// Compare the current word with the previous word.
			// If the current word comes before the previous word then that's the rotation point, so return that index.
			for (int i = 1; i < words.Length; i++)
			{
				var curr = words[i];
				if (string.CompareOrdinal(curr, prev) < 0) return i;

				prev = curr;
			}

			return 0;
		}
	}
}
